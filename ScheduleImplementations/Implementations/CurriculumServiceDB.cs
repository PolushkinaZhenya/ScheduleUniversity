using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleImplementations.Implementations
{
    public class CurriculumServiceDB : ICurriculumService
    {
        private AbstractDbContext context;

        public CurriculumServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<CurriculumViewModel> GetList()
        {
            List<CurriculumViewModel> result = context.Curriculums.Select
                (rec => new CurriculumViewModel
                {
                    Id = rec.Id,
                    DisciplineTitle = rec.Discipline.Title,
                    StudyGroupTitle = rec.StudyGroup.Title,
                    TypeOfClassTitle = rec.TypeOfClass.Title,
                    SemesterTitle = rec.Semester.Title,
                    NumderOfHours = rec.NumderOfHours
                }).ToList();

            return result;
        }

        public CurriculumViewModel GetElement(Guid id)
        {
            Curriculum element = context.Curriculums.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new CurriculumViewModel
                {
                    Id = element.Id,

                    DisciplineId = element.DisciplineId,
                    DisciplineTitle = context.Disciplines
                    .Where(rec => rec.Id == element.DisciplineId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    StudyGroupId = element.StudyGroupId,
                    StudyGroupTitle = context.StudyGroups
                    .Where(rec => rec.Id == element.StudyGroupId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TypeOfClassId = element.TypeOfClassId,
                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(rec => rec.Id == element.TypeOfClassId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    SemesterId = element.SemesterId,
                    SemesterTitle = context.Semesters
                    .Where(rec => rec.Id == element.SemesterId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    NumderOfHours = element.NumderOfHours
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CurriculumBindingModel model)
        {
            Curriculum element = context.Curriculums.FirstOrDefault
            (rec => rec.DisciplineId == model.DisciplineId && rec.StudyGroupId == model.StudyGroupId 
            && rec.TypeOfClassId == model.TypeOfClassId && rec.SemesterId == model.SemesterId);

            if (element != null)
            {
                throw new Exception("Уже есть учебный план на эту дисциплину для этой группы");
            }

            context.Curriculums.Add(new Curriculum
            {
                Id = Guid.NewGuid(),//???
                DisciplineId = model.DisciplineId,
                StudyGroupId = model.StudyGroupId,
                TypeOfClassId = model.TypeOfClassId,
                SemesterId = model.SemesterId,
                NumderOfHours = model.NumderOfHours
            });
            context.SaveChanges();
        }

        public void UpdElement(CurriculumBindingModel model)
        {
            Curriculum element = context.Curriculums.FirstOrDefault
            (rec => rec.DisciplineId == model.DisciplineId && rec.StudyGroupId == model.StudyGroupId
            && rec.TypeOfClassId == model.TypeOfClassId && rec.SemesterId == model.SemesterId && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть учебный план на эту дисциплину для этой группы");
            }

            element = context.Curriculums.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.DisciplineId = model.DisciplineId;
            element.StudyGroupId = model.StudyGroupId;
            element.TypeOfClassId = model.TypeOfClassId;
            element.SemesterId = model.SemesterId;
            element.NumderOfHours = model.NumderOfHours;

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            Curriculum element = context.Curriculums.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Curriculums.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
