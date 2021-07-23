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
	public class HourOfSemesterServiceDB : AbstractServiceDB<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel, HourOfSemester>,
		IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel>
	{
		public HourOfSemesterServiceDB(DbContextOptions<ScheduleDbContext> options) : base(options) { }

		protected override IQueryable<HourOfSemester> Ordering(IQueryable<HourOfSemester> query) =>
			query.OrderBy(x => x.Semester.Title).ThenBy(x => x.Discipline.Title).ThenBy(x => x.StudyGroup.Title);

		protected override IQueryable<HourOfSemester> Including(IQueryable<HourOfSemester> query) =>
			query.Include(x => x.Semester).Include(x => x.Discipline).Include(x => x.StudyGroup)
			.Include(x => x.HourOfSemesterRecords).Include("HourOfSemesterRecords.TypeOfClass").Include("HourOfSemesterRecords.Teacher")
			.Include("HourOfSemesterRecords.Flow").Include("HourOfSemesterRecords.Flow.FlowStudyGroups").Include("HourOfSemesterRecords.Flow.FlowStudyGroups.StudyGroup")
			.Include("HourOfSemesterRecords.HourOfSemesterAuditoriums").Include("HourOfSemesterRecords.HourOfSemesterAuditoriums.Auditorium")
			.Include("HourOfSemesterRecords.HourOfSemesterPeriods").Include("HourOfSemesterRecords.HourOfSemesterPeriods.Period");

		protected override IQueryable<HourOfSemester> FilteringList(IQueryable<HourOfSemester> query, HourOfSemesterSearchModel model)
		{
			if (model.AuditoriumId.HasValue)
			{
				query = query.Where(x => x.HourOfSemesterRecords.Any(y => y.HourOfSemesterAuditoriums.Any(z => z.AuditoriumId == model.AuditoriumId.Value)));
			}
			if (model.DisciplineId.HasValue)
			{
				query = query.Where(x => x.DisciplineId == model.DisciplineId.Value);
			}
			if (model.Reporting.IsNotEmpty())
			{
				query = query.Where(x => x.Reporting.Contains(model.Reporting));
			}
			if (model.SemesterId.HasValue)
			{
				query = query.Where(x => x.SemesterId == model.SemesterId.Value);
			}
			if (model.PeriodId.HasValue)
			{
				query = query.Where(x => x.HourOfSemesterRecords.Any(y => y.HourOfSemesterPeriods.Any(z => z.PeriodId == model.PeriodId.Value)));
			}
			if (model.StudyGroupId.HasValue)
			{
				query = query.Where(x => x.StudyGroupId == model.StudyGroupId.Value);
			}
			if (model.TeacherId.HasValue)
			{
				query = query.Where(x => x.HourOfSemesterRecords.Any(y => y.TeacherId == model.TeacherId.Value));
			}
			if (model.TypeOfClassId.HasValue)
			{
				query = query.Where(x => x.HourOfSemesterRecords.Any(y => y.TypeOfClassId == model.TypeOfClassId.Value));
			}
			if (model.Wishes.IsNotEmpty())
			{
				query = query.Where(x => x.Wishes.Contains(model.Wishes));
			}

			return query;
		}

		protected override HourOfSemester FilteringSingle(IQueryable<HourOfSemester> query, HourOfSemesterSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}

			return query?.FirstOrDefault();
		}

		protected override Func<HourOfSemester, bool> AdditionalCheckingWhenAdding(HourOfSemesterBindingModel model) =>
			x => x.DisciplineId == model.DisciplineId && x.SemesterId == model.SemesterId && x.StudyGroupId == model.StudyGroupId;

		protected override Func<HourOfSemester, bool> AdditionalCheckingWhenUpdateing(HourOfSemesterBindingModel model) =>
			x => x.DisciplineId == model.DisciplineId && x.SemesterId == model.SemesterId && x.StudyGroupId == model.StudyGroupId && x.Id != model.Id;

		protected override IQueryable<HourOfSemester> GetListForDelete(IQueryable<HourOfSemester> query, HourOfSemesterSearchModel model)
		{
			if (model.Id.HasValue)
			{
				query = query.Where(x => x.Id == model.Id.Value);
			}
			if (model.AuditoriumId.HasValue)
			{
				query = query.Where(x => x.HourOfSemesterRecords.Any(y => y.HourOfSemesterAuditoriums.Any(z => z.AuditoriumId == model.AuditoriumId)));
			}
			if (model.DisciplineId.HasValue)
			{
				query = query.Where(x => x.DisciplineId == model.DisciplineId.Value);
			}
			if (model.SemesterId.HasValue)
			{
				query = query.Where(x => x.SemesterId == model.SemesterId.Value);
			}
			if (model.StudyGroupId.HasValue)
			{
				query = query.Where(x => x.StudyGroupId == model.StudyGroupId.Value);
			}
			if (model.TeacherId.HasValue)
			{
				query = query.Where(x => x.HourOfSemesterRecords.Any(y => y.TeacherId == model.TeacherId.Value));
			}

			return query;
		}

		protected override HourOfSemesterViewModel ConvertToViewModel(HourOfSemester entity) =>
			new()
			{
				Id = entity.Id,
				DisciplineId = entity.DisciplineId,
				DisciplineTitle = entity.Discipline?.Title,
				SemesterId = entity.SemesterId,
				SemesterTitle = entity.Semester?.Title,
				StudyGroupId = entity.StudyGroupId,
				StudyGroupTitle = entity.StudyGroup?.Title,
				Reporting = entity.Reporting,
				Wishes = entity.Wishes,
				HourOfSemesterRecords = entity.HourOfSemesterRecords.Select(x => new HourOfSemesterRecordViewModel
				{
					Id = x.Id,
					HourOfSemesterId = entity.Id,
					TeacherId = x.TeacherId,
					TeacherShortName = x.Teacher?.ShortName,
					TypeOfClassId = x.TypeOfClassId,
					TypeOfClassTitle = x.TypeOfClass?.Title,
					Order = x.TypeOfClass?.Priority ?? 0,
					TotalHours = x.TotalHours,
					SubgroupNumber = x.SubgroupNumber,
					FlowId = x.FlowId,
					FlowTitle = x.Flow?.Title,
					Flows = x.Flow?.FlowStudyGroups?.Select(x => x.StudyGroup?.Title).ToList(),
					HourOfSemesterAuditoriums = x.HourOfSemesterAuditoriums.Select(y => new HourOfSemesterAuditoriumViewModel
					{
						Id = y.Id,
						HourOfSemesterRecordId = x.Id,
						AuditoriumId = y.AuditoriumId,
						AuditoriumTitle = y.Auditorium?.Number,
						Priority = y.Priority
					}).ToList(),
					HourOfSemesterPeriods = x.HourOfSemesterPeriods.Select(y => new HourOfSemesterPeriodViewModel
					{
						Id = y.Id,
						HourOfSemesterRecordId = x.Id,
						PeriodId = y.PeriodId,
						PeriodTitle = y.Period?.Title,
						HoursFirstWeek = y.HoursFirstWeek,
						HoursSecondWeek = y.HoursSecondWeek
					}).ToList()
				}).OrderBy(x => x.Order).ToList()
			};

		protected override HourOfSemester ConvertToEntityModel(HourOfSemesterBindingModel model, HourOfSemester element)
		{
			element.DisciplineId = model.DisciplineId;
			element.SemesterId = model.SemesterId;
			element.StudyGroupId = model.StudyGroupId;
			element.Reporting = model.Reporting;
			element.Wishes = model.Wishes;

			return element;
		}

		protected override void AdditionalActionsOnAddition(ScheduleDbContext context, HourOfSemesterBindingModel model, HourOfSemester element)
		{
			base.AdditionalActionsOnAddition(context, model, element);

			SyncRecords(context, element, model);
		}

		protected override void AdditionalActionsOnUpdate(ScheduleDbContext context, HourOfSemesterBindingModel model, HourOfSemester element)
		{
			base.AdditionalActionsOnUpdate(context, model, element);

			SyncRecords(context, element, model);
		}

		private static HourOfSemesterRecord ConvertToHourOfSemesterRecord(HourOfSemesterRecordBindingModel model, HourOfSemesterRecord element, HourOfSemester hos)
		{
			if (model == null) return null;
			if (element == null) element = new HourOfSemesterRecord { Id = Guid.NewGuid() };
			element.HourOfSemesterId = hos.Id;
			element.TeacherId = model.TeacherId;
			element.TypeOfClassId = model.TypeOfClassId;
			element.TotalHours = model.TotalHours;
			element.SubgroupNumber = model.SubgroupNumber;
			element.FlowId = model.FlowId;

			return element;
		}

		private static HourOfSemesterAuditorium ConvertToHourOfSemesterAuditorium(HourOfSemesterAuditoriumBindingModel model, HourOfSemesterAuditorium element, HourOfSemesterRecord hosr)
		{
			if (model == null) return null;
			if (element == null) element = new HourOfSemesterAuditorium { Id = Guid.NewGuid() };
			element.HourOfSemesterRecordId = hosr.Id;
			element.AuditoriumId = model.AuditoriumId;
			element.Priority = model.Priority;

			return element;
		}

		private static HourOfSemesterPeriod ConvertToHourOfSemesterPeriod(HourOfSemesterPeriodBindingModel model, HourOfSemesterPeriod element, HourOfSemesterRecord hosr)
		{
			if (model == null) return null;
			if (element == null) element = new HourOfSemesterPeriod { Id = Guid.NewGuid() };
			element.HourOfSemesterRecordId = hosr.Id;
			element.PeriodId = model.PeriodId;
			element.HoursFirstWeek = model.HoursFirstWeek;
			element.HoursSecondWeek = model.HoursSecondWeek;

			return element;
		}

		private void SyncRecords(ScheduleDbContext context, HourOfSemester hos, HourOfSemesterBindingModel model)
		{
			var records = context.HourOfSemesterRecords.Where(x => x.HourOfSemesterId == hos.Id).ToList();
			foreach (var record in model.HourOfSemesterRecords)
			{
				var rec = records.FirstOrDefault(x => x.TypeOfClassId == record.TypeOfClassId && x.SubgroupNumber == record.SubgroupNumber
																											&& x.TeacherId == record.TeacherId);
				if (rec != null)
				{
					ConvertToHourOfSemesterRecord(record, rec, hos);
					context.SaveChanges();
					records.Remove(rec);
				}
				else
				{
					rec = ConvertToHourOfSemesterRecord(record, null, hos);
					context.HourOfSemesterRecords.Add(rec);
					context.SaveChanges();
				}

				SyncAuditoriums(context, rec, record);
				SyncPeriods(context, rec, record);
			}
			context.HourOfSemesterRecords.RemoveRange(records);
			context.SaveChanges();

			SyncFlows(context, model);
		}

		/// <summary>
		/// Синхронизация потока, если он есть
		/// </summary>
		/// <param name="model"></param>
		private void SyncFlows(ScheduleDbContext context, HourOfSemesterBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			// получаем его
			//вытаскиваем оттуда группу по которой идет добавление
			foreach (var record in model.HourOfSemesterRecords)
			{
				if (!record.FlowId.HasValue)
				{
					continue;
				}
				var flow = context.Flows.Include(x => x.FlowStudyGroups).FirstOrDefault(x => x.Id == record.FlowId);
				if (flow == null)
				{
					continue;
				}
				var group = flow.FlowStudyGroups.FirstOrDefault(x => x.StudyGroupId == model.StudyGroupId);
				// идем по остальным (под)группам потока
				foreach (var gr in flow.FlowStudyGroups.Where(x => x.StudyGroupId != model.StudyGroupId))
				{
					// проверяем, что у группы уже есть расчасовка по этой дисциплине
					var grelem = context.HourOfSemesters.FirstOrDefault(x => x.DisciplineId == model.DisciplineId
															&& x.SemesterId == model.SemesterId && x.StudyGroupId == gr.Id);
					// если нет, то создаем
					if (grelem == null)
					{
						grelem = ConvertToEntityModel(model, new HourOfSemester { Id = new Guid() });
						grelem.StudyGroupId = gr.StudyGroupId;
						context.HourOfSemesters.Add(grelem);
						context.SaveChanges();
					}
					// ищем запись расчасовки по этому типу занятий для этой подгруппы
					var recelem = context.HourOfSemesterRecords.FirstOrDefault(x => x.HourOfSemesterId == grelem.Id &&
												x.TypeOfClassId == record.TypeOfClassId && x.SubgroupNumber == record.SubgroupNumber &&
												x.TeacherId == record.TeacherId);
					// если нет такой, то создаем
					if (recelem == null)
					{
						recelem = ConvertToHourOfSemesterRecord(record, recelem, grelem);
						context.HourOfSemesterRecords.Add(recelem);
					}
					else
					{
						// если есть, то синхронизируем данные
						recelem.TotalHours = record.TotalHours;
						recelem.FlowId = recelem.FlowId;
					}
					context.SaveChanges();

					SyncAuditoriums(context, recelem, record);
					SyncPeriods(context, recelem, record);
				}
			}
		}

		/// <summary>
		/// Синхронизация аудиторий записи расчасовки
		/// </summary>
		/// <param name="hosr"></param>
		/// <param name="record"></param>
		private static void SyncAuditoriums(ScheduleDbContext context, HourOfSemesterRecord hosr, HourOfSemesterRecordBindingModel record)
		{
			// ищем аудитории к записи расчасовки
			var auditoriums = context.HourOfSemesterAuditoriums.Where(x => x.HourOfSemesterRecordId == hosr.Id).ToList();
			foreach (var newAuditor in record.HourOfSemesterAuditoriums)
			{
				var aud = auditoriums.FirstOrDefault(x => x.AuditoriumId == newAuditor.AuditoriumId);
				if (aud != null)
				{
					ConvertToHourOfSemesterAuditorium(newAuditor, aud, hosr);
					context.SaveChanges();
					auditoriums.Remove(aud);
				}
				else
				{
					context.HourOfSemesterAuditoriums.Add(ConvertToHourOfSemesterAuditorium(newAuditor, null, hosr));
					context.SaveChanges();
				}
			}
			context.HourOfSemesterAuditoriums.RemoveRange(auditoriums);
			context.SaveChanges();
		}

		/// <summary>
		/// Синхронизация периодов записи расчасовки
		/// </summary>
		/// <param name="hosr"></param>
		/// <param name="record"></param>
		private static void SyncPeriods(ScheduleDbContext context, HourOfSemesterRecord hosr, HourOfSemesterRecordBindingModel record)
		{
			var periods = context.HourOfSemesterPeriods.Where(x => x.HourOfSemesterRecordId == hosr.Id).ToList();
			foreach (var newPeriod in record.HourOfSemesterPeriods)
			{
				var per = periods.FirstOrDefault(x => x.PeriodId == newPeriod.PeriodId);
				if (per != null)
				{
					ConvertToHourOfSemesterPeriod(newPeriod, per, hosr);
					context.SaveChanges();
					periods.Remove(per);
				}
				else
				{
					per = ConvertToHourOfSemesterPeriod(newPeriod, null, hosr);
					context.HourOfSemesterPeriods.Add(per);
					context.SaveChanges();
				}
				if (newPeriod.HoursFirstWeek == 0 && newPeriod.HoursSecondWeek == 0)
				{
					continue;
				}
				SyncScheduleWeek(context, per.HoursFirstWeek, 1, per.Id);
				SyncScheduleWeek(context, per.HoursSecondWeek, 2, per.Id);
			}
			context.HourOfSemesterPeriods.RemoveRange(periods);
			context.SaveChanges();
		}

		/// <summary>
		/// Синхронизация записей расписания на конкретную неделю
		/// </summary>
		/// <param name="context"></param>
		/// <param name="countLessinsOnWeek"></param>
		/// <param name="numberOfWeek"></param>
		/// <param name="HourOfSemesterPeriodId"></param>
		private static void SyncScheduleWeek(ScheduleDbContext context, int countLessinsOnWeek, int numberOfWeek, Guid HourOfSemesterPeriodId)
		{
			var schedules = context.Schedules.Where(x => x.HourOfSemesterPeriodId == HourOfSemesterPeriodId && x.NumberWeeks == numberOfWeek).ToList();
			if (countLessinsOnWeek != schedules.Count)
			{
				if (countLessinsOnWeek == 0 && schedules.Any())
				{
					context.Schedules.RemoveRange(schedules);
					context.SaveChanges();
				}
				else if (countLessinsOnWeek > schedules.Count)
				{
					while (countLessinsOnWeek > schedules.Count)
					{
						var sched = new Schedule
						{
							HourOfSemesterPeriodId = HourOfSemesterPeriodId,
							NumberWeeks = numberOfWeek,
							Type = "type"
						};
						context.Schedules.Add(sched);
						context.SaveChanges();
						schedules.Add(sched);
					}
				}
				else if (countLessinsOnWeek < schedules.Count)
				{
					if (schedules.Exists(x => !x.DayOfTheWeek.HasValue))
					{
						while(schedules.Count > countLessinsOnWeek)
						{
							var elem = schedules.FirstOrDefault(x => !x.DayOfTheWeek.HasValue);
							if (elem == null)
							{
								break;
							}
							context.Schedules.Remove(elem);
							context.SaveChanges();
							schedules.Remove(elem);
						}
					}
					while (schedules.Count > countLessinsOnWeek)
					{
						var elem = schedules.FirstOrDefault();
						if (elem == null)
						{
							break;
						}
						context.Schedules.Remove(elem);
						context.SaveChanges();
						schedules.Remove(elem);
					}
				}
			}
		}
	}
}