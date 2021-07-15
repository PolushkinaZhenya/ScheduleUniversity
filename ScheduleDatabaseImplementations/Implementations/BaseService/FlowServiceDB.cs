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

			return element;
		}

		protected override void AdditionalActionsOnAddition(FlowBindingModel model, Flow element)
		{
			base.AdditionalActionsOnAddition(model, element); 
			
			var studygroups = model.FlowStudyGroups;

			// добавляем группы 
			foreach (var studygroup in studygroups)
			{
				_context.FlowStudyGroups.Add(ConvertToFlowStudyGroup(studygroup, null, element));
				_context.SaveChanges();
			}
		}

		protected override void AdditionalActionsOnUpdate(FlowBindingModel model, Flow element)
		{
			base.AdditionalActionsOnUpdate(model, element);

			var studygroupIds = model.FlowStudyGroups.Select(x => x.StudyGroupId).Distinct();
			_context.FlowStudyGroups.RemoveRange(_context.FlowStudyGroups.Where(x => x.FlowId == model.Id && !studygroupIds.Contains(x.StudyGroupId)));
			_context.SaveChanges();

			// новые записи  
			var studygroups = model.FlowStudyGroups;

			foreach (var studygroup in studygroups)
			{
				var elementFS = _context.FlowStudyGroups.FirstOrDefault(x => x.FlowId == model.Id && x.StudyGroupId == studygroup.StudyGroupId);

				if (elementFS != null)
				{
					elementFS.Subgroup = studygroup.Subgroup;
					_context.SaveChanges();
				}
				else
				{
					_context.FlowStudyGroups.Add(ConvertToFlowStudyGroup(studygroup, null, element));
					_context.SaveChanges();
				}
			}
		}

		private static FlowStudyGroup ConvertToFlowStudyGroup(FlowStudyGroupBindingModel model, FlowStudyGroup element, Flow f)
		{
			if (model == null) return null;
			if (element == null) element = new FlowStudyGroup { Id = Guid.NewGuid() };
			element.FlowId = f.Id;
			element.StudyGroupId = model.StudyGroupId;
			element.Subgroup = model.Subgroup;

			return element;
		}
	}
}