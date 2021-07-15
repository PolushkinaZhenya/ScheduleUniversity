using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class TypeOfClassServiceDB : AbstractServiceDB<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel, TypeOfClass>,
		IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel>
	{
		public TypeOfClassServiceDB(ScheduleDbContext context)
		{
			_context = context;
		}

		protected override IQueryable<TypeOfClass> Ordering(IQueryable<TypeOfClass> query) =>
			query.OrderBy(x => x.Priority).ThenBy(x => x.Title);

		protected override IQueryable<TypeOfClass> Including(IQueryable<TypeOfClass> query) =>
			query;

		protected override IQueryable<TypeOfClass> FilteringList(IQueryable<TypeOfClass> query, TypeOfClassSearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}
			if (model.AbbreviatedTitle.IsNotEmpty())
			{
				query = query.Where(x => x.AbbreviatedTitle.Contains(model.AbbreviatedTitle));
			}

			return query;
		}

		protected override TypeOfClass FilteringSingle(IQueryable<TypeOfClass> query, TypeOfClassSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.AbbreviatedTitle.IsNotEmpty())
			{
				query = query.Where(x => x.AbbreviatedTitle == model.AbbreviatedTitle);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<TypeOfClass, bool> AdditionalCheckingWhenAdding(TypeOfClassBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<TypeOfClass, bool> AdditionalCheckingWhenUpdateing(TypeOfClassBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<TypeOfClass> GetListForDelete(IQueryable<TypeOfClass> query, TypeOfClassSearchModel model)
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

		protected override TypeOfClassViewModel ConvertToViewModel(TypeOfClass entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				AbbreviatedTitle = entity.AbbreviatedTitle,
				Priority = entity.Priority
			};

		protected override TypeOfClass ConvertToEntityModel(TypeOfClassBindingModel model, TypeOfClass element)
		{
			element.Title = model.Title;
			element.AbbreviatedTitle = model.AbbreviatedTitle;
			element.Priority = model.Priority;

			return element;
		}
	}
}