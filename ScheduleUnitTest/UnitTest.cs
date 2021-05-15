using NUnit.Framework;
using ScheduleImplementations.Implementations;
using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using ScheduleUnitTest;
using System;
using System.Collections.Generic;
using Unity;

namespace Tests
{
    public class Tests
    {
        private ILoadTeacherService serviceLT;

        private IScheduleService serviceS;

        List<LoadTeacherPeriodBindingModel> LoadTeacherPeriods;

        List<LoadTeacherAuditoriumBindingModel> LoadTeacherAuditoriums;

        Guid id_loadteacher;

        Guid id_loadteacherperiod;

        Guid id_loadteacherauditorium;

        [SetUp]
        public void Setup()
        {
            serviceLT = UnityConfig.Container.Resolve<LoadTeacherServiceDB>();

            serviceS = UnityConfig.Container.Resolve<ScheduleServiceDB>();

            LoadTeacherPeriods = new List<LoadTeacherPeriodBindingModel>();

            LoadTeacherAuditoriums = new List<LoadTeacherAuditoriumBindingModel>();

            id_loadteacher = Guid.NewGuid();

            id_loadteacherperiod = Guid.NewGuid();

            id_loadteacherauditorium = Guid.NewGuid();
        }

        [Test]
        public void TestAddLoadTeacher() //добавление расчасовки
        {
            LoadTeacherPeriods.Add(new LoadTeacherPeriodBindingModel
            {
                Id = id_loadteacherperiod,
                LoadTeacherId = id_loadteacher,
                PeriodId = new Guid("f668a6db-8e4d-42e5-af9c-40b616e7c411"),
                TotalHours = 128,
                HoursFirstWeek = 128 / 4,
                HoursSecondWeek = 0
            });

            LoadTeacherAuditoriums.Add(new LoadTeacherAuditoriumBindingModel
            {
                Id = id_loadteacherauditorium,
                LoadTeacherId = id_loadteacher,
                AuditoriumId = new Guid("1ccd1898-d39a-45f2-8de8-a3e4d565b3d5")
            });

            LoadTeacherBindingModel loadTeacherBindingModel = new LoadTeacherBindingModel
            {
                Id = id_loadteacher,
                DisciplineId = new Guid("622dd099-aed1-4cf5-b436-0ff9bba4eea8"),
                TypeOfClassId = new Guid("97a57bc1-065a-454d-9e86-8f3b8b0cb96e"),
                TeacherId = new Guid("c07f0324-2163-4b84-8f9b-b0293c1ef62c"),
                FlowId = new Guid("252f5629-f91a-4262-aa64-9666d6a9abab"),
                LoadTeacherPeriods = LoadTeacherPeriods,
                LoadTeacherAuditoriums = LoadTeacherAuditoriums,
                Reporting = "",
                NumberOfSubgroups = null
            };
            serviceLT.AddElement(loadTeacherBindingModel);

            LoadTeacherViewModel loadTeacherViewModel = serviceLT.GetElement(id_loadteacher);

            Assert.AreEqual(loadTeacherBindingModel.Id, loadTeacherViewModel.Id);

            serviceLT.DelElement(id_loadteacher);
        }

        [Test]
        public void TestAddSchedule() //добавление учебного зан€ти€
        {
            ScheduleBindingModel scheduleBindingModel = new ScheduleBindingModel
            {
                PeriodId = new Guid("f668a6db-8e4d-42e5-af9c-40b616e7c411"),
                NumberWeeks = 3,
                DayOfTheWeek = (DayOfTheWeek)1,
                Type = "“ест",
                ClassTimeId = null,
                StudyGroupId = null,
                Subgroups = null,
                AuditoriumId = null,
                LoadTeacherId = null,
                TeacherId = null
            };

            serviceS.AddElement(scheduleBindingModel);

            List<ScheduleViewModel> schedulelist = serviceS.GetListByPeriodAndWeek(new Guid("f668a6db-8e4d-42e5-af9c-40b616e7c411"), 3, "“ест");

            Assert.IsTrue(schedulelist.Count != 0);

            serviceS.DelElement(schedulelist[0].Id);
        }

        [Test]
        public void TestGetListSchedule() //получить нераспределенные учебные зан€ти€ группы
        {
            List<ScheduleViewModel> schedulelist = serviceS.GetListByPeroidAndStudyGroupEmpty(new Guid("f668a6db-8e4d-42e5-af9c-40b616e7c411"), new Guid("aad03990-89c3-4b3c-82c9-7a46686c755f"), "«ан€тие");

            Assert.IsTrue(schedulelist.Count != 0);
        }

        [Test]
        public void TestGetLoadTeacher() //получить расчасовку с временем за определенный период
        {
            LoadTeacherViewModel loadTeacher = serviceLT.GetElementWhitHoursByPeroid(new Guid("626656ba-8c8a-4f14-bb49-7c6005c57a41"), new Guid("f668a6db-8e4d-42e5-af9c-40b616e7c411"));

            Assert.IsTrue(loadTeacher.HoursFirstWeek != 0 && loadTeacher.HoursSecondWeek != 0);
        }

        [Test]
        public void TestUpdSchedule() //перенести "закрытую пару" преподавател€
        {
            ScheduleBindingModel model = new ScheduleBindingModel
            {
                Id = new Guid("86438a7d-ac80-4106-9ecc-d02f4e168a51"),
                PeriodId = new Guid("f668a6db-8e4d-42e5-af9c-40b616e7c411"),
                NumberWeeks = 2,
                DayOfTheWeek = (DayOfTheWeek)1,
                ClassTimeId = new Guid("84027273-e4ba-4606-aa15-8204e559558a"),
                StudyGroupId = null,
                Subgroups = null,
                AuditoriumId = null,
                LoadTeacherId = null,
                Type = "ѕреподаватель",
                TeacherId = new Guid("59885d16-4a12-4a4e-9a90-3b7dc0c2cdac")
            };
            serviceS.UpdElement(model);

            ScheduleViewModel schedule = serviceS.GetElementByDayAndClassTimeAndTeacherId(model.PeriodId, 2, 
                (DayOfTheWeek)model.DayOfTheWeek, (Guid)model.ClassTimeId, (Guid)model.TeacherId, model.Type);

            Assert.IsTrue(schedule != null);
        } 
    }
}