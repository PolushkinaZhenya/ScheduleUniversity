using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces.AdditionalReferences;
using ScheduleServiceDAL.ViewModels;
using ScheduleView.AdditionalReferences;
using System;
using System.Windows.Forms;

namespace ScheduleView
{
	public partial class FormTypeOfDepartments : FormAdditionalReferenceList<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>
	{
		public FormTypeOfDepartments(IAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel> service) : base(service)
		{
			InitializeComponent();
		}

		protected override void ConfigGrid()
		{
			base.ConfigGrid();
			dataGridView.Columns[1].Visible = false;
			dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		protected override Form GetForm(Guid? id)
		{
			var form = DependencyManager.Instance.Resolve<FormTypeOfDepartment>();
			if (id.HasValue)
			{
				form.Id = id.Value;
			}

			return form;
		}
	}
}