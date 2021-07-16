using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class PeriodServiceDB : AbstractServiceDB<PeriodBindingModel, PeriodViewModel, PeriodSearchModel, Period>,
		IBaseService<PeriodBindingModel, PeriodViewModel, PeriodSearchModel>
	{
		public PeriodServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<Period> Ordering(IQueryable<Period> query) =>
			query.OrderBy(x => x.StartDate);

		protected override IQueryable<Period> Including(IQueryable<Period> query) =>
			query.Include(x => x.Semester);

		protected override IQueryable<Period> FilteringList(IQueryable<Period> query, PeriodSearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}
			if (model.StartDate.HasValue)
			{
				query = query.Where(x => x.StartDate >= model.StartDate.Value);
			}
			if (model.EndDate.HasValue)
			{
				query = query.Where(x => x.EndDate <= model.EndDate.Value);
			}
			if (model.SemesterId.HasValue)
			{
				query = query.Where(x => x.SemesterId == model.SemesterId.Value);
			}
			if (model.AcademicYearId.HasValue)
			{
				query = query.Where(x => x.Semester.AcademicYearId == model.AcademicYearId.Value);
			}

			return query;
		}

		protected override Period FilteringSingle(IQueryable<Period> query, PeriodSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<Period, bool> AdditionalCheckingWhenAdding(PeriodBindingModel model) =>
			x => x.Title == model.Title && x.SemesterId == model.SemesterId;

		protected override Func<Period, bool> AdditionalCheckingWhenUpdateing(PeriodBindingModel model) =>
			x => x.Title == model.Title && x.SemesterId == model.SemesterId && x.Id != model.Id;

		protected override IQueryable<Period> GetListForDelete(IQueryable<Period> query, PeriodSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.SemesterId.HasValue)
			{
				query = query.Where(x => x.SemesterId == model.SemesterId.Value);
			}
			if (model.AcademicYearId.HasValue)
			{
				query = query.Where(x => x.Semester.AcademicYearId == model.AcademicYearId.Value);
			}

			return query;
		}

		protected override PeriodViewModel ConvertToViewModel(Period entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				EndDate = entity.EndDate,
				StartDate = entity.StartDate,
				SemesterId = entity.SemesterId,
				SemesterTitle = entity.Semester?.Title
			};

		protected override Period ConvertToEntityModel(PeriodBindingModel model, Period element)
		{
			element.Title = model.Title;
			element.EndDate = model.EndDate;
			element.StartDate = model.StartDate;
			element.SemesterId = model.SemesterId;

			return element;
		}
	}
}