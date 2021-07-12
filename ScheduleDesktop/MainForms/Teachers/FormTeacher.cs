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
        private Guid? _id;

        public Guid Id { set { _id = value; } }

        private readonly IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel> _service;

        private readonly Lazy<List<DepartmentViewModel>> _departments;

        private List<Guid> _selectedDepartmens;

        private bool _isLoad = false;

        public FormTeacher(IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel> service, 
            IBaseService<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel> serviceD)
        {
            InitializeComponent();
            _service = service;
            _selectedDepartmens = new List<Guid>();
            _departments = new Lazy<List<DepartmentViewModel>>(() => { return serviceD.GetList(); });
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            if (_departments.Value == null)
			{
                Program.ShowError("Список кафедр не получен", "Ошибка загрузки");
			}
            else
			{
                checkedListBoxDepartments.Items.Clear();
                checkedListBoxDepartments.Items.AddRange(_departments.Value.Select(x => x.Title).ToArray());
			}

            if (_id.HasValue)
            {
                try
                {
                    TeacherViewModel view = _service.GetElement(new TeacherSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxShortName.Text = view.ShortName;
                        textBoxSurname.Text = view.Surname;
                        textBoxName.Text = view.Name;
                        textBoxPatronymic.Text = view.Patronymic;
                        _selectedDepartmens = view.TeacherDepartments;

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
            _isLoad = true;
            if (_selectedDepartmens != null)
            {
                foreach (var td in _selectedDepartmens)
                {
                    var dep = _departments.Value?.FirstOrDefault(x => x.Id == td);
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
            _isLoad = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text.IsEmpty() || textBoxName.Text.IsEmpty()  || textBoxPatronymic.Text.IsEmpty() || textBoxShortName.Text.IsEmpty() ||
                _selectedDepartmens.Count == 0)
            {
                Program.ShowError("Заполните все данные и выберете кафедры", "Ошибка");
                return;
            }
            try
            {
                if (_id.HasValue)
                {
                    _service.UpdElement(new TeacherBindingModel
                    {
                        Id = _id.Value,
                        ShortName = textBoxShortName.Text,
                        Surname = textBoxSurname.Text,
                        Name = textBoxName.Text,
                        Patronymic = textBoxPatronymic.Text,
                        TeacherDepartments = _selectedDepartmens
                    });
                }
                else
                {
                    _service.AddElement(new TeacherBindingModel
                    {
                        ShortName = textBoxShortName.Text,
                        Surname = textBoxSurname.Text,
                        Name = textBoxName.Text,
                        Patronymic = textBoxPatronymic.Text,
                        TeacherDepartments = _selectedDepartmens
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
                if (_departments.Value == null)
                {
                    Program.ShowError("Список кафедр не получен", "Ошибка загрузки");
                    return;
                }
                else
                {
                    var selected = _departments.Value.Where(x => x.Title.Contains(textBoxSearchDepartment.Text));
                    checkedListBoxDepartments.Items.Clear();
                    checkedListBoxDepartments.Items.AddRange(selected.Select(x => x.Title).ToArray());

                    MarkSeleted();
                }
            }
		}

		private void CheckedListBoxDepartments_ItemCheck(object sender, ItemCheckEventArgs e)
		{
            if (_isLoad)
			{
                return;
			}
            var dep = _departments.Value?.FirstOrDefault(x => x.Title == checkedListBoxDepartments.Items[e.Index].ToString());
            if (dep != null)
			{
                if (e.NewValue == CheckState.Checked && !_selectedDepartmens.Contains(dep.Id))
				{
                    _selectedDepartmens.Add(dep.Id);
				}
                else if (e.NewValue == CheckState.Unchecked && _selectedDepartmens.Contains(dep.Id))
				{
                    _selectedDepartmens.Remove(dep.Id);
				}
			}
        }

		private void TextBox_TextChanged(object sender, EventArgs e)
		{
            if (!_id.HasValue)
			{
                textBoxShortName.Text = $"{textBoxSurname.Text} {(textBoxName.Text.IsEmpty() ? "" : textBoxName.Text?[0])}.{(textBoxPatronymic.Text.IsEmpty() ? "" : textBoxPatronymic.Text?[0])}.";
			}
		}
	}
}