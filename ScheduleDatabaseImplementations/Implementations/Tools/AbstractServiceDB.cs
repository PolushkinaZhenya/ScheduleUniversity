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
	public abstract class AbstractServiceDB<B, V, S, T> : IBaseService<B, V, S>
		where B : BaseBindingModel
		where V : BaseViewModel
		where S : BaseSearchModel
		where T : BaseEntity, new()
	{
		protected ScheduleDbContext _context;

		public List<V> GetList()
		{
			var query = _context.Set<T>().AsQueryable();
			query = Ordering(query);
			query = Including(query);
			return query.Select(GetViewModel).ToList();
		}

		public List<V> GetList(S model)
		{
			var query = _context.Set<T>().AsQueryable();
			query = FilteringList(query, model);
			query = Ordering(query);
			query = Including(query);
			return query.Select(GetViewModel).ToList();
		}

		public V GetElement(S model)
		{
			var element = FilteringSingle(Including(_context.Set<T>().AsQueryable()), model);
			if (element != null)
			{
				return GetViewModel(element);
			}
			throw new Exception("Элемент не найден");
		}

		public void AddElement(B model)
		{
			var element = _context.Set<T>().FirstOrDefault(AdditionalCheckingWhenAdding(model));
			if (element != null)
			{
				throw new Exception("Уже есть такая запись");
			}
			_context.Set<T>().Add(GetModel(model));
			_context.SaveChanges();
		}

		public void UpdElement(B model)
		{
			using var transaction = _context.Database.BeginTransaction();
			try
			{
				var element = _context.Set<T>().FirstOrDefault(AdditionalCheckingWhenUpdateing(model));
				if (element != null)
				{
					throw new Exception("Уже есть такая запись");
				}

				element = _context.Set<T>().FirstOrDefault(rec => rec.Id == model.Id);
				if (element == null)
				{
					throw new Exception("Элемент не найден");
				}

				GetModel(model, element);
				_context.SaveChanges();

				AdditionalActionsOnUpdate(model, element);

				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

		public void DelElement(S model)
		{
			var query = GetListForDelete(Including(_context.Set<T>().AsQueryable()), model);
			if (query != null)
			{
				_context.Set<T>().RemoveRange(query);
				_context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}

		/// <summary>
		/// Установка сортировок при получении списка
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		protected abstract IQueryable<T> Ordering(IQueryable<T> query);

		/// <summary>
		/// Добавление Include
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		protected abstract IQueryable<T> Including(IQueryable<T> query);

		/// <summary>
		/// Добавление дополнительных фильтров
		/// </summary>
		/// <param name="query"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		protected abstract IQueryable<T> FilteringList(IQueryable<T> query, S model);

		/// <summary>
		/// Добавление дополнительных фильтров
		/// </summary>
		/// <param name="query"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		protected abstract T FilteringSingle(IQueryable<T> query, S model);

		/// <summary>
		/// Возможные дополнительные проверки при добавлении
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		protected abstract Func<T, bool> AdditionalCheckingWhenAdding(B model);

		/// <summary>
		/// Возможные дополнительные проверки модели при изменении
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		protected abstract Func<T, bool> AdditionalCheckingWhenUpdateing(B model);

		/// <summary>
		/// Возможные дополнительные проверки модели при изменении
		/// </summary>
		/// <param name="context"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		protected abstract IQueryable<T> GetListForDelete(IQueryable<T> query, S model);

		/// <summary>
		/// Преобразование модели-сущности в модель-представление
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		protected abstract V ConvertToViewModel(T entity);

		/// <summary>
		/// Преобразование модели-сущности в модель-представление
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		protected abstract T ConvertToEntityModel(B model, T element);

		/// <summary>
		/// Дополнительные действия при обновлении (например, синхронизация дочерних списков)
		/// </summary>
		/// <param name="model"></param>
		protected virtual void AdditionalActionsOnUpdate(B model, T element) { }

		private T GetModel(B model, T element = null)
		{
			if (model == null) return null;
			if (element == null) element = new T { Id = Guid.NewGuid() };

			return ConvertToEntityModel(model, element);
		}

		private V GetViewModel(T entity)
		{
			if (entity == null) return null;
			return ConvertToViewModel(entity);
		}
	}
}