using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class FlowServiceDB : AbstractServiceDB<FlowBindingModel, FlowViewModel, FlowSearchModel, Flow>,
		IBaseService<FlowBindingModel, FlowViewModel, FlowSearchModel>
	{
		public FlowServiceDB(ScheduleDbContext context)
		{
			_context = context;
		}

		protected override IQueryable<Flow> Ordering(IQueryable<Flow> query) =>
			query.OrderBy(x => x.Title);

		protected override IQueryable<Flow> Including(IQueryable<Flow> query) =>
			query.Include(x => x.FlowStudyGroups).ThenInclude(y => y.StudyGroup);

		protected override IQueryable<Flow> FilteringList(IQueryable<Flow> query, FlowSearchModel model)
		{
			if (model.FlowAutoCreation.HasValue)
			{
				query = query.Where(x => x.FlowAutoCreation == model.FlowAutoCreation.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.StudentGroupId.HasValue)
			{
				query = query.Where(x => x.FlowStudyGroups.Any(y => y.StudyGroupId == model.StudentGroupId.Value));
			}

			return query;
		}

		protected override Flow FilteringSingle(IQueryable<Flow> query, FlowSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}

			return query?.FirstOrDefault();
		}

		protected override Func<Flow, bool> AdditionalCheckingWhenAdding(FlowBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<Flow, bool> AdditionalCheckingWhenUpdateing(FlowBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<Flow> GetListForDelete(IQueryable<Flow> query, FlowSearchModel model)
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

		protected override FlowViewModel ConvertToViewModel(Flow entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				FlowAutoCreation = entity.FlowAutoCreation,
				FlowStudyGroups = entity.FlowStudyGroups.Select(x => new FlowStudyGroupViewModel
				{
					Id = x.Id,
					FlowId = x.FlowId,
					StudyGroupId = x.StudyGroupId,
					StudyGroupTitle = x.StudyGroup?.Title,
					Subgroup = x.Subgroup
				}).ToList()
			};

		protected override Flow ConvertToEntityModel(FlowBindingModel model, Flow element)
		{
			element.Title = model.Title;
			element.FlowAutoCreation = element.FlowAutoCreation;

			return element;
		}

		protected override void AdditionalActionsOnAddition(FlowBindingModel model, Flow element)
		{
			base.AdditionalActionsOnAddition(model, element); 
			
			var studygroups = model.FlowStudyGroups;

			// добавляем группы 
			foreach (var studygroup in studygroups)
			{
				_context.FlowStudyGroups.Add(new FlowStudyGroup
				{
					Id = Guid.NewGuid(),
					FlowId = element.Id,
					StudyGroupId = studygroup.StudyGroupId,
					Subgroup = studygroup.Subgroup
				});
				_context.SaveChanges();
			}
		}

		protected override void AdditionalActionsOnUpdate(FlowBindingModel model, Flow element)
		{
			base.AdditionalActionsOnUpdate(model, element);

			// обновляем существуюущие компоненты 
			var studygroupIds = model.FlowStudyGroups.Select(rec => rec.StudyGroupId).Distinct();

			var updateStudygroups = _context.FlowStudyGroups
				.Where(rec => rec.FlowId == model.Id && studygroupIds.Contains(rec.StudyGroupId));

			_context.SaveChanges();
			_context.FlowStudyGroups.RemoveRange(_context.FlowStudyGroups.Where(x => x.FlowId == model.Id && !studygroupIds.Contains(x.StudyGroupId)));
			_context.SaveChanges();

			// новые записи  
			var studygroups = model.FlowStudyGroups;

			foreach (var studygroup in studygroups)
			{
				FlowStudyGroup elementFS = _context.FlowStudyGroups.FirstOrDefault(x => x.FlowId == model.Id && x.StudyGroupId == studygroup.StudyGroupId);

				if (elementFS != null)
				{
					elementFS.Subgroup = studygroup.Subgroup;
					_context.SaveChanges();
				}
				else
				{
					_context.FlowStudyGroups.Add(new FlowStudyGroup
					{
						Id = Guid.NewGuid(),
						FlowId = model.Id,
						StudyGroupId = studygroup.StudyGroupId,
						Subgroup = studygroup.Subgroup
					});
					_context.SaveChanges();
				}
			}
		}
	}
}