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
        private ScheduleDbContext context;

        public ScheduleServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

        //пары за период, по неделе расставленные
        public List<ScheduleViewModel> GetListByPeriodAndWeek(Guid PeriodId, int NumberWeek, string Type)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.NumberWeeks == NumberWeek && recS.DayOfTheWeek != null && recS.Type == Type)
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

                    TeacherId = rec.TeacherId,

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

        //пары за период, по неделе расставленные по группе и п/г
        public List<ScheduleViewModel> GetListByPeriodAndWeekAndStudyGroupSubgroup(Guid PeriodId, int NumberWeek, Guid StudyGroupId, string Type)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.NumberWeeks == NumberWeek && recS.StudyGroupId == StudyGroupId
                 && recS.DayOfTheWeek != null && recS.Type == Type)
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

                    TeacherId = rec.TeacherId,

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

        //нераспределенные пары группы
        public List<ScheduleViewModel> GetListByPeroidAndStudyGroupEmpty(Guid PeriodId, Guid StudyGroupId, string Type)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.StudyGroupId == StudyGroupId && recS.DayOfTheWeek == null && recS.Type == Type)
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

                    TeacherId = rec.TeacherId,

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
                .OrderBy(reco => reco.NumberWeeks)
                .ThenBy(reco => reco.TypeOfClassTitle)
                .ToList();

            return result;
        }

        //распределенные пары группы
        public List<ScheduleViewModel> GetListByPeroidAndStudyGroupFill(Guid PeriodId, Guid StudyGroupId, string Type)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.StudyGroupId == StudyGroupId && recS.DayOfTheWeek != null && recS.Type == Type)
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

                    TeacherId = rec.TeacherId,

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

                }).OrderBy(u => u.NumberWeeks).ThenBy(u => u.DayOfTheWeek).ThenBy(u => u.ClassTimeNumber)
                .ToList();

            return result;
        }

        //"закрытые" пары аудитории
        public List<ScheduleViewModel> GetListByPeroidAndAuditoriumClose(Guid PeriodId, Guid AuditoriumId, string Type)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.AuditoriumId == AuditoriumId && recS.Type == Type)
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

                    TeacherId = rec.TeacherId,

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

        //распределенные пары аудитории
        public List<ScheduleViewModel> GetListByPeroidAndAuditoriumFill(Guid PeriodId, Guid AuditoriumId, string Type)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.AuditoriumId == AuditoriumId && recS.DayOfTheWeek != null && recS.Type == Type)
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
                    TeacherId = rec.TeacherId,

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

        //"закрытые" пары преподавателя
        public List<ScheduleViewModel> GetListByPeroidAndTeacherClose(Guid PeriodId, Guid TeacherId, string Type)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.TeacherId == TeacherId && recS.Type == Type)
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

                    TeacherId = rec.TeacherId,

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

        //распределенные пары преподавателя
        public List<ScheduleViewModel> GetListByPeroidAndTeacherFill(Guid PeriodId, Guid TeacherId, string Type)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.PeriodId == PeriodId && recS.DayOfTheWeek != null && recS.LoadTeacher.TeacherId == TeacherId && recS.Type == Type)
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

                    TeacherId = rec.TeacherId,

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

                }).OrderBy(u => u.NumberWeeks).ThenBy(u => u.DayOfTheWeek).ThenBy(u => u.ClassTimeNumber)
                .ToList();
            return result;
        }

        //пары по расчасовке и периоду
        public List<ScheduleViewModel> GetListByLoadTeacher(Guid? LoadTeacherId, string Type, Guid PeriodId)
        {
            List<ScheduleViewModel> result = context.Schedules
                .Where(recS => recS.LoadTeacherId == LoadTeacherId && recS.Type == Type && recS.PeriodId == PeriodId)
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
                    TeacherId = rec.TeacherId,

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

        public ScheduleViewModel GetElementByParamEmpty(Guid PeriodId, int NumberWeeks, Guid StudyGroupId, int? Subgroups, Guid? LoadTeacherId, string Type)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.PeriodId == PeriodId && rec.NumberWeeks == NumberWeeks
            && rec.StudyGroupId == StudyGroupId && rec.Subgroups == Subgroups && rec.LoadTeacherId == LoadTeacherId && rec.DayOfTheWeek == null && rec.Type == Type);

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

                    TeacherId = element.TeacherId,

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

        public ScheduleViewModel GetElementByParamFill(Guid PeriodId, int NumberWeeks, DayOfTheWeek? day, Guid? ClassTimeId, Guid StudyGroupId, int? Subgroups, Guid? LoadTeacherId, string Type)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.PeriodId == PeriodId && rec.NumberWeeks == NumberWeeks
            && rec.DayOfTheWeek == day && rec.ClassTimeId == ClassTimeId && rec.StudyGroupId == StudyGroupId && rec.Subgroups == Subgroups
            && rec.LoadTeacherId == LoadTeacherId && rec.DayOfTheWeek != null && rec.Type == Type);

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

                    TeacherId = element.TeacherId,

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

        //пара группы по таблице расписания
        public ScheduleViewModel GetElementByDayAndClassTimeAndStudyGroupId(Guid PeriodId, int NumberWeeks, DayOfTheWeek day, Guid classtimeId, Guid StudyGroupId, string Type)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.PeriodId == PeriodId && rec.NumberWeeks == NumberWeeks
            && rec.DayOfTheWeek == day && rec.ClassTimeId == classtimeId && rec.StudyGroupId == StudyGroupId && rec.Type == Type);

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

                    TeacherId = element.TeacherId,

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

        //пара аудитории по таблице расписания
        public ScheduleViewModel GetElementByDayAndClassTimeAndAuditoriumId(Guid PeriodId, int NumberWeeks, DayOfTheWeek day, Guid classtimeId, Guid AuditoriumId, string Type)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.PeriodId == PeriodId && rec.NumberWeeks == NumberWeeks
            && rec.DayOfTheWeek == day && rec.ClassTimeId == classtimeId && rec.AuditoriumId == AuditoriumId && rec.Type == Type);

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

                    TeacherId = element.TeacherId,

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

        //пара преподавателя по таблице расписания
        public ScheduleViewModel GetElementByDayAndClassTimeAndTeacherId(Guid PeriodId, int NumberWeeks, DayOfTheWeek day, Guid classtimeId, Guid TeacherId, string Type)
        {
            Schedule element = context.Schedules.FirstOrDefault(rec => rec.PeriodId == PeriodId && rec.NumberWeeks == NumberWeeks
            && rec.DayOfTheWeek == day && rec.ClassTimeId == classtimeId && rec.TeacherId == TeacherId && rec.Type == Type);

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

                    TeacherId = element.TeacherId,

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

                    TeacherId = element.TeacherId,

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
                LoadTeacherId = model.LoadTeacherId,
                TeacherId = model.TeacherId
            });
            context.SaveChanges();
        }

        public void UpdElement(ScheduleBindingModel model)
        {
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
            element.TeacherId = model.TeacherId;

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
