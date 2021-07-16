using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class MainService : IMainService
	{
		private readonly DbContextOptions<ScheduleDbContext> _options;

		public MainService(DbContextOptions<ScheduleDbContext> option)
		{
			_options = option;
		}

		private ScheduleDbContext GetContext { get => new(_options); }

		public List<PeriodWithAcademicYearViewModel> GetPeriods()
		{
			using var context = GetContext;
			return context.Periods
				.Include(x => x.Semester).Include(x => x.Semester.AcademicYear)
				.OrderBy(x => x.StartDate)
				.Select(GetPeriodWithAcademicYearViewModel)
				.ToList();
		}

		public PeriodWithAcademicYearViewModel GetPeriod(Guid id)
		{
			using var context = GetContext;
			return context.Periods
				.Include(x => x.Semester).Include(x => x.Semester.AcademicYear)
				.Where(x => x.Id == id)
				.Select(GetPeriodWithAcademicYearViewModel)
				.FirstOrDefault();
		}

		private PeriodWithAcademicYearViewModel GetPeriodWithAcademicYearViewModel(Period entity) =>
			new()
			{
				Id = entity.Id,
				PeriodTitle = entity.Title,
				SemesterId = entity.SemesterId,
				SemesterTitle = entity.Semester?.Title,
				AcademicYearTitle = entity.Semester?.AcademicYear?.Title
			};

		public void UpdateHours(UpdateHoursBindingModel model)
		{
			using var context = GetContext;
			var record = context.HourOfSemesterPeriods.FirstOrDefault(x => x.Id == model.HourOfSemesterPeriodId);
			if (record == null)
			{
				throw new Exception("Не найдена запись расчасовки по идентификатору");
			}
			record.HoursFirstWeek = model.FirstWeekCountLessons;
			record.HoursSecondWeek = model.SecondWeekCountLessons;
			context.SaveChanges();
		}

		public List<PeriodForHousOfSemesterViewModel> GetHourOfSemestersPeriodRecords(PeriodForHousOfSemesterBindingModel model)
		{
			using var context = GetContext;
			return context.HourOfSemesterPeriods
				.Include(x => x.HourOfSemesterRecord)
				.Include(x => x.HourOfSemesterRecord.Teacher).Include(x => x.HourOfSemesterRecord.Flow)
				.Include(x => x.HourOfSemesterRecord.Flow.FlowStudyGroups).ThenInclude(x => x.StudyGroup)
				.Include(x => x.HourOfSemesterRecord.HourOfSemesterAuditoriums).ThenInclude(x => x.Auditorium)
				.Include(x => x.HourOfSemesterRecord.HourOfSemester)
				.Include(x => x.HourOfSemesterRecord.HourOfSemester.Discipline)
				.Where(x => x.PeriodId == model.PeriodId && x.HourOfSemesterRecord.TypeOfClassId == model.TypeOfClassId &&
														x.HourOfSemesterRecord.HourOfSemester.StudyGroupId == model.StudyGroupId)
				.Select(x => new PeriodForHousOfSemesterViewModel
				{
					HourOfSemesterPeriodId = x.Id,
					HousOfSemesterId = x.HourOfSemesterRecord.HourOfSemesterId,
					DisciplineTitle = x.HourOfSemesterRecord.HourOfSemester.Discipline.Title,
					TeacherShortName = x.HourOfSemesterRecord.Teacher.ShortName,
					SubgroupNumber = x.HourOfSemesterRecord.SubgroupNumber,
					TotalHours = x.HourOfSemesterRecord.TotalHours,
					Flows = x.HourOfSemesterRecord.Flow != null ? x.HourOfSemesterRecord.Flow.FlowStudyGroups.Select(y => y.StudyGroup.Title).ToList() : null,
					HoursFirstWeek = x.HoursFirstWeek,
					HoursSecondWeek = x.HoursSecondWeek,
					Auditoriums = string.Join(",", x.HourOfSemesterRecord.HourOfSemesterAuditoriums.Select(y => y.Auditorium.Number).ToList())
				})
				.ToList();
		}
	}
}