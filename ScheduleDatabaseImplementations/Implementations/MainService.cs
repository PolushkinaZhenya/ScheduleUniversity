using Microsoft.EntityFrameworkCore;
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
		private readonly ScheduleDbContext _context;

		public MainService(ScheduleDbContext context)
		{
			_context = context;
		}

		public List<PeriodWithAcademicYearViewModel> GetPeriods() =>
			_context.Periods
				.Include(x => x.Semester).Include(x => x.Semester.AcademicYear)
				.OrderBy(x => x.StartDate)
				.Select(GetPeriodWithAcademicYearViewModel)
				.ToList();

		public PeriodWithAcademicYearViewModel GetPeriod(Guid id) => 
			_context.Periods
				.Include(x => x.Semester).Include(x => x.Semester.AcademicYear)
				.Where(x => x.Id == id)
				.Select(GetPeriodWithAcademicYearViewModel)
				.FirstOrDefault();

		private PeriodWithAcademicYearViewModel GetPeriodWithAcademicYearViewModel(Period entity) =>
			new()
			{
				Id = entity.Id,
				PeriodTitle = entity.Title,
				SemesterTitle = entity.Semester?.Title,
				AcademicYearTitle = entity.Semester?.AcademicYear?.Title
			};
	}
}