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
	public class SemesterServiceDB : AbstractServiceDB<SemesterBindingModel, SemesterViewModel, SemesterSearchModel, Semester>,
		IBaseService<SemesterBindingModel, SemesterViewModel, SemesterSearchModel>
	{
		public SemesterServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<Semester> Ordering(IQueryable<Semester> query) =>
			query.OrderBy(x => x.Title);

		protected override IQueryable<Semester> Including(IQueryable<Semester> query) =>
			query.Include(x => x.AcademicYear);

		protected override IQueryable<Semester> FilteringList(IQueryable<Semester> query, SemesterSearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}
			if (model.AcademicYearId.HasValue)
			{
				query = query.Where(x => x.AcademicYearId == model.AcademicYearId.Value);
			}

			return query;
		}

		protected override Semester FilteringSingle(IQueryable<Semester> query, SemesterSearchModel model)
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

		protected override Func<Semester, bool> AdditionalCheckingWhenAdding(SemesterBindingModel model) =>
			x => x.Title == model.Title && x.AcademicYearId == model.AcademicYearId;

		protected override Func<Semester, bool> AdditionalCheckingWhenUpdateing(SemesterBindingModel model) =>
			x => x.Title == model.Title && x.AcademicYearId == model.AcademicYearId && x.Id != model.Id;

		protected override IQueryable<Semester> GetListForDelete(IQueryable<Semester> query, SemesterSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.AcademicYearId.HasValue)
			{
				query = query.Where(x => x.AcademicYearId == model.AcademicYearId.Value);
			}

			return query;
		}

		protected override SemesterViewModel ConvertToViewModel(Semester entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				AcademicYearId = entity.AcademicYearId,
				AcademicYearTitle = entity.AcademicYear?.Title
			};

		protected override Semester ConvertToEntityModel(SemesterBindingModel model, Semester element)
		{
			element.Title = model.Title;
			element.AcademicYearId = model.AcademicYearId;

			return element;
		}
	}
}