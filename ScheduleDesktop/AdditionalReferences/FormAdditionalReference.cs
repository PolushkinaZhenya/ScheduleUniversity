using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop.AdditionalReferences
{
	public partial class FormAdditionalReference<B, V, S> : Form
		where B : BaseBindingModel, new()
		where V : BaseViewModel
		where S : BaseSearchModel, new()
	{
		private readonly IBaseService<B, V, S> _service;

		private Guid? _id;

		private readonly List<(string controlName, bool mustCheck, string propertyName)> _controls;

		public Guid? Id { set { _id = value; } }

		public FormAdditionalReference(IBaseService<B, V, S> service)
		{
			InitializeComponent();
			_service = service;
			_controls = new List<(string controlName, bool mustCheck, string propertyName)>();
		}

		public void AddControl(Control control, bool check, string propertyName = null)
		{
			if (control == null)
			{
				return;
			}
			panelControls.Controls.Add(control);
			if (propertyName.IsNotEmpty())
			{
				_controls.Add((control.Name, check, propertyName));
			}
		}

		private void FormAdditionalReference_Load(object sender, EventArgs e)
		{
			foreach (var control in panelControls.Controls)
			{
				switch (control.GetType().Name)
				{
					case "TextBox":
						((TextBox)control).Text = string.Empty;
						break;
					case "MaskedTextBox":
						((MaskedTextBox)control).Text = string.Empty;
						break;
					case "NumericUpDown":
						((NumericUpDown)control).Value = ((NumericUpDown)control).Minimum;
						break;
					case "ComboBox":
						((ComboBox)control).SelectedIndex = -1;
						((ComboBox)control).SelectedValue = null;
						break;
				}
			}
			LoadData();
		}

		private void LoadData()
		{
			if (_id.HasValue)
			{
				try
				{
					var view = _service.GetElement(new S { Id = _id.Value});
					if (view != null)
					{
						var properties = view.GetType().GetProperties();
						foreach (var prop in properties)
						{
							var cntrl = _controls.FirstOrDefault(x => x.propertyName == prop.Name);
							if (cntrl != default)
							{
								var controls = panelControls.Controls.Find(cntrl.controlName, true);
								foreach (var control in controls)
								{
									switch (control.GetType().Name)
									{
										case "TextBox":
											((TextBox)control).Text = prop.GetValue(view)?.ToString();
											break;
										case "MaskedTextBox":
											((MaskedTextBox)control).Text = prop.GetValue(view)?.ToString();
											break;
										case "NumericUpDown":
											((NumericUpDown)control).Value = Convert.ToDecimal(prop.GetValue(view));
											break;
										case "DateTimePicker":
											((DateTimePicker)control).Value = Convert.ToDateTime(prop.GetValue(view));
											break;
										case "ComboBox":
											if (prop.Name.Contains("Id"))
											{
												((ComboBox)control).SelectedValue = prop.GetValue(view);
											}
											else
											{
												((ComboBox)control).SelectedIndex = ((ComboBox)control).Items.IndexOf(prop.GetValue(view));
											}
											break;
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка загрузки");
				}
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			foreach (var (controlName, mustCheck, propertyName) in _controls.Where(x => x.mustCheck))
			{
				var controls = panelControls.Controls.Find(controlName, true);
				foreach (var control in controls)
				{
					switch (control.GetType().Name)
					{
						case "TextBox":
							if (((TextBox)control).Text.IsEmpty())
							{
								((TextBox)control).BackColor = Color.OrangeRed;
								Program.ShowError("Не все обязательные поля заполнены", "Ошибка заполнения");
								return;
							}
							else
							{
								((TextBox)control).BackColor = Color.White;
							}
							break;
						case "MaskedTextBox":
							if (((MaskedTextBox)control).Text.IsEmpty())
							{
								((MaskedTextBox)control).BackColor = Color.OrangeRed;
								Program.ShowError("Не все обязательные поля заполнены", "Ошибка заполнения");
								return;
							}
							else
							{
								((MaskedTextBox)control).BackColor = Color.White;
							}
							break;
						case "ComboBox":
							if (propertyName.Contains("Id"))
							{
								if (((ComboBox)control).SelectedValue == null)
								{
									((ComboBox)control).BackColor = Color.OrangeRed;
									Program.ShowError("Не все обязательные поля заполнены", "Ошибка заполнения");
									return;
								}
								else
								{
									((ComboBox)control).BackColor = Color.White;
								}
							}
							else
							{
								if (((ComboBox)control).SelectedIndex == -1)
								{
									((ComboBox)control).BackColor = Color.OrangeRed;
									Program.ShowError("Не все обязательные поля заполнены", "Ошибка заполнения");
									return;
								}
								else
								{
									((ComboBox)control).BackColor = Color.White;
								}
							}
							break;
					}
				}
			}
			try
			{
				var obj = new B();
				foreach (var (controlName, mustCheck, propertyName) in _controls.Where(x => !string.IsNullOrEmpty(x.propertyName)))
				{
					var control = panelControls.Controls.Find(controlName, true);
					object value = null;
					if (control.FirstOrDefault() != null)
					{
						switch (control.FirstOrDefault().GetType().Name)
						{
							case "TextBox":
								value = (control.FirstOrDefault() as TextBox).Text;
								break;
							case "MaskedTextBox":
								value = (control.FirstOrDefault() as MaskedTextBox).Text;
								break;
							case "NumericUpDown":
								value = (control.FirstOrDefault() as NumericUpDown).Value;
								break;
							case "DateTimePicker":
								value = (control.FirstOrDefault() as DateTimePicker).Value;
								break;
							case "ComboBox":
								if (propertyName.Contains("Id"))
								{
									value = (control.FirstOrDefault() as ComboBox).SelectedValue;
								}
								else
								{
									value = (control.FirstOrDefault() as ComboBox).SelectedText;
								}
								break;
						}
					}
					var property = obj.GetType().GetProperty(propertyName);
					if (property != null && value != null)
					{
						if (property.PropertyType == typeof(TimeSpan))
						{
							property.SetValue(obj, TimeSpan.Parse(value.ToString()), null);
						}
						else
						{
							property.SetValue(obj, Convert.ChangeType(value, property.PropertyType), null);
						}
					}
				}
				if (_id.HasValue)
				{
					obj.Id = _id.Value;
					_service.UpdElement(obj);
				}
				else
				{
					_service.AddElement(obj);
				}
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка сохранения");
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}