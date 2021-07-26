﻿using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class ScheduleServiceDB : AbstractServiceDB<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel, Schedule>,
        IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel>
    {
        public ScheduleServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

        protected override IQueryable<Schedule> Ordering(IQueryable<Schedule> query) =>
            query.OrderBy(x => x.NumberWeeks).ThenBy(x => x.DayOfTheWeek).ThenBy(x => x.ClassTime.StartTime);

        protected override IQueryable<Schedule> Including(IQueryable<Schedule> query) =>
            query
            .Include(x => x.Auditorium)
            .Include(x => x.ClassTime)
            .Include(x => x.Discipline)
            .Include(x => x.Teacher)
            .Include(x => x.TypeOfClass)
            .Include(x => x.StudyGroup);

        protected override IQueryable<Schedule> FilteringList(IQueryable<Schedule> query, ScheduleSearchModel model)
		{
            if (model.AuditoriumId.HasValue)
			{
                query = query.Where(x => x.AuditoriumId == model.AuditoriumId.Value);
            }
            if (model.ClassTimeId.HasValue)
            {
                query = query.Where(x => x.ClassTimeId == model.ClassTimeId.Value);
            }
            if (model.DayOfTheWeek.HasValue)
            {
                query = query.Where(x => x.DayOfTheWeek == model.DayOfTheWeek.Value);
            }
            if (model.NumberWeeks.HasValue)
            {
                query = query.Where(x => x.NumberWeeks == model.NumberWeeks.Value);
            }
            if (model.HourOfSemesterPeriodId.HasValue)
            {
                query = query.Where(x => x.HourOfSemesterPeriodId == model.HourOfSemesterPeriodId.Value);
            }
            if (model.StudyGroupId.HasValue)
            {
                query = query.Where(x => x.StudyGroupId == model.StudyGroupId.Value);
            }
            if (model.TeacherId.HasValue)
            {
                query = query.Where(x => x.TeacherId == model.TeacherId.Value);
            }
            if (model.PeriodId.HasValue)
            {
                query = query.Where(x => x.HourOfSemesterPeriod.PeriodId == model.PeriodId.Value);
            }
            if (model.IsFree.HasValue)
			{
                if (model.IsFree.Value)
                {
                    query = query.Where(x => !x.DayOfTheWeek.HasValue);
                }
                else
                {
                    query = query.Where(x => x.DayOfTheWeek.HasValue);
                }
			}

            return query;
		}

		protected override Schedule FilteringSingle(IQueryable<Schedule> query, ScheduleSearchModel model)
        {
            if (model.Id.HasValue)
            {
                query = query.Where(x => x.Id == model.Id.Value);
            }

            return query?.FirstOrDefault();
        }

        protected override Func<Schedule, bool> AdditionalCheckingWhenAdding(ScheduleBindingModel model) =>
            x => false;

		protected override Func<Schedule, bool> AdditionalCheckingWhenUpdateing(ScheduleBindingModel model) =>
            x => false;

        protected override IQueryable<Schedule> GetListForDelete(IQueryable<Schedule> query, ScheduleSearchModel model)
        {
            if (model.Id.HasValue)
            {
                query = query.Where(x => x.Id == model.Id.Value);
            }
            if (model.AuditoriumId.HasValue)
            {
                query = query.Where(x => x.AuditoriumId == model.AuditoriumId.Value);
            }
            if (model.ClassTimeId.HasValue)
            {
                query = query.Where(x => x.ClassTimeId == model.ClassTimeId.Value);
            }
            if (model.DayOfTheWeek.HasValue)
            {
                query = query.Where(x => x.DayOfTheWeek == model.DayOfTheWeek.Value);
            }
            if (model.NumberWeeks.HasValue)
            {
                query = query.Where(x => x.NumberWeeks == model.NumberWeeks.Value);
            }
            if (model.HourOfSemesterPeriodId.HasValue)
            {
                query = query.Where(x => x.HourOfSemesterPeriodId == model.HourOfSemesterPeriodId.Value);
            }
            if (model.StudyGroupId.HasValue)
            {
                query = query.Where(x => x.StudyGroupId == model.StudyGroupId.Value);
            }
            if (model.TeacherId.HasValue)
            {
                query = query.Where(x => x.TeacherId == model.TeacherId.Value);
            }

            return query;
        }

		protected override ScheduleViewModel ConvertToViewModel(Schedule entity) =>
            new()
            {
                Id = entity.Id,
                Type = entity.Type,
                AuditoriumId = entity.AuditoriumId,
                AuditoriumNumber = entity.Auditorium?.Number,
                ClassTimeId = entity.ClassTimeId,
                ClassTimeNumber = entity.ClassTime?.Number,
                DayOfTheWeek = entity.DayOfTheWeek,
                NumberWeeks = entity.NumberWeeks,
                HourOfSemesterPeriodId = entity.HourOfSemesterPeriodId,
                DisciplineTitle = entity.Discipline.AbbreviatedTitle,
                TeacherId = entity.TeacherId,
                TeacherShortName = entity.Teacher.ShortName,
                StudyGroupId = entity.StudyGroupId,
                StudyGroupTitle = entity.StudyGroup.Title,
                SubgroupNumber = entity.SubgroupNumber,
                TypeOfClassTitle = entity.TypeOfClass.Title,
                TypeOfClassShort = entity.TypeOfClass.AbbreviatedTitle
            };

        protected override Schedule ConvertToEntityModel(ScheduleBindingModel model, Schedule element)
		{
            element.AuditoriumId = model.AuditoriumId;
            element.Type = model.Type;
            element.NumberWeeks = model.NumberWeeks;
            element.DayOfTheWeek = model.DayOfTheWeek;
            element.ClassTimeId = model.ClassTimeId;
            element.HourOfSemesterPeriodId = model.HourOfSemesterPeriodId;
            element.DisciplineId = model.DisciplineId;
            element.FlowId = model.FlowId;
            element.StudyGroupId = model.StudyGroupId;
            element.SubgroupNumber = model.SubgroupNumber;
            element.TeacherId = model.TeacherId;
            element.TypeOfClassId = model.TypeOfClassId;

            return element;
        }
	}
}