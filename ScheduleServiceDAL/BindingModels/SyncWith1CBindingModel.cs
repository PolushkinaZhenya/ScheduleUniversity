namespace ScheduleServiceDAL.BindingModels
{
	public class SyncWith1CBindingModel
	{
		/// <summary>
		/// Адрес сервера
		/// </summary>
		public string BaseAddress { get; set; }

		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Кафедры
		/// </summary>
		public (bool Sync, bool Full) UniverStructure { get; set; }

		/// <summary>
		/// Аудитории и корпуса
		/// </summary>
		public (bool Sync, bool Full) AuditoriumStructure { get; set; }

		/// <summary>
		/// Учебные группы
		/// </summary>
		public (bool Sync, bool Full) Groups { get; set; }

		/// <summary>
		/// Учебные планы
		/// </summary>
		public (bool Sync, bool Full) StudyPlan { get; set; }

		/// <summary>
		/// Расчасовки
		/// </summary>
		public (bool Sync, bool Full) Chart { get; set; }
	}
}