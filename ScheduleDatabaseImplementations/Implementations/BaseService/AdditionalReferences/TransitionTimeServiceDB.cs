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
	public class TransitionTimeServiceDB : AbstractServiceDB<TransitionTimeBindingModel, TransitionTimeViewModel, TransitionTimeSearchModel, TransitionTime>,
		IBaseService<TransitionTimeBindingModel, TransitionTimeViewModel, TransitionTimeSearchModel>
	{
		public TransitionTimeServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<TransitionTime> Ordering(IQueryable<TransitionTime> query) =>
			query.OrderBy(x => x.EducationalBuildingFrom.Title).ThenBy(x => x.EducationalBuildingTo.Title);

		protected override IQueryable<TransitionTime> Including(IQueryable<TransitionTime> query) =>
			query.Include(x => x.EducationalBuildingFrom).Include(x => x.EducationalBuildingTo);

		protected override IQueryable<TransitionTime> FilteringList(IQueryable<TransitionTime> query, TransitionTimeSearchModel model)
		{
			if (model.Time.HasValue)
			{
				query = query.Where(x => x.Time == model.Time.Value);
			}
			if (model.EducationalBuildingIdFrom.HasValue)
			{
				query = query.Where(x => x.EducationalBuildingIdFrom == model.EducationalBuildingIdFrom.Value);
			}
			if (model.EducationalBuildingIdTo.HasValue)
			{
				query = query.Where(x => x.EducationalBuildingIdTo == model.EducationalBuildingIdTo.Value);
			}

			return query;
		}

		protected override TransitionTime FilteringSingle(IQueryable<TransitionTime> query, TransitionTimeSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<TransitionTime, bool> AdditionalCheckingWhenAdding(TransitionTimeBindingModel model) =>
			x => x.EducationalBuildingIdFrom == model.EducationalBuildingIdFrom && x.EducationalBuildingIdTo == model.EducationalBuildingIdTo;

		protected override Func<TransitionTime, bool> AdditionalCheckingWhenUpdateing(TransitionTimeBindingModel model) =>
			x => x.EducationalBuildingIdFrom == model.EducationalBuildingIdFrom && x.EducationalBuildingIdTo == model.EducationalBuildingIdTo && x.Id != model.Id;

		protected override IQueryable<TransitionTime> GetListForDelete(IQueryable<TransitionTime> query, TransitionTimeSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.EducationalBuildingIdFrom.HasValue)
			{
				query = query.Where(x => x.EducationalBuildingIdFrom == model.EducationalBuildingIdFrom.Value);
			}
			if (model.EducationalBuildingIdTo.HasValue)
			{
				query = query.Where(x => x.EducationalBuildingIdTo == model.EducationalBuildingIdTo.Value);
			}

			return query;
		}

		protected override TransitionTimeViewModel ConvertToViewModel(TransitionTime entity) =>
			new()
			{
				Id = entity.Id,
				EducationalBuildingIdFrom = entity.EducationalBuildingIdFrom,
				EducationalBuildingFrom = entity.EducationalBuildingFrom.Number,
				EducationalBuildingIdTo = entity.EducationalBuildingIdTo,
				EducationalBuildingTo = entity.EducationalBuildingTo.Number,
				Time = entity.Time
			};

		protected override TransitionTime ConvertToEntityModel(TransitionTimeBindingModel model, TransitionTime element)
		{
			element.EducationalBuildingIdFrom = model.EducationalBuildingIdFrom;
			element.EducationalBuildingIdTo = model.EducationalBuildingIdTo;
			element.Time = model.Time;

			return element;
		}
	}
}