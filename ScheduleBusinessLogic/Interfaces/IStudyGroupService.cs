using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
{
	public interface IStudyGroupService
    {
        List<StudyGroupViewModel> GetList();

        List<StudyGroupViewModel> GetListByCourse(int Course);

        List<StudyGroupViewModel> GetListCourse();

        List<StudyGroupViewModel> GetListByFaculty(Guid facultyId);

        List<StudyGroupViewModel> GetListBySpecialty(Guid specialtyId);

        List<SpecialtyViewModel> GetSpecialtyByFaculty(Guid? facultyId);

        StudyGroupViewModel GetElement(Guid id);

        StudyGroupViewModel GetElementByTitle(string Title);

        void AddElement(StudyGroupBindingModel model);

        void UpdElement(StudyGroupBindingModel model);

        void DelElement(Guid id);
    }
}