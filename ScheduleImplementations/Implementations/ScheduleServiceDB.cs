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
    public class ScheduleServiceDB : IScheduleService
    {
        private AbstractDbContext context;

        public ScheduleServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<ScheduleViewModel> GetList()
        {
            List<ScheduleViewModel> result = context.Schedules.Select
                (rec => new ScheduleViewModel
                {
                    Id = rec.Id,
                    PeriodTitle = rec.Period.Title,
                    NumberWeeks = rec.NumberWeeks,
                    DayOfTheWeek = rec.DayOfTheWeek,
                    ClassTimeNumber = rec.ClassTime.Number,
                    StudyGroupTitle = rec.StudyGroup.Title,
                    Subgroups = rec.Subgroups,
                    AuditoriumNumber = rec.Auditorium.Number,
                    TypeOfClassTitle = rec.TypeOfClass.Title,
                    DisciplineTitle = rec.Discipline.Title,
                    TeacherSurname = rec.Teacher.Surname,
                }).ToList();

            return result;
        }

        public ScheduleViewModel GetElement(Guid id)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new ScheduleViewModel
                {
                    Id = element.Id,
                    PeriodId = element.PeriodId,
                    PeriodTitle = context.Periods
                    .Where(rec => rec.Id == element.PeriodId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    NumberWeeks = element.NumberWeeks,
                    DayOfTheWeek = element.DayOfTheWeek,

                    ClassTimeId = element.ClassTimeId,
                    ClassTimeNumber = context.ClassTimes
                    .Where(rec => rec.Id == element.ClassTimeId)
                    .Select(rec => rec.Number).FirstOrDefault(),

                    StudyGroupId = element.StudyGroupId,
                    StudyGroupTitle = context.StudyGroups
                    .Where(rec => rec.Id == element.StudyGroupId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    Subgroups = element.Subgroups,

                    AuditoriumId = element.AuditoriumId,
                    AuditoriumNumber = context.Auditoriums
                    .Where(rec => rec.Id == element.AuditoriumId)
                    .Select(rec => rec.Number).FirstOrDefault(),

                    TypeOfClassId = element.TypeOfClassId,
                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(rec => rec.Id == element.TypeOfClassId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    DisciplineId = element.DisciplineId,
                    DisciplineTitle = context.Disciplines
                    .Where(rec => rec.Id == element.DisciplineId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TeacherId = element.TeacherId,
                    TeacherSurname = context.Teachers
                    .Where(rec => rec.Id == element.TeacherId)
                    .Select(rec => rec.Surname).FirstOrDefault(),
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(ScheduleBindingModel model)
        {
            Schedule element = context.Schedules.FirstOrDefault
            (rec => rec.PeriodId == model.PeriodId && rec.NumberWeeks == model.NumberWeeks 
            && rec.DayOfTheWeek == model.DayOfTheWeek && rec.ClassTimeId == model.ClassTimeId 
            && rec.StudyGroupId == model.StudyGroupId && rec.Subgroups == model.Subgroups);

            if (element != null)
            {
                throw new Exception("Уже есть пара в это время у этой подгруппы");
            }

            context.Schedules.Add(new Schedule
            {
                Id = Guid.NewGuid(),//???
                PeriodId = model.PeriodId,
                NumberWeeks = model.NumberWeeks,
                DayOfTheWeek = model.DayOfTheWeek,
                ClassTimeId = model.ClassTimeId,
                StudyGroupId = model.StudyGroupId,
                Subgroups = model.Subgroups,
                AuditoriumId = model.AuditoriumId,
                TypeOfClassId = model.TypeOfClassId,
                DisciplineId = model.DisciplineId,
                TeacherId = model.TeacherId
            });
            context.SaveChanges();
        }

        public void UpdElement(ScheduleBindingModel model)
        {
            Schedule element = context.Schedules.FirstOrDefault
            (rec => rec.PeriodId == model.PeriodId && rec.NumberWeeks == model.NumberWeeks
            && rec.DayOfTheWeek == model.DayOfTheWeek && rec.ClassTimeId == model.ClassTimeId
            && rec.StudyGroupId == model.StudyGroupId && rec.Subgroups == model.Subgroups);

            if (element != null)
            {
                throw new Exception("Уже есть пара в это время у этой подгруппы");
            }

            element = context.Schedules.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.PeriodId = model.PeriodId;
            element.NumberWeeks = model.NumberWeeks;
            element.DayOfTheWeek = model.DayOfTheWeek;
            element.ClassTimeId = model.ClassTimeId;
            element.StudyGroupId = model.StudyGroupId;
            element.Subgroups = model.Subgroups;
            element.AuditoriumId = model.AuditoriumId;
            element.TypeOfClassId = model.TypeOfClassId;
            element.DisciplineId = model.DisciplineId;
            element.TeacherId = model.TeacherId;

            context.SaveChanges();
        }

        public void DelElement(Guid id)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                context.Schedules.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
