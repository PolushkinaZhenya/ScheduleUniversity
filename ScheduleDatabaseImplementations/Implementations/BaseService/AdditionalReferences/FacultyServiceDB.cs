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
	public class FacultyServiceDB : AbstractServiceDB<FacultyBindingModel, FacultyViewModel, FacultySearchModel, Faculty>,
		IBaseService<FacultyBindingModel, FacultyViewModel, FacultySearchModel>
	{
		public FacultyServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<Faculty> Ordering(IQueryable<Faculty> query) =>
			query.OrderBy(x => x.Title);

		protected override IQueryable<Faculty> Including(IQueryable<Faculty> query) =>
			query;

		protected override IQueryable<Faculty> FilteringList(IQueryable<Faculty> query, FacultySearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}

			return query;
		}

		protected override Faculty FilteringSingle(IQueryable<Faculty> query, FacultySearchModel model)
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

		protected override Func<Faculty, bool> AdditionalCheckingWhenAdding(FacultyBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<Faculty, bool> AdditionalCheckingWhenUpdateing(FacultyBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<Faculty> GetListForDelete(IQueryable<Faculty> query, FacultySearchModel model)
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

		protected override FacultyViewModel ConvertToViewModel(Faculty entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title
			};

		protected override Faculty ConvertToEntityModel(FacultyBindingModel model, Faculty element)
		{
			element.Title = model.Title;

			return element;
		}
	}
}