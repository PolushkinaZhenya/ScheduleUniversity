using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class ClassTimeServiceDB : AbstractServiceDB<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel, ClassTime>,
		IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel>
	{
		public ClassTimeServiceDB(ScheduleDbContext context)
		{
			_context = context;
		}

		protected override IQueryable<ClassTime> Ordering(IQueryable<ClassTime> query) => 
			query.OrderBy(x => x.Number);

		protected override IQueryable<ClassTime> Including(IQueryable<ClassTime> query) => 
			query;

		protected override IQueryable<ClassTime> FilteringList(IQueryable<ClassTime> query, ClassTimeSearchModel model)
		{
			if (model.Number.HasValue)
			{
				query = query.Where(x => x.Number == model.Number.Value);
			}
			if (model.StartTime.HasValue)
			{
				query = query.Where(x => x.StartTime >= model.StartTime.Value);
			}
			if (model.EndTime.HasValue)
			{
				query = query.Where(x => x.EndTime <= model.EndTime.Value);
			}

			return query;
		}

		protected override ClassTime FilteringSingle(IQueryable<ClassTime> query, ClassTimeSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Number.HasValue)
			{
				query = query.Where(x => x.Number == model.Number.Value);
			}
			if (model.StartTime.HasValue)
			{
				query = query.Where(x => x.StartTime == model.StartTime.Value);
			}
			if (model.EndTime.HasValue)
			{
				query = query.Where(x => x.EndTime == model.EndTime.Value);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<ClassTime, bool> AdditionalCheckingWhenAdding(ClassTimeBindingModel model) => 
			x => x.Number == model.Number;

		protected override Func<ClassTime, bool> AdditionalCheckingWhenUpdateing(ClassTimeBindingModel model) => 
			x => x.Number == model.Number && x.Id != model.Id;

		protected override IQueryable<ClassTime> GetListForDelete(IQueryable<ClassTime> query, ClassTimeSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Number.HasValue)
			{
				query = query.Where(x => x.Number == model.Number.Value);
			}

			return query;
		}

		protected override ClassTimeViewModel ConvertToViewModel(ClassTime entity) =>
			new()
			{
				Id = entity.Id,
				Number = entity.Number,
				EndTime = entity.EndTime,
				StartTime = entity.StartTime
			};

		protected override ClassTime ConvertToEntityModel(ClassTimeBindingModel model, ClassTime element)
		{
			element.Number = model.Number;
			element.StartTime = model.StartTime;
			element.EndTime = model.EndTime;

			return element;
		}
	}
}