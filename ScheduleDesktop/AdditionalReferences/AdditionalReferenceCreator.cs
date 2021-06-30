﻿using ScheduleBusinessLogic.BindingModels;
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
			formElement.Text = "Тип аудитории";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Тип:"
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
			formElement.Text = "Тип кафедры";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Тип:"
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
			formElement.Text = "Тип занятия";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Тип:"
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

			var shortlabel = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Сокращенное название:"
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
			formElement.Text = "Учебный корпус";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Номер:"
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(80, 8),
				Name = "textBoxType",
				Size = new System.Drawing.Size(200, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Number");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<EducationalBuildingBindingModel, EducationalBuildingViewModel>>();
			form.Form = formElement;
			form.Text = "Учебные корпуса";
			return form;
		}

		public static Form GetTransitionTimeForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<TransitionTimeBindingModel, TransitionTimeViewModel>>();
			formElement.Width = 300;
			formElement.Height = 200;
			formElement.Text = "Время перехода между корпусами";

			var educationalBuilding = DependencyManager.Instance.Resolve<IAdditionalReference<EducationalBuildingBindingModel, EducationalBuildingViewModel>>();
			
			var labelFrom = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelFrom",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Из корпуса:"
			};
			formElement.AddControl(labelFrom, false);

			var comboBoxFrom = new ComboBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				FormattingEnabled = true,
				Location = new System.Drawing.Point(120, 8),
				Name = "comboBoxEducationalBuildingFrom",
				Size = new System.Drawing.Size(160, 24),
				TabIndex = 1,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			var listFrom = educationalBuilding.GetList();
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
				Text = "В корпус:"
			};
			formElement.AddControl(labelTo, false);

			var comboBoxTo = new ComboBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				FormattingEnabled = true,
				Location = new System.Drawing.Point(120, 38),
				Name = "comboBoxEducationalBuildingTo",
				Size = new System.Drawing.Size(160, 24),
				TabIndex = 1,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			var listTo = educationalBuilding.GetList();
			if (listTo != null)
			{
				comboBoxTo.DisplayMember = "Number";
				comboBoxTo.ValueMember = "Id";
				comboBoxTo.DataSource = listTo;
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
				Text = "Время перехода:"
			};
			formElement.AddControl(labelTime, false);
			var maskedTextBoxTime = new MaskedTextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(120, 68),
				Mask = "00:00:00",
				Name = "maskedTextBoxTime",
				Size = new System.Drawing.Size(160, 22),
				TabIndex = 3,
				ValidatingType = typeof(System.DateTime)
			};
			formElement.AddControl(maskedTextBoxTime, true, "Time");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<TransitionTimeBindingModel, TransitionTimeViewModel>>();
			form.Form = formElement;
			form.Text = "Время переходов между корпусами";
			return form;
		}

		public static Form GetClassTimeForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<ClassTimeBindingModel, ClassTimeViewModel>>();
			formElement.Width = 300;
			formElement.Height = 200;
			formElement.Text = "Время проведения пары";

			var labelNumber = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelFrom",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Номер пары:"
			};
			formElement.AddControl(labelNumber, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(130, 8),
				Name = "textBoxNumber",
				Size = new System.Drawing.Size(150, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Number");

			var labelBegin = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelBegin",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Время начала:"
			};
			formElement.AddControl(labelBegin, false);

			var maskedTextBoxBegin = new MaskedTextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(130, 38),
				Mask = "00:00",
				Name = "maskedTextBoxBegin",
				Size = new System.Drawing.Size(150, 22),
				TabIndex = 3,
				ValidatingType = typeof(System.DateTime)
			};
			formElement.AddControl(maskedTextBoxBegin, true, "StartTime");

			var labelEnd = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 70),
				Name = "labelTime",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Время окончания:"
			};
			formElement.AddControl(labelEnd, false);
			var maskedTextBoxEnd = new MaskedTextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(130, 68),
				Mask = "00:00",
				Name = "maskedTextBoxEnd",
				Size = new System.Drawing.Size(150, 22),
				TabIndex = 3,
				ValidatingType = typeof(System.DateTime)
			};
			formElement.AddControl(maskedTextBoxEnd, true, "EndTime");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<ClassTimeBindingModel, ClassTimeViewModel>>();
			form.Form = formElement;
			form.Text = "Время проведения пар";
			return form;
		}

		public static Form GetAcademicYearForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<AcademicYearBindingModel, AcademicYearViewModel>>();
			formElement.Width = 300;
			formElement.Height = 130;
			formElement.Text = "Учебный год";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Учебный год:"
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 8),
				Name = "textBoxTitle",
				Size = new System.Drawing.Size(170, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<AcademicYearBindingModel, AcademicYearViewModel>>();
			form.Form = formElement;
			form.Text = "Учебные года";
			return form;
		}

		public static Form GetSemesterForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<SemesterBindingModel, SemesterViewModel>>();
			formElement.Width = 300;
			formElement.Height = 160;
			formElement.Text = "Семестр";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Семестр:"
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 8),
				Name = "textBoxTitle",
				Size = new System.Drawing.Size(170, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");

			var academicYear = DependencyManager.Instance.Resolve<IAdditionalReference<AcademicYearBindingModel, AcademicYearViewModel>>();

			var labelAcademicYear = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelAcademicYear",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Учебный год:"
			};
			formElement.AddControl(labelAcademicYear, false);

			var comboBoxAcademicYear = new ComboBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				FormattingEnabled = true,
				Location = new System.Drawing.Point(110, 38),
				Name = "comboBoxAcademicYear",
				Size = new System.Drawing.Size(170, 24),
				TabIndex = 1,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			var listTo = academicYear.GetList();
			if (listTo != null)
			{
				comboBoxAcademicYear.DisplayMember = "Title";
				comboBoxAcademicYear.ValueMember = "Id";
				comboBoxAcademicYear.DataSource = listTo;
				comboBoxAcademicYear.SelectedItem = null;
			}
			formElement.AddControl(comboBoxAcademicYear, true, "AcademicYearId");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<SemesterBindingModel, SemesterViewModel>>();
			form.Form = formElement;
			form.Text = "Семестры";
			return form;
		}

		public static Form GetPeriodForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<PeriodBindingModel, PeriodViewModel>>();
			formElement.Width = 300;
			formElement.Height = 220;
			formElement.Text = "Период";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Период:"
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 8),
				Name = "textBoxTitle",
				Size = new System.Drawing.Size(170, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");

			var labelBegin = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelBegin",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Начало:"
			};
			formElement.AddControl(labelBegin, false);

			var dateTimePickerStartDate = new DateTimePicker
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 38),
				Name = "dateTimePickerStartDate",
				Size = new System.Drawing.Size(170, 22),
				TabIndex = 3
			};
			formElement.AddControl(dateTimePickerStartDate, true, "StartDate");

			var labelEnd = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 70),
				Name = "labelBegin",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Конец:"
			};
			formElement.AddControl(labelEnd, false);

			var dateTimePickerEndDate = new DateTimePicker
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 68),
				Name = "dateTimePickerEndDate",
				Size = new System.Drawing.Size(170, 22),
				TabIndex = 3
			};
			formElement.AddControl(dateTimePickerEndDate, true, "EndDate");

			var semester = DependencyManager.Instance.Resolve<IAdditionalReference<SemesterBindingModel, SemesterViewModel>>();

			var labelSemester = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 100),
				Name = "labelSemester",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Семестр:"
			};
			formElement.AddControl(labelSemester, false);

			var comboBoxSemester = new ComboBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				FormattingEnabled = true,
				Location = new System.Drawing.Point(110, 98),
				Name = "comboBoxSemester",
				Size = new System.Drawing.Size(170, 24),
				TabIndex = 1,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			var listTo = semester.GetList();
			if (listTo != null)
			{
				comboBoxSemester.DisplayMember = "Title";
				comboBoxSemester.ValueMember = "Id";
				comboBoxSemester.DataSource = listTo;
				comboBoxSemester.SelectedItem = null;
			}
			formElement.AddControl(comboBoxSemester, true, "SemesterId");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<PeriodBindingModel, PeriodViewModel>>();
			form.Form = formElement;
			form.Text = "Периоды";
			return form;
		}

		public static Form GetDepartmentForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<DepartmentBindingModel, DepartmentViewModel>>();
			formElement.Width = 300;
			formElement.Height = 160;
			formElement.Text = "Кафедра";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Название:"
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 8),
				Name = "textBoxTitle",
				Size = new System.Drawing.Size(170, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");

			var typeOfDepartment = DependencyManager.Instance.Resolve<IAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>>();

			var labelTypeOfDepartment = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelTypeOfDepartment",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Тип:"
			};
			formElement.AddControl(labelTypeOfDepartment, false);

			var comboBoxTypeOfDepartment = new ComboBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				FormattingEnabled = true,
				Location = new System.Drawing.Point(110, 38),
				Name = "comboBoxTypeOfDepartment",
				Size = new System.Drawing.Size(170, 24),
				TabIndex = 1,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			var listTo = typeOfDepartment.GetList();
			if (listTo != null)
			{
				comboBoxTypeOfDepartment.DisplayMember = "Title";
				comboBoxTypeOfDepartment.ValueMember = "Id";
				comboBoxTypeOfDepartment.DataSource = listTo;
				comboBoxTypeOfDepartment.SelectedItem = null;
			}
			formElement.AddControl(comboBoxTypeOfDepartment, true, "TypeOfDepartmentId");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<DepartmentBindingModel, DepartmentViewModel>>();
			form.Form = formElement;
			form.Text = "Кафедры";
			return form;
		}

		public static Form GetDisciplineForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<DisciplineBindingModel, DisciplineViewModel>>();
			formElement.Width = 400;
			formElement.Height = 160;
			formElement.Text = "Дисциплина";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Название:"
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(80, 8),
				Name = "textBoxType",
				Size = new System.Drawing.Size(300, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");

			var labeAbbreviatedTitle = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelAbbreviatedTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Сокращение:"
			};
			formElement.AddControl(labeAbbreviatedTitle, false);

			var textboxAbbreviatedTitle = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(170, 38),
				Name = "textBoxAbbreviatedTitle",
				Size = new System.Drawing.Size(210, 10),
				TabIndex = 1
			};
			formElement.AddControl(textboxAbbreviatedTitle, true, "AbbreviatedTitle");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<DisciplineBindingModel, DisciplineViewModel>>();
			form.Form = formElement;
			form.Text = "Дисциплины";
			return form;
		}

		public static Form GetFacultyForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<FacultyBindingModel, FacultyViewModel>>();
			formElement.Width = 400;
			formElement.Height = 130;
			formElement.Text = "Факультет";

			var label = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Название:"
			};
			formElement.AddControl(label, false);

			var textbox = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(80, 8),
				Name = "textBoxTitle",
				Size = new System.Drawing.Size(300, 10),
				TabIndex = 1
			};
			formElement.AddControl(textbox, true, "Title");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<FacultyBindingModel, FacultyViewModel>>();
			form.Form = formElement;
			form.Text = "Факультеты";
			return form;
		}

		public static Form GetSpecialtyForm()
		{
			var formElement = DependencyManager.Instance.Resolve<FormAdditionalReference<SpecialtyBindingModel, SpecialtyViewModel>>();
			formElement.Width = 300;
			formElement.Height = 220;
			formElement.Text = "Специальность";

			var labelCode = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 10),
				Name = "labelCode",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Код:"
			};
			formElement.AddControl(labelCode, false);

			var textboxCode = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 8),
				Name = "textBoxCode",
				Size = new System.Drawing.Size(170, 10),
				TabIndex = 1
			};
			formElement.AddControl(textboxCode, true, "Code");

			var labelTitle = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 40),
				Name = "labelTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Название:"
			};
			formElement.AddControl(labelTitle, false);

			var textboxTitle = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 38),
				Name = "textboxTitle",
				Size = new System.Drawing.Size(170, 10),
				TabIndex = 1
			};
			formElement.AddControl(textboxTitle, true, "Title");

			var labelAbbreviatedTitle = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 70),
				Name = "labelAbbreviatedTitle",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Сокращенное:"
			};
			formElement.AddControl(labelAbbreviatedTitle, false);

			var textboxAbbreviatedTitle = new TextBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				Location = new System.Drawing.Point(110, 68),
				Name = "textboxAbbreviatedTitle",
				Size = new System.Drawing.Size(170, 10),
				TabIndex = 1
			};
			formElement.AddControl(textboxAbbreviatedTitle, true, "AbbreviatedTitle");

			var faculty = DependencyManager.Instance.Resolve<IAdditionalReference<FacultyBindingModel, FacultyViewModel>>();

			var labelFaculty = new Label
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				AutoSize = true,
				Location = new System.Drawing.Point(10, 100),
				Name = "labelFaculty",
				Size = new System.Drawing.Size(45, 17),
				TabIndex = 0,
				Text = "Факультет:"
			};
			formElement.AddControl(labelFaculty, false);

			var comboBoxFaculty = new ComboBox
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
				FormattingEnabled = true,
				Location = new System.Drawing.Point(110, 98),
				Name = "comboBoxFaculty",
				Size = new System.Drawing.Size(170, 24),
				TabIndex = 1,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			var listTo = faculty.GetList();
			if (listTo != null)
			{
				comboBoxFaculty.DisplayMember = "Title";
				comboBoxFaculty.ValueMember = "Id";
				comboBoxFaculty.DataSource = listTo;
				comboBoxFaculty.SelectedItem = null;
			}
			formElement.AddControl(comboBoxFaculty, true, "FacultyId");

			var form = DependencyManager.Instance.Resolve<FormAdditionalReferenceList<SpecialtyBindingModel, SpecialtyViewModel>>();
			form.Form = formElement;
			form.Text = "Специальности";
			return form;
		}
	}
}