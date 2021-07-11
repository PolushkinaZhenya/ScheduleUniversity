using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class AcademicYearServiceDB : AbstractServiceDB<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel, AcademicYear>,
		IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel>
	{
		public AcademicYearServiceDB(ScheduleDbContext context)
		{
			_context = context;
		}

		protected override IQueryable<AcademicYear> Ordering(IQueryable<AcademicYear> query) =>
			query.OrderBy(x => x.Title);

		protected override IQueryable<AcademicYear> Including(IQueryable<AcademicYear> query) =>
			query;

		protected override IQueryable<AcademicYear> FilteringList(IQueryable<AcademicYear> query, AcademicYearSearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}

			return query;
		}

		protected override AcademicYear FilteringSingle(IQueryable<AcademicYear> query, AcademicYearSearchModel model)
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

		protected override Func<AcademicYear, bool> AdditionalCheckingWhenAdding(AcademicYearBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<AcademicYear, bool> AdditionalCheckingWhenUpdateing(AcademicYearBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<AcademicYear> GetListForDelete(IQueryable<AcademicYear> query, AcademicYearSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}

			return query;
		}

		protected override AcademicYearViewModel ConvertToViewModel(AcademicYear entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title
			};

		protected override AcademicYear ConvertToEntityModel(AcademicYearBindingModel model, AcademicYear element)
		{
			element.Title = model.Title;

			return element;
		}
	}
}