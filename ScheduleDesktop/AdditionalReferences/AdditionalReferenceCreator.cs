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
	}
}