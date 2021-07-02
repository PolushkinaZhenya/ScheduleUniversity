using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class StudyGroupServiceDB : IStudyGroupService
	{
		private readonly ScheduleDbContext context;

		public StudyGroupServiceDB(ScheduleDbContext context)
		{
			this.context = context;
		}

		public List<StudyGroupViewModel> GetList() => context.StudyGroups.Select(GetViewModel).OrderBy(reco => reco.Title).ToList();

		public List<StudyGroupViewModel> GetListCourse()
		{
			List<StudyGroupViewModel> result = context.StudyGroups.Select
				(rec => new StudyGroupViewModel
				{
					Course = rec.Course
				})
				.Distinct()
				.OrderBy(reco => reco.Course)
				.ToList();

			return result;
		}

		public List<StudyGroupViewModel> GetListByCourse(int Course) => context.StudyGroups
				.Include(x => x.Specialty)
				.Where(rec => rec.Course == Course)
				.Select(GetViewModel)
				.OrderBy(reco => reco.Title)
				.ToList();

		public List<StudyGroupViewModel> GetListByFaculty(Guid facultyId) => context.StudyGroups
				.Include(x => x.Specialty)
				.Where(rec => rec.Specialty.FacultyId == facultyId)
				.Select(GetViewModel)
				.OrderBy(reco => reco.Course).ThenBy(reco => reco.Title)
				.ToList();

		public List<StudyGroupViewModel> GetListBySpecialty(Guid specialtyId) => context.StudyGroups
				.Include(x => x.Specialty)
				.Where(rec => rec.SpecialtyId == specialtyId)
				.Select(GetViewModel)
				.OrderBy(reco => reco.Course).ThenBy(reco => reco.Title)
				.ToList();

		public List<SpecialtyViewModel> GetSpecialtyByFaculty(Guid? facultyId) => context.Specialties
				.Where(x => x.FacultyId == facultyId || facultyId == null)
				.Select(rec => new SpecialtyViewModel
				{
					Id = rec.Id,
					Code = rec.Code,
					Title = rec.Title,
					AbbreviatedTitle = rec.AbbreviatedTitle,
					FacultyTitle = rec.Faculty.Title
				}).OrderBy(reco => reco.Title)
				.ToList();

		public StudyGroupViewModel GetElement(Guid id)
		{
			StudyGroup element = context.StudyGroups.Include(x => x.Specialty).FirstOrDefault(rec => rec.Id == id);

			if (element != null)
			{
				return GetViewModel(element);
			}
			throw new Exception("Элемент не найден");
		}

		public StudyGroupViewModel GetElementByTitle(string Title)
		{
			StudyGroup element = context.StudyGroups.Include(x => x.Specialty).Where(rec => rec.Title == Title).FirstOrDefault();

			if (element != null)
			{
				return GetViewModel(element);
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(StudyGroupBindingModel model)
		{
			StudyGroup element = context.StudyGroups.FirstOrDefault
			(rec => rec.Title == model.Title);

			if (element != null)
			{
				throw new Exception("Уже есть такая группа");
			}

			context.StudyGroups.Add(GetModel(model));
			context.SaveChanges();
		}

		public void UpdElement(StudyGroupBindingModel model)
		{
			StudyGroup element = context.StudyGroups.FirstOrDefault
			(rec => rec.Title == model.Title && rec.Id != model.Id);

			if (element != null)
			{
				throw new Exception("Уже есть такая группа");
			}

			element = context.StudyGroups.FirstOrDefault(rec => rec.Id == model.Id);

			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}

			GetModel(model, element);

			context.SaveChanges();
		}

		public void DelElement(Guid id)
		{
			StudyGroup element = context.StudyGroups.FirstOrDefault(rec => rec.Id == id);

			if (element != null)
			{
				context.StudyGroups.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}

		private static StudyGroup GetModel(StudyGroupBindingModel model, StudyGroup element = null)
		{
			if (model == null) return null;
			if (element == null) element = new StudyGroup { Id = Guid.NewGuid() };

			element.Title = model.Title;
			element.SpecialtyId = model.SpecialtyId;
			element.TypeEducation = model.TypeEducation;
			element.FormEducation = model.FormEducation;
			element.Course = model.Course;
			element.GroupNumber = model.GroupNumber;
			element.NumderStudents = model.NumderStudents;
			element.NumderSubgroups = model.NumderSubgroups;

			return element;
		}

		private static StudyGroupViewModel GetViewModel(StudyGroup element)
		{
			if (element == null) return null;
			return new StudyGroupViewModel
			{
				Id = element.Id,
				Title = element.Title,
				SpecialtyId = element.SpecialtyId,
				SpecialtyTitle = element.Specialty.Title,
				TypeEducation = element.TypeEducation,
				FormEducation = element.FormEducation,
				GroupNumber = element.GroupNumber,
				Course = element.Course,
				NumderStudents = element.NumderStudents,
				NumderSubgroups = element.NumderSubgroups
			};

		}
	}
}