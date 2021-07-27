using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
{
	public interface IExportService
    {
        void SaveExcel(string FileName, List<StudyGroupViewModel> studyGroups);

        void SaveHtmlTeachers(HtmlTeachersBindingModel model);

        void SaveHtmlStudyGroups(HtmlStudyGroupsBindingModel model);

        void SaveHtmlAuditoriums(HtmlAuditoriumsBindingModel model);
    }
}