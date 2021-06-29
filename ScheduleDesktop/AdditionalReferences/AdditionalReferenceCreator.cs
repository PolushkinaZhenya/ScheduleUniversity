using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
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

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<TypeOfAudienceBindingModel, TypeOfAudienceViewModel>>();
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

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>>();
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

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<TypeOfClassBindingModel, TypeOfClassViewModel>>();
			form.Form = formElement;
			form.Text = "Типы занятий";
			return form;
		}

		public static Form GetEducationalBuildingForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<EducationalBuildingBindingModel, EducationalBuildingViewModel>>();
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
				Text = "Номер : "
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(100, 8),
				Name = "textBoxType",
				Size = new System.Drawing.Size(180, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Number");
			formElement.Text = "Учебный корпус";

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<EducationalBuildingBindingModel, EducationalBuildingViewModel>>();
			form.Form = formElement;
			form.Text = "Учебные корпуса";
			return form;
		}

		public static Form GetTransitionTimeForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<TransitionTimeBindingModel, TransitionTimeViewModel>>();
			formElement.Width = 300;
			formElement.Height = 130;

			var educationalBuilding = DependencyManager.Instance.Resolve<IAdditionalReference<EducationalBuildingBindingModel, EducationalBuildingViewModel>>();
			var listFrom = educationalBuilding.GetList();

			var labelFrom = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelFrom",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Из корпуса : "
			};
			formElement.AddControl(labelFrom, false);

			var comboBoxFrom = new ComboBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				FormattingEnabled = true,
				Location = new System.Drawing.Point(136, 8),
				Name = "comboBoxEducationalBuildingFrom",
				Size = new System.Drawing.Size(237, 24),
				TabIndex = 1,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			if (listFrom != null)
			{
				comboBoxFrom.DisplayMember = "Number";
				comboBoxFrom.ValueMember = "Id";
				comboBoxFrom.DataSource = listFrom;
				comboBoxFrom.SelectedItem = null;
			}
			formElement.AddControl(comboBoxFrom, true, "EducationalBuildingIdFrom");

			var labelTo = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelTo",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "В корпус : "
			};
			formElement.AddControl(labelTo, false);

			var comboBoxTo = new ComboBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				FormattingEnabled = true,
				Location = new System.Drawing.Point(136, 38),
				Name = "comboBoxEducationalBuildingTo",
				Size = new System.Drawing.Size(237, 24),
				TabIndex = 1,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			if (listFrom != null)
			{
				comboBoxTo.DisplayMember = "Number";
				comboBoxTo.ValueMember = "Id";
				comboBoxTo.DataSource = listFrom;
				comboBoxTo.SelectedItem = null;
			}
			formElement.AddControl(comboBoxTo, true, "EducationalBuildingIdTo");

			var labelTime = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 70),
				Name = "labelTime",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Время перехода : "
			};
			formElement.AddControl(labelTime, false);
			var maskedTextBoxTime = new MaskedTextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(136, 68),
				Mask = "00:00:00",
				Name = "maskedTextBoxTime",
				Size = new System.Drawing.Size(237, 22),
				TabIndex = 3,
				ValidatingType = typeof(System.DateTime)
			};
			formElement.AddControl(maskedTextBoxTime, true, "Time");

			formElement.Text = "Время перехода между корпусами";

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<TransitionTimeBindingModel, TransitionTimeViewModel>>();
			form.Form = formElement;
			form.Text = "Время переходов между корпусами";
			return form;
		}
	}
}