using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<ScheduleViewModel> result = context.Schedules
                .Select(rec => new ScheduleViewModel
                {
                    Id = rec.Id,
                    PeriodId = rec.PeriodId,
                    PeriodTitle = rec.Period.Title,
                    NumberWeeks = rec.NumberWeeks,
                    DayOfTheWeek = rec.DayOfTheWeek,
                    Type = rec.Type,
                    ClassTimeId = rec.ClassTimeId,
                    ClassTimeNumber = rec.ClassTime.Number,
                    StudyGroupId = rec.StudyGroupId,
                    StudyGroupTitle = rec.StudyGroup.Title,
                    Subgroups = rec.Subgroups,
                    AuditoriumId = rec.AuditoriumId,
                    AuditoriumNumber = rec.Auditorium.Number,
                    LoadTeacherId = rec.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname).FirstOrDefault(),

                }).ToList();

            return result;
        }

        //пары за период, по неделе расставленные
        public List<ScheduleViewModel> GetListByPeriodAndWeek(Guid PeriodId, int NumberWeek)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.NumberWeeks == NumberWeek && recS.DayOfTheWeek != null)
                .Select(rec => new ScheduleViewModel
                {
                    Id = rec.Id,
                    PeriodId = rec.PeriodId,
                    PeriodTitle = rec.Period.Title,
                    NumberWeeks = rec.NumberWeeks,
                    DayOfTheWeek = rec.DayOfTheWeek,
                    Type = rec.Type,
                    ClassTimeId = rec.ClassTimeId,
                    ClassTimeNumber = rec.ClassTime.Number,
                    StudyGroupId = rec.StudyGroupId,
                    StudyGroupTitle = rec.StudyGroup.Title,
                    Subgroups = rec.Subgroups,
                    AuditoriumId = rec.AuditoriumId,
                    AuditoriumNumber = rec.Auditorium.Number,
                    LoadTeacherId = rec.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherId = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Id).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname + " " + recT.Name.Substring(0, 1) + " " + recT.Patronymic.Substring(0, 1)).FirstOrDefault(),

                }).ToList();

            return result;
        }

        //пары за период, по неделе расставленные по группе и п/г
        public List<ScheduleViewModel> GetListByPeriodAndWeekAndStudyGroupSubgroup(Guid PeriodId, int NumberWeek, Guid StudyGroupId)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.NumberWeeks == NumberWeek && recS.StudyGroupId == StudyGroupId 
                 && recS.DayOfTheWeek != null)
                .Select(rec => new ScheduleViewModel
                {
                    Id = rec.Id,
                    PeriodId = rec.PeriodId,
                    PeriodTitle = rec.Period.Title,
                    NumberWeeks = rec.NumberWeeks,
                    DayOfTheWeek = rec.DayOfTheWeek,
                    Type = rec.Type,
                    ClassTimeId = rec.ClassTimeId,
                    ClassTimeNumber = rec.ClassTime.Number,
                    StudyGroupId = rec.StudyGroupId,
                    StudyGroupTitle = rec.StudyGroup.Title,
                    Subgroups = rec.Subgroups,
                    AuditoriumId = rec.AuditoriumId,
                    AuditoriumNumber = rec.Auditorium.Number,
                    LoadTeacherId = rec.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherId = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Id).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname + " " + recT.Name.Substring(0, 1) + " " + recT.Patronymic.Substring(0, 1)).FirstOrDefault(),

                }).ToList();

            return result;
        }

        //нераспределенные пары группы
        public List<ScheduleViewModel> GetListByPeroidAndStudyGroupEmpty(Guid PeriodId, Guid StudyGroupId)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.StudyGroupId == StudyGroupId && recS.DayOfTheWeek == null)
                .Select(rec => new ScheduleViewModel
                {
                    Id = rec.Id,
                    PeriodId = rec.PeriodId,
                    PeriodTitle = rec.Period.Title,
                    NumberWeeks = rec.NumberWeeks,
                    DayOfTheWeek = rec.DayOfTheWeek,
                    Type = rec.Type,
                    ClassTimeId = rec.ClassTimeId,
                    ClassTimeNumber = rec.ClassTime.Number,
                    StudyGroupId = rec.StudyGroupId,
                    StudyGroupTitle = rec.StudyGroup.Title,
                    Subgroups = rec.Subgroups,
                    AuditoriumId = rec.AuditoriumId,
                    AuditoriumNumber = rec.Auditorium.Number,
                    LoadTeacherId = rec.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle)
                    .FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname + " " + recT.Name.Substring(0, 1) + " " + recT.Patronymic.Substring(0, 1)).FirstOrDefault(),

                })
                .OrderBy(reco => reco.TypeOfClassTitle)
                .ToList();

            return result;
        }

        //распределенные пары группы
        public List<ScheduleViewModel> GetListByPeroidAndStudyGroupFill(Guid PeriodId, Guid StudyGroupId)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.StudyGroupId == StudyGroupId && recS.DayOfTheWeek != null)
                .Select(rec => new ScheduleViewModel
                {
                    Id = rec.Id,
                    PeriodId = rec.PeriodId,
                    PeriodTitle = rec.Period.Title,
                    NumberWeeks = rec.NumberWeeks,
                    DayOfTheWeek = rec.DayOfTheWeek,
                    Type = rec.Type,
                    ClassTimeId = rec.ClassTimeId,
                    ClassTimeNumber = rec.ClassTime.Number,
                    StudyGroupId = rec.StudyGroupId,
                    StudyGroupTitle = rec.StudyGroup.Title,
                    Subgroups = rec.Subgroups,
                    AuditoriumId = rec.AuditoriumId,
                    AuditoriumNumber = rec.Auditorium.Number,
                    LoadTeacherId = rec.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname + " " + recT.Name.Substring(0, 1) + " " + recT.Patronymic.Substring(0, 1)).FirstOrDefault(),

                }).ToList();

            return result;
        }

        //пары по расчасовке
        public List<ScheduleViewModel> GetListByLoadTeacher(Guid? LoadTeacherId)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.LoadTeacherId == LoadTeacherId)
                .Select(rec => new ScheduleViewModel
                {
                    Id = rec.Id,
                    PeriodId = rec.PeriodId,
                    PeriodTitle = rec.Period.Title,
                    NumberWeeks = rec.NumberWeeks,
                    DayOfTheWeek = rec.DayOfTheWeek,
                    Type = rec.Type,
                    ClassTimeId = rec.ClassTimeId,
                    ClassTimeNumber = rec.ClassTime.Number,
                    StudyGroupId = rec.StudyGroupId,
                    StudyGroupTitle = rec.StudyGroup.Title,
                    Subgroups = rec.Subgroups,
                    AuditoriumId = rec.AuditoriumId,
                    AuditoriumNumber = rec.Auditorium.Number,
                    LoadTeacherId = rec.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == rec.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname + " " + recT.Name.Substring(0, 1) + " " + recT.Patronymic.Substring(0, 1)).FirstOrDefault(),

                }).ToList();

            return result;
        }
        
        public ScheduleViewModel GetElementByParamEmpty(Guid PeriodId, int NumberWeeks, Guid StudyGroupId, int? Subgroups, Guid LoadTeacherId)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.PeriodId == PeriodId && rec.NumberWeeks == NumberWeeks
            && rec.StudyGroupId == StudyGroupId && rec.Subgroups == Subgroups && rec.LoadTeacherId == LoadTeacherId && rec.DayOfTheWeek == null);

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
                    Type = element.Type,

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

                    LoadTeacherId = element.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname).FirstOrDefault(),

                };
            }
            throw new Exception("Элемент не найден");
        }

        public ScheduleViewModel GetElementByParamFill(Guid PeriodId, int NumberWeeks, DayOfTheWeek? day, Guid? ClassTimeId, Guid StudyGroupId, int? Subgroups, Guid LoadTeacherId)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.PeriodId == PeriodId && rec.NumberWeeks == NumberWeeks
            && rec.DayOfTheWeek == day && rec.ClassTimeId == ClassTimeId && rec.StudyGroupId == StudyGroupId && rec.Subgroups == Subgroups
            && rec.LoadTeacherId == LoadTeacherId && rec.DayOfTheWeek != null);

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
                    Type = element.Type,

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

                    LoadTeacherId = element.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname).FirstOrDefault(),

                };
            }
            throw new Exception("Элемент не найден");
        }

        public ScheduleViewModel GetIdElementByDayAndClassTime(Guid PeriodId, int NumberWeeks, DayOfTheWeek day, Guid classtimeId, Guid StudyGroupId)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.PeriodId == PeriodId && rec.NumberWeeks == NumberWeeks
            && rec.DayOfTheWeek == day && rec.ClassTimeId == classtimeId && rec.StudyGroupId == StudyGroupId);

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
                    Type = element.Type,

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

                    LoadTeacherId = element.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname).FirstOrDefault(),
                };
            }
            throw new Exception("Элемент не найден");
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
                    Type = element.Type,

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

                    LoadTeacherId = element.LoadTeacherId,

                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.TypeOfClassId).FirstOrDefault())
                    .Select(recT => recT.AbbreviatedTitle).FirstOrDefault(),

                    DisciplineTitle = context.Disciplines
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.DisciplineId).FirstOrDefault())
                    .Select(recT => recT.Title).FirstOrDefault(),

                    TeacherSurname = context.Teachers
                    .Where(recT => recT.Id == context.LoadTeachers
                    .Where(recId => recId.Id == element.LoadTeacherId)
                    .Select(recId => recId.TeacherId).FirstOrDefault())
                    .Select(recT => recT.Surname).FirstOrDefault(),

                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(ScheduleBindingModel model)
        {
            //Schedule element = context.Schedules.FirstOrDefault
            //(rec => rec.PeriodId == model.PeriodId && rec.NumberWeeks == model.NumberWeeks
            //&& rec.DayOfTheWeek == model.DayOfTheWeek && rec.ClassTimeId == model.ClassTimeId
            //&& rec.StudyGroupId == model.StudyGroupId && rec.Subgroups == model.Subgroups);

            //if (element != null)
            //{
            //    throw new Exception("Уже есть пара в это время у этой подгруппы");
            //}

            context.Schedules.Add(new Schedule
            {
                Id = Guid.NewGuid(),
                PeriodId = model.PeriodId,
                NumberWeeks = model.NumberWeeks,
                DayOfTheWeek = model.DayOfTheWeek,
                Type = model.Type,
                ClassTimeId = model.ClassTimeId,
                StudyGroupId = model.StudyGroupId,
                Subgroups = model.Subgroups,
                AuditoriumId = model.AuditoriumId,
                LoadTeacherId = model.LoadTeacherId
            });
            context.SaveChanges();
        }

        public void UpdElement(ScheduleBindingModel model)
        {
            //Schedule element = context.Schedules.FirstOrDefault
            //(rec => rec.PeriodId == model.PeriodId && rec.NumberWeeks == model.NumberWeeks
            //&& rec.DayOfTheWeek == model.DayOfTheWeek && rec.ClassTimeId == model.ClassTimeId
            //&& rec.StudyGroupId == model.StudyGroupId && rec.Subgroups == model.Subgroups);

            ////if (element != null)
            ////{
            ////    throw new Exception("Уже есть пара в это время у этой подгруппы");
            ////}

            Schedule element = context.Schedules.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.PeriodId = model.PeriodId;
            element.NumberWeeks = model.NumberWeeks;
            element.DayOfTheWeek = model.DayOfTheWeek;
            element.ClassTimeId = model.ClassTimeId;
            element.Type = model.Type;
            element.StudyGroupId = model.StudyGroupId;
            element.Subgroups = model.Subgroups;
            element.AuditoriumId = model.AuditoriumId;
            element.LoadTeacherId = model.LoadTeacherId;

            context.SaveChanges();
        }

        public void DelElement(Guid Id)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.Id == Id);

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
