using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using ScheduleView.AdditionalReferences;
using System;
using System.Windows.Forms;

namespace ScheduleView
{
	public partial class FormTypeOfDepartments : Form// : FormAdditionalReferenceList<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel>
	{
		public FormTypeOfDepartments(IAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel> service) //: base(service)
		{
			InitializeComponent();
		}

		//protected override Form GetForm(Guid? id)
		//{
		//	var form = DependencyManager.Instance.Resolve<FormTypeOfDepartment>();
		//	if (id.HasValue)
		//	{
		//		form.Id = id.Value;
		//	}

		//	return form;
		//}
	}
}