using ScheduleModel;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
    public class StudyGroupServiceDB : IStudyGroupService
    {
        private ScheduleDbContext context;

        public StudyGroupServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

        public List<StudyGroupViewModel> GetList()
        {
            List<StudyGroupViewModel> result = context.StudyGroups.Select
                (rec => new StudyGroupViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    Course = rec.Course,
                    NumderStudents = rec.NumderStudents,
                    NumderSubgroups = rec.NumderSubgroups,
                    SpecialtyTitle = rec.Specialty.Title,
                    TypeEducation = rec.TypeEducation,
                    FormEducation = rec.FormEducation
                }).OrderBy(reco => reco.Title)
                .ToList();

            return result;
        }

        public List<StudyGroupViewModel> GetListCourse()
        {
            List<StudyGroupViewModel> result = context.StudyGroups.Select
                (rec => new StudyGroupViewModel
                {
                    Course = rec.Course
                })
                .Distinct()
                .OrderBy(reco => reco.Course)
                .ToList();

            return result;
        }

        public List<StudyGroupViewModel> GetListByCourse(int Course)
        {
            List<StudyGroupViewModel> result = context.StudyGroups
                .Where(rec => rec.Course == Course)
                .Select
                (rec => new StudyGroupViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    Course = rec.Course,
                    NumderStudents = rec.NumderStudents,
                    NumderSubgroups = rec.NumderSubgroups,
                    SpecialtyTitle = rec.Specialty.Title,
                    TypeEducation = rec.TypeEducation,
                    FormEducation = rec.FormEducation
                }).OrderBy(reco => reco.Title)
                .ToList();

            return result;
        }

        public List<StudyGroupViewModel> GetListBySpecialty(Guid specialtyId)
        {
            List<StudyGroupViewModel> result = context.StudyGroups
                .Where(rec => rec.SpecialtyId == specialtyId)
                .Select
                (rec => new StudyGroupViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    Course = rec.Course,
                    NumderStudents = rec.NumderStudents,
                    NumderSubgroups = rec.NumderSubgroups,
                    SpecialtyTitle = rec.Specialty.Title,
                    TypeEducation = rec.TypeEducation,
                    FormEducation = rec.FormEducation
                }).OrderBy(reco => reco.Course).ThenBy(reco => reco.Title)
                .ToList();

            return result;
        }

        public StudyGroupViewModel GetElement(Guid id)
        {
            StudyGroup element = context.StudyGroups.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new StudyGroupViewModel
                {
                    Id = element.Id,
                    Title = element.Title,
                    Course = element.Course,
                    NumderStudents = element.NumderStudents,
                    NumderSubgroups = element.NumderSubgroups,

                    SpecialtyId = element.SpecialtyId,
                    SpecialtyTitle = context.Specialties
                    .Where(rec => rec.Id == element.SpecialtyId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TypeEducation = element.TypeEducation,//.ToString(),
                    FormEducation = element.FormEducation//.ToString()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public StudyGroupViewModel GetElementByTitle(string Title)
        {
            StudyGroup element = context.StudyGroups.Where(rec => rec.Title == Title).FirstOrDefault();

            if (element != null)
            {
                return new StudyGroupViewModel
                {
                    Id = element.Id,
                    Title = element.Title,
                    Course = element.Course,
                    NumderStudents = element.NumderStudents,
                    NumderSubgroups = element.NumderSubgroups,

                    SpecialtyId = element.SpecialtyId,
                    SpecialtyTitle = context.Specialties
                    .Where(rec => rec.Id == element.SpecialtyId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TypeEducation = element.TypeEducation,
                    FormEducation = element.FormEducation
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StudyGroupBindingModel model)
        {
            StudyGroup element = context.StudyGroups.FirstOrDefault
            (rec => rec.Title == model.Title);

            if (element != null)
            {
                throw new Exception("Уже есть такая группа");
            }

            context.StudyGroups.Add(new StudyGroup
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Course = model.Course,
                NumderStudents = model.NumderStudents,
                NumderSubgroups = model.NumderSubgroups,
                SpecialtyId = model.SpecialtyId,
                TypeEducation = model.TypeEducation,
                FormEducation = model.FormEducation
            });
            context.SaveChanges();
        }

        public void UpdElement(StudyGroupBindingModel model)
        {
            StudyGroup element = context.StudyGroups.FirstOrDefault
            (rec => rec.Title == model.Title && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть такая группа");
            }

            element = context.StudyGroups.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Title = model.Title;
            element.Course = model.Course;
            element.NumderStudents = model.NumderStudents;
            element.NumderSubgroups = model.NumderSubgroups;
            element.SpecialtyId = model.SpecialtyId;
            element.TypeEducation = model.TypeEducation;
            element.FormEducation = model.FormEducation;

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            StudyGroup element = context.StudyGroups.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.StudyGroups.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
