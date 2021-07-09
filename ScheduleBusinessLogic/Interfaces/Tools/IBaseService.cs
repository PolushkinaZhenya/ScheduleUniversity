using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
{
	public interface IBaseService<B, V, S>
        where B : BaseBindingModel
        where V : BaseViewModel
        where S : BaseSearchModel
    {
        /// <summary>
        /// Получение полного списка из хранилища
        /// </summary>
        /// <returns></returns>
        List<V> GetList();

        /// <summary>
        /// Получение фильтрованого списка из хранилища
        /// </summary>
        /// <param name="model">Поля для выборки</param>
        /// <returns></returns>
        List<V> GetList(S model);

        /// <summary>
        /// Получение записи из хранилища
        /// </summary>
        /// <param name="model">Поля для выборки</param>
        /// <returns></returns>
        V GetElement(S model);

        /// <summary>
        /// Добавление записи в ханиилище
        /// </summary>
        /// <param name="model"></param>
        void AddElement(B model);

        /// <summary>
        /// Изменение записи из хранилища
        /// </summary>
        /// <param name="model"></param>
        void UpdElement(B model);

        /// <summary>
        /// Удаление записи в хранилище
        /// </summary>
        /// <param name="model"></param>
        void DelElement(S model);
    }
}