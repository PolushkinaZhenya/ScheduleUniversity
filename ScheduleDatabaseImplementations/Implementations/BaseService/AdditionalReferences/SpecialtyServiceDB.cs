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
	public class SpecialtyServiceDB : AbstractServiceDB<SpecialtyBindingModel, SpecialtyViewModel, SpecialtySearchModel, Specialty>,
		IBaseService<SpecialtyBindingModel, SpecialtyViewModel, SpecialtySearchModel>
	{
		public SpecialtyServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<Specialty> Ordering(IQueryable<Specialty> query) =>
			query.OrderBy(x => x.Title);

		protected override IQueryable<Specialty> Including(IQueryable<Specialty> query) =>
			query.Include(x => x.Faculty);

		protected override IQueryable<Specialty> FilteringList(IQueryable<Specialty> query, SpecialtySearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}
			if (model.Code.IsNotEmpty())
			{
				query = query.Where(x => x.Code.Contains(model.Code));
			}
			if (model.AbbreviatedTitle.IsNotEmpty())
			{
				query = query.Where(x => x.AbbreviatedTitle.Contains(model.AbbreviatedTitle));
			}
			if (model.FacultyId.HasValue)
			{
				query = query.Where(x => x.FacultyId == model.FacultyId.Value);
			}

			return query;
		}

		protected override Specialty FilteringSingle(IQueryable<Specialty> query, SpecialtySearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.Code.IsNotEmpty())
			{
				query = query.Where(x => x.Code == model.Code);
			}
			if (model.AbbreviatedTitle.IsNotEmpty())
			{
				query = query.Where(x => x.AbbreviatedTitle == model.AbbreviatedTitle);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<Specialty, bool> AdditionalCheckingWhenAdding(SpecialtyBindingModel model) =>
			x => x.Title == model.Title || x.AbbreviatedTitle == model.AbbreviatedTitle;

		protected override Func<Specialty, bool> AdditionalCheckingWhenUpdateing(SpecialtyBindingModel model) =>
			x => (x.Title == model.Title || x.AbbreviatedTitle == model.AbbreviatedTitle) && x.Id != model.Id;

		protected override IQueryable<Specialty> GetListForDelete(IQueryable<Specialty> query, SpecialtySearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.Code.IsNotEmpty())
			{
				query = query.Where(x => x.Code == model.Code);
			}

			return query;
		}

		protected override SpecialtyViewModel ConvertToViewModel(Specialty entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				Code = entity.Code,
				AbbreviatedTitle = entity.AbbreviatedTitle,
				FacultyId = entity.FacultyId,
				FacultyTitle = entity.Faculty?.Title
			};

		protected override Specialty ConvertToEntityModel(SpecialtyBindingModel model, Specialty element)
		{
			element.Title = model.Title;
			element.Code = model.Code;
			element.AbbreviatedTitle = model.AbbreviatedTitle;
			element.FacultyId = model.FacultyId;

			return element;
		}
	}
}