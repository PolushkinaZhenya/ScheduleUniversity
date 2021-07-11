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
	public class CurriculumServiceDB : AbstractServiceDB<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel, Curriculum>,
		IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel>
	{
		public CurriculumServiceDB(ScheduleDbContext context)
		{
			_context = context;
		}

		protected override IQueryable<Curriculum> Ordering(IQueryable<Curriculum> query) =>
			query.OrderBy(x => x.SemesterId).ThenBy(x => x.StudyGroupId).ThenBy(x => x.TypeOfClassId);

		protected override IQueryable<Curriculum> Including(IQueryable<Curriculum> query) =>
			query.Include(x => x.Semester).Include(x => x.Discipline).Include(x => x.StudyGroup).Include(x => x.TypeOfClass);

		protected override IQueryable<Curriculum> FilteringList(IQueryable<Curriculum> query, CurriculumSearchModel model)
		{
			if (model.AcademicYearId.HasValue)
			{
				query = query.Where(x => x.Semester.AcademicYearId == model.AcademicYearId.Value);
			}
			if (model.DisciplineId.HasValue)
			{
				query = query.Where(x => x.DisciplineId == model.DisciplineId.Value);
			}
			if (model.SemesterId.HasValue)
			{
				query = query.Where(x => x.SemesterId == model.SemesterId.Value);
			}
			if (model.StudyGroupId.HasValue)
			{
				query = query.Where(x => x.StudyGroupId == model.StudyGroupId.Value);
			}
			if (model.TypeOfClassId.HasValue)
			{
				query = query.Where(x => x.TypeOfClassId == model.TypeOfClassId.Value);
			}
			if (model.NumderOfHours.HasValue)
			{
				query = query.Where(x => x.NumderOfHours == model.NumderOfHours.Value);
			}

			return query;
		}

		protected override Curriculum FilteringSingle(IQueryable<Curriculum> query, CurriculumSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<Curriculum, bool> AdditionalCheckingWhenAdding(CurriculumBindingModel model) =>
			x => x.DisciplineId == model.DisciplineId && x.StudyGroupId == model.StudyGroupId && x.TypeOfClassId == model.TypeOfClassId && x.SemesterId == model.SemesterId;

		protected override Func<Curriculum, bool> AdditionalCheckingWhenUpdateing(CurriculumBindingModel model) =>
			x => x.DisciplineId == model.DisciplineId && x.StudyGroupId == model.StudyGroupId && x.TypeOfClassId == model.TypeOfClassId && x.SemesterId == model.SemesterId && x.Id != model.Id;

		protected override IQueryable<Curriculum> GetListForDelete(IQueryable<Curriculum> query, CurriculumSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.SemesterId.HasValue)
			{
				query = query.Where(x => x.SemesterId == model.SemesterId.Value);
			}
			if (model.AcademicYearId.HasValue)
			{
				query = query.Where(x => x.Semester.AcademicYearId == model.AcademicYearId.Value);
			}

			return query;
		}

		protected override CurriculumViewModel ConvertToViewModel(Curriculum entity) =>
			new()
			{
				Id = entity.Id,
				DisciplineId = entity.DisciplineId,
				DisciplineTitle = entity.Discipline?.Title,
				NumderOfHours = entity.NumderOfHours,
				SemesterId = entity.SemesterId,
				SemesterTitle = entity.Semester?.Title,
				StudyGroupId = entity.StudyGroupId,
				StudyGroupTitle = entity.StudyGroup?.Title,
				TypeOfClassId = entity.TypeOfClassId,
				TypeOfClassTitle = entity.TypeOfClass?.Title
			};

		protected override Curriculum ConvertToEntityModel(CurriculumBindingModel model, Curriculum element)
		{
			element.DisciplineId = model.DisciplineId;
			element.NumderOfHours = model.NumderOfHours;
			element.SemesterId = model.SemesterId;
			element.StudyGroupId = model.StudyGroupId;
			element.TypeOfClassId = model.TypeOfClassId;

			return element;
		}
	}
}