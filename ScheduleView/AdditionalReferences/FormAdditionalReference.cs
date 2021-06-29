using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleView.AdditionalReferences
{
	public partial class FormAdditionalReference<B, V> : Form
		where B : AdditionalReferenceBindingModel
		where V : AdditionalReferenceViewModel
	{
		private readonly IAdditionalReference<B, V> _service;

		private Guid? id;

		private List<(string controlName, bool mustCheck, string propertyName)> _controls;

		public Guid Id { set { id = value; } }

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

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			//foreach(var elem in _controls.Where(x => x.mustCheck))
			//{
			//	var controls = panelControls.Controls.Find(elem.controlName, true);
			//	foreach(var control in controls)
			//	{
			//		switch (control.GetType())
			//		{
			//			case Type.GetType("TextBox"):
			//				break;
			//		}
			//	}
			//}
			//if (string.IsNullOrEmpty(textBoxType.Text))
			//{
			//	MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}
			//try
			//{
			//	if (id.HasValue)
			//	{
			//		_service.UpdElement(new TypeOfAudienceBindingModel
			//		{
			//			Id = id.Value,
			//			Title = textBoxType.Text
			//		});
			//	}
			//	else
			//	{
			//		_service.AddElement(new TypeOfAudienceBindingModel
			//		{
			//			Title = textBoxType.Text
			//		});
			//	}
			//	DialogResult = DialogResult.OK;
			//	Close();
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}