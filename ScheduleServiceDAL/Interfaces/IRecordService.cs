using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
    public interface IRecordService
    {
        void SaveExcel(string FileName, List<StudyGroupViewModel> studyGroups);

        void SaveHtmlTeachers(string SelectedPath, List<TeacherViewModel> teachers);

        void SaveHtmlStudyGroups(string SelectedPath, List<StudyGroupViewModel> studyGroupsTitle);
    }
}
