using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormTeacher : Form
    {
        public Guid Id { set { id = value; } }

        private readonly ITeacherService service;

        private readonly IBaseService<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel> serviceD;

        private Guid? id;

        private List<DepartmentViewModel> departments;

        private List<Guid> selectedDepartmens;

        private bool isLoad = false;

        public FormTeacher(ITeacherService service, IBaseService<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel> serviceD)
        {
            InitializeComponent();
            this.service = service;
            this.serviceD = serviceD;
            selectedDepartmens = new List<Guid>();
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            departments = serviceD.GetList();
            if (departments == null)
			{
                Program.ShowError("Список кафедр не получен", "Ошибка загрузки");
			}
            else
			{
                checkedListBoxDepartments.Items.Clear();
                checkedListBoxDepartments.Items.AddRange(departments.Select(x => x.Title).ToArray());
			}

            if (id.HasValue)
            {
                try
                {
                    TeacherViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxSurname.Text = view.Surname;
                        textBoxName.Text = view.Name;
                        textBoxPatronymic.Text = view.Patronymic;
                        selectedDepartmens = view.TeacherDepartments;

                        MarkSeleted();
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowError(ex, "Ошибка");
                }
            }
        }

        private void MarkSeleted()
		{
            isLoad = true;
            if (selectedDepartmens != null)
            {
                foreach (var td in selectedDepartmens)
                {
                    var dep = departments?.FirstOrDefault(x => x.Id == td);
                    if (dep != null)
                    {
                        var item = checkedListBoxDepartments.Items.IndexOf(dep.Title);
                        if (item > -1)
                        {
                            checkedListBoxDepartments.SetItemChecked(item, true);
                        }
                    }
                }
            }
            isLoad = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSurname.Text) || string.IsNullOrEmpty(textBoxName.Text) 
                || string.IsNullOrEmpty(textBoxPatronymic.Text) || selectedDepartmens.Count == 0)
            {
                Program.ShowError("Заполните все данные и выберете кафедры", "Ошибка");
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new TeacherBindingModel
                    {
                        Id = id.Value,
                        Surname = textBoxSurname.Text,
                        Name = textBoxName.Text,
                        Patronymic = textBoxPatronymic.Text,
                        TeacherDepartments = selectedDepartmens
                    });
                }
                else
                {
                    service.AddElement(new TeacherBindingModel
                    {
                        Surname = textBoxSurname.Text,
                        Name = textBoxName.Text,
                        Patronymic = textBoxPatronymic.Text,
                        TeacherDepartments = selectedDepartmens
                    });
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

		private void TextBoxSearchDepartment_TextChanged(object sender, EventArgs e)
		{
            if (textBoxSearchDepartment.Text.Length > 2)
			{
                if (departments == null)
                {
                    departments = serviceD.GetList();
                    if (departments == null)
                    {
                        Program.ShowError("Список кафедр не получен", "Ошибка загрузки");
                        return;
                    }
                }
                else
                {
                    var selected = departments.Where(x => x.Title.Contains(textBoxSearchDepartment.Text));
                    checkedListBoxDepartments.Items.Clear();
                    checkedListBoxDepartments.Items.AddRange(selected.Select(x => x.Title).ToArray());

                    MarkSeleted();
                }
            }
		}

		private void CheckedListBoxDepartments_ItemCheck(object sender, ItemCheckEventArgs e)
		{
            if (isLoad)
			{
                return;
			}
            var dep = departments?.FirstOrDefault(x => x.Title == checkedListBoxDepartments.Items[e.Index].ToString());
            if (dep != null)
			{
                if (e.NewValue == CheckState.Checked && !selectedDepartmens.Contains(dep.Id))
				{
                    selectedDepartmens.Add(dep.Id);
				}
                else if (e.NewValue == CheckState.Unchecked && selectedDepartmens.Contains(dep.Id))
				{
                    selectedDepartmens.Remove(dep.Id);
				}
			}
        }
	}
}