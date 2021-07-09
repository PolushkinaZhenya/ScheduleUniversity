using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class DisciplineServiceDB : AbstractServiceDB<DisciplineBindingModel, DisciplineViewModel, DisciplineSearchModel, Discipline>,
		IBaseService<DisciplineBindingModel, DisciplineViewModel, DisciplineSearchModel>
	{
		public DisciplineServiceDB(ScheduleDbContext context)
		{
			_context = context;
		}

		protected override IQueryable<Discipline> Ordering(IQueryable<Discipline> query) => 
			query.OrderBy(x => x.Title);

		protected override IQueryable<Discipline> Including(IQueryable<Discipline> query) =>
			query;

		protected override IQueryable<Discipline> FilteringList(IQueryable<Discipline> query, DisciplineSearchModel model)
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

		protected override Discipline FilteringSingle(IQueryable<Discipline> query, DisciplineSearchModel model)
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

		protected override Func<Discipline, bool> AdditionalCheckingWhenAdding(DisciplineBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<Discipline, bool> AdditionalCheckingWhenUpdateing(DisciplineBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<Discipline> GetListForDelete(IQueryable<Discipline> query, DisciplineSearchModel model)
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

		protected override DisciplineViewModel ConvertToViewModel(Discipline entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				AbbreviatedTitle = entity.AbbreviatedTitle
			};

		protected override Discipline ConvertToEntityModel(DisciplineBindingModel model, Discipline element)
		{
			element.Title = model.Title;
			element.AbbreviatedTitle = model.AbbreviatedTitle;

			return element;
		}
	}
}