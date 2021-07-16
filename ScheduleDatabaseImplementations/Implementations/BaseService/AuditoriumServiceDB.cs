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
	public class AuditoriumServiceDB : AbstractServiceDB<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel, Auditorium>,
		IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel>
	{
		public AuditoriumServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<Auditorium> Ordering(IQueryable<Auditorium> query) =>
			query.OrderBy(x => x.EducationalBuilding).ThenBy(x => x.Number);

		protected override IQueryable<Auditorium> Including(IQueryable<Auditorium> query) =>
			query.Include(x => x.Department).Include(x => x.EducationalBuilding).Include(x => x.TypeOfAudience);

		protected override IQueryable<Auditorium> FilteringList(IQueryable<Auditorium> query, AuditoriumSearchModel model)
		{
			if (model.Capacity.HasValue)
			{
				query = query.Where(x => x.Capacity == model.Capacity.Value);
			}
			if (model.DepartmentId.HasValue)
			{
				query = query.Where(x => x.DepartmentId == model.DepartmentId.Value);
			}
			if (model.EducationalBuildingId.HasValue)
			{
				query = query.Where(x => x.EducationalBuildingId == model.EducationalBuildingId.Value);
			}
			if (model.Number.IsNotEmpty())
			{
				query = query.Where(x => x.Number == model.Number);
			}
			if (model.TypeOfAudienceId.HasValue)
			{
				query = query.Where(x => x.TypeOfAudienceId == model.TypeOfAudienceId.Value);
			}

			return query;
		}

		protected override Auditorium FilteringSingle(IQueryable<Auditorium> query, AuditoriumSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Number.IsNotEmpty())
			{
				query = query.Where(x => x.Number == model.Number);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<Auditorium, bool> AdditionalCheckingWhenAdding(AuditoriumBindingModel model) =>
			x => x.Number == model.Number && x.EducationalBuildingId == model.EducationalBuildingId;

		protected override Func<Auditorium, bool> AdditionalCheckingWhenUpdateing(AuditoriumBindingModel model) =>
			x => x.Number == model.Number && x.EducationalBuildingId == model.EducationalBuildingId && x.Id != model.Id;

		protected override IQueryable<Auditorium> GetListForDelete(IQueryable<Auditorium> query, AuditoriumSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Number.IsNotEmpty())
			{
				query = query.Where(x => x.Number == model.Number);
			}
			if (model.EducationalBuildingId.HasValue)
			{
				query = query.Where(x => x.EducationalBuildingId == model.EducationalBuildingId.Value);
			}
			if (model.DepartmentId.HasValue)
			{
				query = query.Where(x => x.DepartmentId == model.DepartmentId.Value);
			}

			return query;
		}

		protected override AuditoriumViewModel ConvertToViewModel(Auditorium entity) =>
			new()
			{
				Id = entity.Id,
				Number = entity.Number,
				Capacity = entity.Capacity,
				TypeOfAudienceId = entity.TypeOfAudienceId,
				TypeOfAudience = entity.TypeOfAudience?.Title,
				EducationalBuildingId = entity.EducationalBuildingId,
				EducationalBuilding = entity.EducationalBuilding?.Number,
				DepartmentId = entity.DepartmentId,
				Department = entity.Department?.Title
			};

		protected override Auditorium ConvertToEntityModel(AuditoriumBindingModel model, Auditorium element)
		{
			element.Number = model.Number;
			element.Capacity = model.Capacity;
			element.TypeOfAudienceId = model.TypeOfAudienceId;
			element.EducationalBuildingId = model.EducationalBuildingId;
			element.DepartmentId = model.DepartmentId;

			return element;
		}
	}
}