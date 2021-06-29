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
											(control as TextBox).Text = prop.GetValue(view)?.ToString();
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
							if (string.IsNullOrEmpty((control as TextBox).Text))
							{
								(control as TextBox).BackColor = Color.OrangeRed;
								Program.ShowError("Не все обязательные поля заполнены", "Ошибка заполнения");
								return;
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
						(control as TextBox).Text = string.Empty;
						break;
				}
			}
			LoadData();
		}
	}
}