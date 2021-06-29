using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop.AdditionalReferences
{
	public partial class FormAdditionalReference<B, V> : Form
		where B : AdditionalReferenceBindingModel, new()
		where V : AdditionalReferenceViewModel
	{
		private readonly IAdditionalReference<B, V> _service;

		private Guid? id;

		private readonly List<(string controlName, bool mustCheck, string propertyName)> _controls;

		public Guid? Id { set { id = value; } }

		public FormAdditionalReference(IAdditionalReference<B, V> service)
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
			if (!string.IsNullOrEmpty(propertyName))
			{
				_controls.Add((control.Name, check, propertyName));
			}
		}

		private void LoadData()
		{
			if (id.HasValue)
			{
				try
				{
					var view = _service.GetElement(id.Value);
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
										case "ComboBox":
											if (((ComboBox)control).Items.Count == 0)
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
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
							if (string.IsNullOrEmpty(((TextBox)control).Text))
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
							if (string.IsNullOrEmpty(((MaskedTextBox)control).Text))
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
							if (((ComboBox)control).Items.Count == 0)
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
							case "ComboBox":
								if ((control.FirstOrDefault() as ComboBox).Items.Count == 0)
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
						property.SetValue(obj, value);
					}
				}
				if (id.HasValue)
				{
					obj.Id = id.Value;
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
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
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
				}
			}
			LoadData();
		}
	}
}