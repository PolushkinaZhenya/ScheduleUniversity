using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System.Windows.Forms;

namespace ScheduleDesktop.AdditionalReferences
{
	public static class AdditionalReferenceCreator
	{
		public static Form GetTypeOfAudienceForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<TypeOfAudienceBindingModel, TypeOfAudienceViewModel>>();
			formElement.Width = 300;
			formElement.Height = 130;

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Тип : "
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(50, 8),
				Name = "textBoxType",
				Size = new System.Drawing.Size(230, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");
			formElement.Text = "Тип аудитории";

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<TypeOfAudienceBindingModel, TypeOfAudienceViewModel, FormAdditionalReference<TypeOfAudienceBindingModel, TypeOfAudienceViewModel>>>();
			form.Form = formElement;
			form.Text = "Типы аудиторий";
			return form;
		}

		public static Form GetTypeOfDepartmentForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>>();
			formElement.Width = 300;
			formElement.Height = 130;

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Тип : "
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(50, 8),
				Name = "textBoxType",
				Size = new System.Drawing.Size(230, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");
			formElement.Text = "Тип кафедры";

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel, FormAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>>>();
			form.Form = formElement;
			form.Text = "Типы кафедр";
			return form;
		}

		public static Form GetTypeOfClassForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<TypeOfClassBindingModel, TypeOfClassViewModel>>();
			formElement.Width = 300;
			formElement.Height = 160;

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Тип : "
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(50, 8),
				Name = "textBoxType",
				Size = new System.Drawing.Size(230, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");
			formElement.Text = "Тип занятия";

			var shortlabel = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Сокращенное название: "
			};
			formElement.AddControl(shortlabel, false);

			var shorttextbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(170, 38),
				Name = "textBoxShort",
				Size = new System.Drawing.Size(110, 10),
				TabIndex = 1
			};
			formElement.AddControl(shorttextbox, true, "AbbreviatedTitle");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<TypeOfClassBindingModel, TypeOfClassViewModel, FormAdditionalReference<TypeOfClassBindingModel, TypeOfClassViewModel>>>();
			form.Form = formElement;
			form.Text = "Типы занятий";
			return form;
		}
	}
}