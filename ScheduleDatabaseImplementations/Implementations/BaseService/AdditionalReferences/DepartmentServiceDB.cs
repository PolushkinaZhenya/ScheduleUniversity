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
	public class DepartmentServiceDB : AbstractServiceDB<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel, Department>,
		IBaseService<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel>
	{
		public DepartmentServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<Department> Ordering(IQueryable<Department> query) =>
			query.OrderBy(x => x.TypeOfDepartment.Title).ThenBy(x => x.Title);

		protected override IQueryable<Department> Including(IQueryable<Department> query) =>
			query.Include(x => x.TypeOfDepartment);

		protected override IQueryable<Department> FilteringList(IQueryable<Department> query, DepartmentSearchModel model)
		{
			if (model.Title.IsNotEmpty())
			{
				query = query.Where(x => x.Title.Contains(model.Title));
			}
			if (model.TypeOfDepartmentId.HasValue)
			{
				query = query.Where(x => x.TypeOfDepartmentId == model.TypeOfDepartmentId.Value);
			}

			return query;
		}

		protected override Department FilteringSingle(IQueryable<Department> query, DepartmentSearchModel model)
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

		protected override Func<Department, bool> AdditionalCheckingWhenAdding(DepartmentBindingModel model) =>
			x => x.Title == model.Title;

		protected override Func<Department, bool> AdditionalCheckingWhenUpdateing(DepartmentBindingModel model) =>
			x => x.Title == model.Title && x.Id != model.Id;

		protected override IQueryable<Department> GetListForDelete(IQueryable<Department> query, DepartmentSearchModel model)
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

		protected override DepartmentViewModel ConvertToViewModel(Department entity) =>
			new()
			{
				Id = entity.Id,
				Title = entity.Title,
				TypeOfDepartmentId = entity.TypeOfDepartmentId,
				TypeOfDepartment = entity.TypeOfDepartment?.Title
			};

		protected override Department ConvertToEntityModel(DepartmentBindingModel model, Department element)
		{
			element.Title = model.Title;
			element.TypeOfDepartmentId = model.TypeOfDepartmentId;

			return element;
		}
	}
}