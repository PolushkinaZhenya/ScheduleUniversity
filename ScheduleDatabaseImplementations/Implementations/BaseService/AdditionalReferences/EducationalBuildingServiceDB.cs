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
	public class EducationalBuildingServiceDB : AbstractServiceDB<EducationalBuildingBindingModel, EducationalBuildingViewModel, EducationalBuildingSearchModel, EducationalBuilding>,
		IBaseService<EducationalBuildingBindingModel, EducationalBuildingViewModel, EducationalBuildingSearchModel>
	{
		public EducationalBuildingServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<EducationalBuilding> Ordering(IQueryable<EducationalBuilding> query) =>
			query.OrderBy(x => x.Number);

		protected override IQueryable<EducationalBuilding> Including(IQueryable<EducationalBuilding> query) =>
			query;

		protected override IQueryable<EducationalBuilding> FilteringList(IQueryable<EducationalBuilding> query, EducationalBuildingSearchModel model)
		{
			if (model.Number.IsNotEmpty())
			{
				query = query.Where(x => x.Number.Contains(model.Number));
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}

			return query;
		}

		protected override EducationalBuilding FilteringSingle(IQueryable<EducationalBuilding> query, EducationalBuildingSearchModel model)
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

		protected override Func<EducationalBuilding, bool> AdditionalCheckingWhenAdding(EducationalBuildingBindingModel model) =>
			x => x.Title == model.Title || x.Number == model.Number;

		protected override Func<EducationalBuilding, bool> AdditionalCheckingWhenUpdateing(EducationalBuildingBindingModel model) =>
			x => (x.Title == model.Title || x.Number == model.Number) && x.Id != model.Id;

		protected override IQueryable<EducationalBuilding> GetListForDelete(IQueryable<EducationalBuilding> query, EducationalBuildingSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.Number.IsNotEmpty())
			{
				query = query.Where(x => x.Number == model.Number);
			}

			return query;
		}

		protected override EducationalBuildingViewModel ConvertToViewModel(EducationalBuilding entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				Number = entity.Number
			};

		protected override EducationalBuilding ConvertToEntityModel(EducationalBuildingBindingModel model, EducationalBuilding element)
		{
			element.Title = model.Title;
			element.Number = model.Number;

			return element;
		}
	}
}