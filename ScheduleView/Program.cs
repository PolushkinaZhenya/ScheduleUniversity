﻿using ScheduleImplementations.Implementations;
using ScheduleServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ScheduleView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<ITypeOfAudienceService, TypeOfAudienceServiceDB>
                (new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITypeOfDepartmentService, TypeOfDepartmentServiceDB>
                (new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDepartmentService, DepartmentServiceDB>
                (new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
