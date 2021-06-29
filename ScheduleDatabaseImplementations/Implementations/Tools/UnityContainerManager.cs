using ScheduleBusinessLogic.Interfaces.Tools;
using System;
using Unity;
using Unity.Lifetime;

namespace ScheduleDatabaseImplementations.Implementations.Tools
{
	/// <summary>
	/// Работа с UnityContainer
	/// </summary>
	public class UnityContainerManager : IDependencyManager
	{
		private readonly IUnityContainer _unityContainer;

		public UnityContainerManager() => _unityContainer = new UnityContainer();

		public void RegisterType<T, U>() where U : T => _unityContainer.RegisterType<T, U>(new HierarchicalLifetimeManager());

		public void RegisterType<T>() => _unityContainer.RegisterType<T>(new HierarchicalLifetimeManager());

		public void RegisterInstance<T>(T obj) => _unityContainer.RegisterInstance(obj, InstanceLifetime.Singleton);

		public T Resolve<T>() => _unityContainer.Resolve<T>();

		public object Resolve(Type t) => _unityContainer.Resolve(t);
	}
}