using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IRecordService
    {
        void SaveExcel(string FileName);

        void SaveHtmlTeachers(string SelectedPath, List<TeacherViewModel> teachers);

        void SaveHtmlStudyGroups(string SelectedPath, List<StudyGroupViewModel> studyGroups);
    }
}
