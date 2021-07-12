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
	public class StudyGroupServiceDB : AbstractServiceDB<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel, StudyGroup>,
		IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel>
	{
		public StudyGroupServiceDB(ScheduleDbContext context)
		{
			_context = context;
		}

		protected override IQueryable<StudyGroup> Ordering(IQueryable<StudyGroup> query) =>
			query.OrderBy(x => x.SpecialtyId).ThenBy(x => x.Title);

		protected override IQueryable<StudyGroup> Including(IQueryable<StudyGroup> query) =>
			query.Include(x => x.Specialty);

		protected override IQueryable<StudyGroup> FilteringList(IQueryable<StudyGroup> query, StudyGroupSearchModel model)
		{
			if (model.Course.HasValue)
			{
				query = query.Where(x => x.Course == model.Course.Value);
			}
			if (model.FormEducation.HasValue)
			{
				query = query.Where(x => x.FormEducation == model.FormEducation.Value);
			}
			if (model.GroupNumber.HasValue)
			{
				query = query.Where(x => x.GroupNumber == model.GroupNumber.Value);
			}
			if (model.NumderStudents.HasValue)
			{
				query = query.Where(x => x.NumderStudents == model.NumderStudents.Value);
			}
			if (model.SpecialtyId.HasValue)
			{
				query = query.Where(x => x.SpecialtyId == model.SpecialtyId.Value);
			}
			if (model.FacultyId.HasValue)
			{
				query = query.Where(x => x.Specialty.FacultyId == model.FacultyId.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.TypeEducation.HasValue)
			{
				query = query.Where(x => x.TypeEducation == model.TypeEducation.Value);
			}

			return query;
		}

		protected override StudyGroup FilteringSingle(IQueryable<StudyGroup> query, StudyGroupSearchModel model)
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

		protected override Func<StudyGroup, bool> AdditionalCheckingWhenAdding(StudyGroupBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<StudyGroup, bool> AdditionalCheckingWhenUpdateing(StudyGroupBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<StudyGroup> GetListForDelete(IQueryable<StudyGroup> query, StudyGroupSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title == model.Title);
			}
			if (model.SpecialtyId.HasValue)
			{
				query = query.Where(x => x.SpecialtyId == model.SpecialtyId.Value);
			}

			return query;
		}

		protected override StudyGroupViewModel ConvertToViewModel(StudyGroup entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				SpecialtyId = entity.SpecialtyId,
				SpecialtyTitle = entity.Specialty?.Title,
				TypeEducation = entity.TypeEducation,
				FormEducation = entity.FormEducation,
				GroupNumber = entity.GroupNumber,
				Course = entity.Course,
				NumderStudents = entity.NumderStudents
			};

		protected override StudyGroup ConvertToEntityModel(StudyGroupBindingModel model, StudyGroup element)
		{
			element.Title = model.Title;
			element.SpecialtyId = model.SpecialtyId;
			element.TypeEducation = model.TypeEducation;
			element.FormEducation = model.FormEducation;
			element.Course = model.Course;
			element.GroupNumber = model.GroupNumber;
			element.NumderStudents = model.NumderStudents;

			return element;
		}
	}
}