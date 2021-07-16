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
	public class TypeOfAudienceServiceDB : AbstractServiceDB<TypeOfAudienceBindingModel, TypeOfAudienceViewModel, TypeOfAudienceSearchModel, TypeOfAudience>,
	IBaseService<TypeOfAudienceBindingModel, TypeOfAudienceViewModel, TypeOfAudienceSearchModel>
	{
		public TypeOfAudienceServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<TypeOfAudience> Ordering(IQueryable<TypeOfAudience> query) =>
			query.OrderBy(x => x.Title);

		protected override IQueryable<TypeOfAudience> Including(IQueryable<TypeOfAudience> query) =>
			query;

		protected override IQueryable<TypeOfAudience> FilteringList(IQueryable<TypeOfAudience> query, TypeOfAudienceSearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}

			return query;
		}

		protected override TypeOfAudience FilteringSingle(IQueryable<TypeOfAudience> query, TypeOfAudienceSearchModel model)
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

		protected override Func<TypeOfAudience, bool> AdditionalCheckingWhenAdding(TypeOfAudienceBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<TypeOfAudience, bool> AdditionalCheckingWhenUpdateing(TypeOfAudienceBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<TypeOfAudience> GetListForDelete(IQueryable<TypeOfAudience> query, TypeOfAudienceSearchModel model)
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

		protected override TypeOfAudienceViewModel ConvertToViewModel(TypeOfAudience entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title
			};

		protected override TypeOfAudience ConvertToEntityModel(TypeOfAudienceBindingModel model, TypeOfAudience element)
		{
			element.Title = model.Title;

			return element;
		}
	}
}