﻿using System;

namespace ScheduleBusinessLogic.Interfaces
{
	/// <summary>
	/// Интерфейс установки зависмости между элементами
	/// </summary>
	public interface IDependencyManager
	{
		/// <summary>
		/// Добавление зависимости
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		void RegisterType<T, U>() where U : T;


		/// <summary>
		/// Добавление зависимости
		/// </summary>
		/// <typeparam name="T"></typeparam>
		void RegisterType<T>();

		/// <summary>
		/// Добавление объекта
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		void RegisterInstance<T>(T obj);

		/// <summary>
		/// Получение класса со всеми зависмостями
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		T Resolve<T>();

		/// <summary>
		/// Получение класса со всеми зависмостями
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		object Resolve(Type t);
	}
}