using ScheduleBusinessLogic.Interfaces.Tools;
using System;

namespace ScheduleView
{
	/// <summary>
	/// Менеджер для работы с зависимостями
	/// </summary>
	public class DependencyManager
	{
		private readonly IDependencyManager _dependencyManager;

		private static DependencyManager _manager;

		private static readonly object _locjObject = new object();

		private DependencyManager()
		{
			//_dependencyManager = new UnityContainerManager();
		}

		public static DependencyManager Instance { get { if (_manager == null) { lock (_locjObject) { _manager = new DependencyManager(); } } return _manager; } }

		/// <summary>
		/// Добавление зависимости
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		public void RegisterType<T, U>() where U : T => _dependencyManager.RegisterType<T, U>();


		/// <summary>
		/// Добавление зависимости
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public void RegisterType<T>() => _dependencyManager.RegisterType<T>();

		/// <summary>
		/// Получение класса со всеми зависмостями
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T Resolve<T>() => _dependencyManager.Resolve<T>();

		/// <summary>
		/// Получение класса со всеми зависмостями
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public object Resolve(Type t) => _dependencyManager.Resolve(t);
	}
}