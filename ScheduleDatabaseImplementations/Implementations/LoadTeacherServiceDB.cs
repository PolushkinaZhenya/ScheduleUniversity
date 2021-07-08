using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class LoadTeacherServiceDB : ILoadTeacherService
    {
        private readonly ScheduleDbContext context;

        public LoadTeacherServiceDB(ScheduleDbContext context)
        {
            this.context = context;
        }

        public List<LoadTeacherViewModel> GetList()
        {
            List<LoadTeacherViewModel> result = context.LoadTeachers.Select
                (rec => new LoadTeacherViewModel
                {
                    Id = rec.Id,
                    DisciplineId = rec.DisciplineId,
                    DisciplineTitle = rec.Discipline.Title,
                    TypeOfClassId = rec.TypeOfClassId,
                    TypeOfClassTitle = rec.TypeOfClass.Title,
                    TeacherId = rec.TeacherId,
                    TeacherSurname = rec.Teacher.Surname,
                    FlowId = rec.FlowId,
                    FlowTitle = rec.Flow.Title,
                    Reporting = rec.Reporting,
                    NumberOfSubgroups = rec.NumberOfSubgroups,

                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == rec.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        TotalHours = recLTP.TotalHours,
                        HoursFirstWeek = recLTP.HoursFirstWeek,
                        HoursSecondWeek = recLTP.HoursSecondWeek
                    }).ToList(),

                    LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == rec.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number,
                        Priority = recLTA.Priority
                    }).OrderBy(reco => reco.Priority).ToList()

                }).OrderBy(reco => reco.DisciplineTitle)
                .ToList();

            return result;
        }

        public List<LoadTeacherViewModel> GetListByTypeAndStudyGroupAndPeriod(string Type, Guid StudyGroupId, Guid PeriodId)
        {
            Guid TypeId = context.TypeOfClasses.Where(rec => rec.AbbreviatedTitle == Type).Select(rec => rec.Id).FirstOrDefault();

            List<Guid> FlowIds = context.FlowStudyGroups.Where(rec => rec.StudyGroupId == StudyGroupId).Select(rec => rec.FlowId).ToList();

            List<LoadTeacherViewModel> resultType = context.LoadTeachers
            .Where(recLT => recLT.TypeOfClassId == TypeId)
            .Select(rec => new LoadTeacherViewModel
            {
                Id = rec.Id,
                DisciplineTitle = rec.Discipline.Title,
                TypeOfClassTitle = rec.TypeOfClass.Title,
                TeacherSurname = rec.Teacher.Surname + " " + rec.Teacher.Name.Substring(0, 1) + " " + rec.Teacher.Patronymic.Substring(0, 1),
                FlowId = rec.FlowId,
                FlowTitle = rec.Flow.Title,
                Reporting = rec.Reporting,
                NumberOfSubgroups = rec.NumberOfSubgroups,

                LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == rec.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        TotalHours = recLTP.TotalHours,
                        HoursFirstWeek = recLTP.HoursFirstWeek,
                        HoursSecondWeek = recLTP.HoursSecondWeek
                    }).ToList(),

                TotalHours = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == rec.Id))
                    .Select(recLTP => recLTP.TotalHours
                    ).FirstOrDefault(),

                HoursFirstWeek = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == rec.Id))
                    .Select(recLTP => recLTP.HoursFirstWeek
                    ).FirstOrDefault(),

                HoursSecondWeek = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == rec.Id))
                    .Select(recLTP => recLTP.HoursSecondWeek
                    ).FirstOrDefault(),

                LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == rec.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number,
                        Priority = recLTA.Priority
                    }).OrderBy(reco => reco.Priority).ToList()
            }).ToList();

            List<LoadTeacherViewModel> result = new List<LoadTeacherViewModel>();

            for (int i = 0; i < FlowIds.Count; i++)
            {
                List<LoadTeacherViewModel> resultLocal = resultType
                .Where(recLT => recLT.FlowId == FlowIds[i])
                .Select
                (rec => new LoadTeacherViewModel
                {
                    Id = rec.Id,
                    DisciplineTitle = rec.DisciplineTitle,
                    TypeOfClassTitle = rec.TypeOfClassTitle,
                    TeacherSurname = rec.TeacherSurname,
                    FlowId = rec.FlowId,
                    FlowTitle = rec.FlowTitle,
                    Reporting = rec.Reporting,
                    NumberOfSubgroups = rec.NumberOfSubgroups,

                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == rec.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        TotalHours = recLTP.TotalHours,
                        HoursFirstWeek = recLTP.HoursFirstWeek,
                        HoursSecondWeek = recLTP.HoursSecondWeek
                    }).ToList(),

                    TotalHours = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == rec.Id))
                    .Select(recLTP => recLTP.TotalHours
                    ).FirstOrDefault(),

                    HoursFirstWeek = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == rec.Id))
                    .Select(recLTP => recLTP.HoursFirstWeek
                    ).FirstOrDefault(),

                    HoursSecondWeek = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == rec.Id))
                    .Select(recLTP => recLTP.HoursSecondWeek
                    ).FirstOrDefault(),

                    LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == rec.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number,
                        Priority = recLTA.Priority
                    }).ToList()

                }).OrderBy(reco => reco.DisciplineTitle)
                .ToList();

                result = result.Concat(resultLocal).OrderBy(reco => reco.DisciplineTitle).ToList();
            }
            return result;
        }

        public LoadTeacherViewModel GetElement(Guid? id)
        {
            LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new LoadTeacherViewModel
                {
                    Id = element.Id,

                    DisciplineId = element.DisciplineId,
                    DisciplineTitle = context.Disciplines
                    .Where(rec => rec.Id == element.DisciplineId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TypeOfClassId = element.TypeOfClassId,
                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(rec => rec.Id == element.TypeOfClassId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TeacherId = element.TeacherId,
                    TeacherSurname = context.Teachers
                    .Where(rec => rec.Id == element.TeacherId)
                    .Select(rec => rec.Surname).FirstOrDefault(),

                    FlowId = element.FlowId,
                    FlowTitle = context.Flows
                    .Where(rec => rec.Id == element.FlowId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    Reporting = element.Reporting,
                    NumberOfSubgroups = element.NumberOfSubgroups,

                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == element.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        TotalHours = recLTP.TotalHours,
                        HoursFirstWeek = recLTP.HoursFirstWeek,
                        HoursSecondWeek = recLTP.HoursSecondWeek
                    }).ToList(),

                    LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == element.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number,
                        Priority = recLTA.Priority
                    }).OrderBy(reco => reco.Priority)
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        //расчасовка с временем за период
        public LoadTeacherViewModel GetElementWhitHoursByPeroid(Guid id, Guid PeriodId)
        {
            LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new LoadTeacherViewModel
                {
                    Id = element.Id,

                    DisciplineId = element.DisciplineId,
                    DisciplineTitle = context.Disciplines
                    .Where(rec => rec.Id == element.DisciplineId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TypeOfClassId = element.TypeOfClassId,
                    TypeOfClassTitle = context.TypeOfClasses
                    .Where(rec => rec.Id == element.TypeOfClassId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    TeacherId = element.TeacherId,
                    TeacherSurname = context.Teachers
                    .Where(rec => rec.Id == element.TeacherId)
                    .Select(rec => rec.Surname).FirstOrDefault(),

                    FlowId = element.FlowId,
                    FlowTitle = context.Flows
                    .Where(rec => rec.Id == element.FlowId)
                    .Select(rec => rec.Title).FirstOrDefault(),

                    Reporting = element.Reporting,
                    NumberOfSubgroups = element.NumberOfSubgroups,

                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == element.Id)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        TotalHours = recLTP.TotalHours,
                        HoursFirstWeek = recLTP.HoursFirstWeek,
                        HoursSecondWeek = recLTP.HoursSecondWeek
                    }).ToList(),

                    LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == element.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number,
                        Priority = recLTA.Priority
                    }).OrderBy(reco => reco.Priority).ToList(),

                    HoursFirstWeek = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == element.Id))
                    .Select(recLTP => recLTP.HoursFirstWeek
                    ).FirstOrDefault(),

                    HoursSecondWeek = context.LoadTeacherPeriods
                    .Where(recLTP => (recLTP.PeriodId == PeriodId) && (recLTP.LoadTeacherId == element.Id))
                    .Select(recLTP => recLTP.HoursSecondWeek
                    ).FirstOrDefault(),
                };
            }
            throw new Exception("Элемент не найден");
        }

        //обновленный период расчасовки
        public LoadTeacherPeriodViewModel GetLoadTeacherPeriodNew(Guid LoadTeacherId, Guid PeriodId)
        {
            LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == LoadTeacherId);

            if (element != null)
            {
                LoadTeacherViewModel l = new LoadTeacherViewModel
                {
                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == LoadTeacherId && recLTP.PeriodId == PeriodId)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        TotalHours = recLTP.TotalHours,
                        HoursFirstWeek = recLTP.HoursFirstWeek,
                        HoursSecondWeek = recLTP.HoursSecondWeek
                    }).ToList(),
                };
                return l.LoadTeacherPeriods.FirstOrDefault();
            }
            throw new Exception("Элемент не найден");
        }

        //все периоды расчасовки без обновленного периода
        public List<LoadTeacherPeriodViewModel> GetLoadTeacherPeriodOld(Guid LoadTeacherId, Guid PeriodId)
        {
            LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == LoadTeacherId);

            if (element != null)
            {
                LoadTeacherViewModel l = new LoadTeacherViewModel
                {
                    LoadTeacherPeriods = context.LoadTeacherPeriods
                    .Where(recLTP => recLTP.LoadTeacherId == LoadTeacherId && recLTP.PeriodId != PeriodId)
                    .Select(recLTP => new LoadTeacherPeriodViewModel
                    {
                        Id = recLTP.Id,
                        LoadTeacherId = recLTP.LoadTeacherId,
                        PeriodId = recLTP.PeriodId,
                        PeriodTitle = recLTP.Period.Title,
                        TotalHours = recLTP.TotalHours,
                        HoursFirstWeek = recLTP.HoursFirstWeek,
                        HoursSecondWeek = recLTP.HoursSecondWeek
                    }).ToList(),
                };
                return l.LoadTeacherPeriods;
            }
            throw new Exception("Элемент не найден");
        }

        public List<LoadTeacherAuditoriumViewModel> GetLoadTeacherAuditorium(Guid LoadTeacherId)
        {
            LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == LoadTeacherId);

            if (element != null)
            {
                LoadTeacherViewModel l = new LoadTeacherViewModel
                {
                    LoadTeacherAuditoriums = context.LoadTeacherAuditoriums
                    .Where(recLTA => recLTA.LoadTeacherId == element.Id)
                    .Select(recLTA => new LoadTeacherAuditoriumViewModel
                    {
                        Id = recLTA.Id,
                        LoadTeacherId = recLTA.LoadTeacherId,
                        AuditoriumId = recLTA.AuditoriumId,
                        AuditoriumTitle = recLTA.Auditorium.Number,
                        Priority = recLTA.Priority
                    }).ToList(),
                };

                return l.LoadTeacherAuditoriums.ToList();
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(LoadTeacherBindingModel model)
        {
			using var transaction = context.Database.BeginTransaction();
			try
			{
				List<LoadTeacherViewModel> loadteacher = GetList();
				for (int i = 0; i < loadteacher.Count; i++)
				{
					for (int j = 0; j < loadteacher[i].LoadTeacherPeriods.Count; j++)
					{
						for (int k = 0; k < model.LoadTeacherPeriods.Count; k++)
						{
							if (loadteacher[i].LoadTeacherPeriods[j].PeriodId == model.LoadTeacherPeriods[k].PeriodId
								&& loadteacher[i].DisciplineId == model.DisciplineId
								&& loadteacher[i].TypeOfClassId == model.TypeOfClassId
								&& loadteacher[i].FlowId == model.FlowId
								)
							{
								throw new Exception("Уже есть такая расчасовка");
							}
						}
					}
				}

				LoadTeacher element = new LoadTeacher
				{
					Id = model.Id,
					DisciplineId = model.DisciplineId,
					TypeOfClassId = model.TypeOfClassId,
					TeacherId = model.TeacherId,
					FlowId = model.FlowId,

					Reporting = model.Reporting,
					NumberOfSubgroups = model.NumberOfSubgroups
				};
				context.LoadTeachers.Add(element);
				context.SaveChanges();

				// убираем дубли 
				var periods = model.LoadTeacherPeriods;

				// добавляем периоды 
				foreach (var period in periods)
				{
					context.LoadTeacherPeriods.Add(new LoadTeacherPeriod
					{
						Id = Guid.NewGuid(),//???
						LoadTeacherId = element.Id,
						PeriodId = period.PeriodId,
						TotalHours = period.TotalHours,
						HoursFirstWeek = period.HoursFirstWeek,
						HoursSecondWeek = period.HoursSecondWeek
					});
					context.SaveChanges();
				}

				// убираем дубли 
				var auditoriums = model.LoadTeacherAuditoriums;

				// добавляем аудитории 
				int priority = 1;
				foreach (var auditorium in auditoriums)
				{
					context.LoadTeacherAuditoriums.Add(new LoadTeacherAuditorium
					{
						Id = Guid.NewGuid(),//???
						LoadTeacherId = element.Id,
						AuditoriumId = auditorium.AuditoriumId,
						Priority = priority
					});
					context.SaveChanges();

					priority++;
				}
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

        public void UpdElement(LoadTeacherBindingModel model)
        {
			using var transaction = context.Database.BeginTransaction();
			try
			{
				List<LoadTeacherViewModel> loadteacher = GetList();
				for (int i = 0; i < loadteacher.Count; i++)
				{
					for (int j = 0; j < loadteacher[i].LoadTeacherPeriods.Count; j++)
					{
						for (int k = 0; k < model.LoadTeacherPeriods.Count; k++)
						{
							if (loadteacher[i].Id != model.Id &&
								loadteacher[i].LoadTeacherPeriods[j].PeriodId == model.LoadTeacherPeriods[k].PeriodId
								&& loadteacher[i].DisciplineId == model.DisciplineId
								&& loadteacher[i].TypeOfClassId == model.TypeOfClassId
								&& loadteacher[i].FlowId == model.FlowId
								)
							{
								throw new Exception("Уже есть такая расчасовка");
							}
						}
					}
				}

				LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == model.Id);
				if (element == null)
				{
					throw new Exception("Элемент не найден");
				}
				element.DisciplineId = model.DisciplineId;
				element.TypeOfClassId = model.TypeOfClassId;
				element.TeacherId = model.TeacherId;
				element.FlowId = model.FlowId;

				element.Reporting = model.Reporting;
				element.NumberOfSubgroups = model.NumberOfSubgroups;

				context.SaveChanges();

				// обновляем существуюущие компоненты 
				var periodIds = model.LoadTeacherPeriods.Select(rec => rec.PeriodId).Distinct();

				var updatePeriods = context.LoadTeacherPeriods
					.Where(rec => rec.LoadTeacherId == model.Id && periodIds.Contains(rec.PeriodId));

				context.SaveChanges();
				context.LoadTeacherPeriods.RemoveRange(context.LoadTeacherPeriods.Where(rec => rec.LoadTeacherId == model.Id && !periodIds.Contains(rec.PeriodId)));
				context.SaveChanges();

				// новые записи  
				var periods = model.LoadTeacherPeriods;

				foreach (var period in periods)
				{
					LoadTeacherPeriod elementLTP = context.LoadTeacherPeriods
						.FirstOrDefault(rec => rec.LoadTeacherId == model.Id && rec.PeriodId == period.PeriodId);

					if (elementLTP != null)
					{
						elementLTP.TotalHours = period.TotalHours;
						elementLTP.HoursFirstWeek = period.HoursFirstWeek;
						elementLTP.HoursSecondWeek = period.HoursSecondWeek;
						//elementPC.Count += groupPart.Count;
						context.SaveChanges();
					}
					else
					{
						context.LoadTeacherPeriods.Add(new LoadTeacherPeriod
						{
							Id = Guid.NewGuid(),//???
							LoadTeacherId = model.Id,
							PeriodId = period.PeriodId,
							TotalHours = period.TotalHours,
							HoursFirstWeek = period.HoursFirstWeek,
							HoursSecondWeek = period.HoursSecondWeek
						});
						context.SaveChanges();
					}
				}


				// обновляем существуюущие компоненты 
				var auditoriumIds = model.LoadTeacherAuditoriums.Select(rec => rec.AuditoriumId).Distinct();

				var updateAuditoriums = context.LoadTeacherAuditoriums
					.Where(rec => rec.LoadTeacherId == model.Id && auditoriumIds.Contains(rec.AuditoriumId));

				context.SaveChanges();
				context.LoadTeacherAuditoriums.RemoveRange(context.LoadTeacherAuditoriums.Where(rec => rec.LoadTeacherId == model.Id && !auditoriumIds.Contains(rec.AuditoriumId)));
				context.SaveChanges();

				// новые записи  
				var auditoriums = model.LoadTeacherAuditoriums;

				int priority = 1;
				foreach (var auditorium in auditoriums)
				{
					LoadTeacherAuditorium elementLTA = context.LoadTeacherAuditoriums
						.FirstOrDefault(rec => rec.LoadTeacherId == model.Id && rec.AuditoriumId == auditorium.AuditoriumId);

					if (elementLTA != null)
					{
						elementLTA.Priority = priority;
						context.SaveChanges();
					}
					else
					{
						context.LoadTeacherAuditoriums.Add(new LoadTeacherAuditorium
						{
							Id = Guid.NewGuid(),//???
							LoadTeacherId = model.Id,
							AuditoriumId = auditorium.AuditoriumId,
							Priority = priority
						});
						context.SaveChanges();

					}

					priority++;
				}
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

        public void DelElement(Guid id)
        {
			using var transaction = context.Database.BeginTransaction();
			try
			{
				LoadTeacher element = context.LoadTeachers.FirstOrDefault(rec => rec.Id == id);
				if (element != null)
				{
					// удаяем записи по периодам, аудиториям и занятиям при удалении расчасовки
					context.LoadTeacherPeriods.RemoveRange(context.LoadTeacherPeriods.Where(rec => rec.LoadTeacherId == id));
					context.LoadTeacherAuditoriums.RemoveRange(context.LoadTeacherAuditoriums.Where(rec => rec.LoadTeacherId == id));
					context.Schedules.RemoveRange(context.Schedules.Where(rec => rec.LoadTeacherId == id));
					context.LoadTeachers.Remove(element);
					context.SaveChanges();
				}
				else
				{
					throw new Exception("Элемент не найден");
				}
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}
    }
}