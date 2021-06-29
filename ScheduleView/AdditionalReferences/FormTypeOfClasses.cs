using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using ScheduleView.AdditionalReferences;
using System;
using System.Windows.Forms;

namespace ScheduleView
{
	public partial class FormTypeOfClasses : Form// : FormAdditionalReferenceList<TypeOfClassBindingModel, TypeOfClassViewModel>
    {
        public FormTypeOfClasses(IAdditionalReference<TypeOfClassBindingModel, TypeOfClassViewModel> service) //: base(service)
        {
            InitializeComponent();
        }

        //protected override Form GetForm(Guid? id)
        //{
        //    var form = DependencyManager.Instance.Resolve<FormTypeOfClass>();
        //    if (id.HasValue)
        //    {
        //        form.Id = id.Value;
        //    }

        //    return form;
        //}
	}
}