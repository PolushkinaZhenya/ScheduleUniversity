using Microsoft.EntityFrameworkCore;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class MainService : IMainService
	{
		private readonly DbContextOptions<ScheduleDbContext> _options;

		public MainService(DbContextOptions<ScheduleDbContext> option)
		{
			_options = option;
		}

		private ScheduleDbContext GetContext { get => new(_options); }

		public List<PeriodWithAcademicYearViewModel> GetPeriods()
		{
			using var context = GetContext;
			return context.Periods
				.Include(x => x.Semester).Include(x => x.Semester.AcademicYear)
				.OrderBy(x => x.StartDate)
				.Select(GetPeriodWithAcademicYearViewModel)
				.ToList();
		}

		public PeriodWithAcademicYearViewModel GetPeriod(Guid id)
		{
			using var context = GetContext;
			return context.Periods
				.Include(x => x.Semester).Include(x => x.Semester.AcademicYear)
				.Where(x => x.Id == id)
				.Select(GetPeriodWithAcademicYearViewModel)
				.FirstOrDefault();
		}

		private PeriodWithAcademicYearViewModel GetPeriodWithAcademicYearViewModel(Period entity) =>
			new()
			{
				Id = entity.Id,
				PeriodTitle = entity.Title,
				SemesterId = entity.SemesterId,
				SemesterTitle = entity.Semester?.Title,
				AcademicYearTitle = entity.Semester?.AcademicYear?.Title
			};

		public List<PeriodForHousOfSemesterViewModel> GetHourOfSemestersPeriodRecords(PeriodForHousOfSemesterBindingModel model)
		{
			using var context = GetContext;
			return context.HourOfSemesterPeriods
				.Include(x => x.HourOfSemesterRecord)
				.Include(x => x.HourOfSemesterRecord.Teacher).Include(x => x.HourOfSemesterRecord.Flow)
				.Include(x => x.HourOfSemesterRecord.Flow.FlowStudyGroups).ThenInclude(x => x.StudyGroup)
				.Include(x => x.HourOfSemesterRecord.HourOfSemesterAuditoriums).ThenInclude(x => x.Auditorium)
				.Include(x => x.HourOfSemesterRecord.HourOfSemester)
				.Include(x => x.HourOfSemesterRecord.HourOfSemester.Discipline)
				.Where(x => x.PeriodId == model.PeriodId && x.HourOfSemesterRecord.TypeOfClassId == model.TypeOfClassId &&
														x.HourOfSemesterRecord.HourOfSemester.StudyGroupId == model.StudyGroupId)
				.Select(x => new PeriodForHousOfSemesterViewModel
				{
					HourOfSemesterPeriodId = x.Id,
					HousOfSemesterId = x.HourOfSemesterRecord.HourOfSemesterId,
					DisciplineTitle = x.HourOfSemesterRecord.HourOfSemester.Discipline.Title,
					TeacherShortName = x.HourOfSemesterRecord.Teacher.ShortName,
					SubgroupNumber = x.HourOfSemesterRecord.SubgroupNumber,
					TotalHours = x.HourOfSemesterRecord.TotalHours,
					Flows = x.HourOfSemesterRecord.Flow != null ? x.HourOfSemesterRecord.Flow.FlowStudyGroups.Select(y => y.StudyGroup.Title).ToList() : null,
					HoursFirstWeek = x.HoursFirstWeek,
					HoursSecondWeek = x.HoursSecondWeek,
					Auditoriums = string.Join(",", x.HourOfSemesterRecord.HourOfSemesterAuditoriums.Select(y => y.Auditorium.Number).ToList())
				})
				.ToList();
		}

		public void UpdateHours(UpdateHoursBindingModel model)
		{
			using var context = GetContext;
			var record = context.HourOfSemesterPeriods.FirstOrDefault(x => x.Id == model.HourOfSemesterPeriodId);
			if (record == null)
			{
				throw new Exception("Не найдена запись расчасовки по идентификатору");
			}
			record.HoursFirstWeek = model.FirstWeekCountLessons;
			record.HoursSecondWeek = model.SecondWeekCountLessons;
			context.SaveChanges();
		}

		public void CreateDuplicateByHourOfSemesters(CreateDuplicateByHOSBindingModel model)
		{
			using var context = GetContext;
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var hos = context.HourOfSemesters
					.Include(x => x.HourOfSemesterRecords)
					.Include("HourOfSemesterRecords.HourOfSemesterAuditoriums")
					.Include("HourOfSemesterRecords.HourOfSemesterPeriods")
					.FirstOrDefault(x => x.Id == model.HousOfSemesterId);
				if (hos == null)
				{
					throw new Exception("Не найдена запись расчасовки по идентификатору");
				}

				// ищем расчасовку по другой группе
				var grelem = context.HourOfSemesters.FirstOrDefault(x => x.DisciplineId == hos.DisciplineId
																&& x.SemesterId == hos.SemesterId && x.StudyGroupId == model.StudyGroupId);
				// если нет, то создаем
				if (grelem == null)
				{
					grelem = new HourOfSemester
					{
						Id = new Guid(),
						DisciplineId = hos.DisciplineId,
						Reporting = hos.Reporting,
						SemesterId = hos.SemesterId,
						StudyGroupId = model.StudyGroupId,
						Wishes = hos.Wishes
					};
					context.HourOfSemesters.Add(grelem);
					context.SaveChanges();
				}
				// иначе, синхронизируем данные
				else
				{
					grelem.Reporting = hos.Reporting;
					grelem.Wishes = hos.Wishes;
					context.SaveChanges();
				}

				// идем по записям расчасовок
				foreach (var record in hos.HourOfSemesterRecords)
				{
					// ищем запись расчасовки по этому типу занятий для этой подгруппы
					var recelem = context.HourOfSemesterRecords.FirstOrDefault(x => x.HourOfSemesterId == grelem.Id &&
											x.TypeOfClassId == record.TypeOfClassId && x.SubgroupNumber == record.SubgroupNumber);
					// если нет такой, то создаем
					if (recelem == null)
					{
						recelem = new HourOfSemesterRecord
						{
							Id = new Guid(),
							HourOfSemesterId = grelem.Id,
							SubgroupNumber = record.SubgroupNumber,
							TypeOfClassId = record.TypeOfClassId,
							TotalHours = record.TotalHours,
							TeacherId = record.TeacherId,
							FlowId = record.FlowId,
							
						};
						context.HourOfSemesterRecords.Add(recelem);
					}
					else
					{
						// если есть, то синхронизируем данные
						recelem.TeacherId = record.TeacherId;
						recelem.TotalHours = record.TotalHours;
						recelem.FlowId = recelem.FlowId;
					}
					context.SaveChanges();

					#region auditoriums
					// ищем аудитории к записи расчасовки
					var auditoriums = context.HourOfSemesterAuditoriums.Where(x => x.HourOfSemesterRecordId == recelem.Id).ToList();
					foreach (var auditor in record.HourOfSemesterAuditoriums)
					{
						var aud = auditoriums.FirstOrDefault(x => x.AuditoriumId == auditor.AuditoriumId);
						if (aud != null)
						{
							aud.Priority = auditor.Priority;
							context.SaveChanges();
							auditoriums.Remove(aud);
						}
						else
						{
							context.HourOfSemesterAuditoriums.Add(new HourOfSemesterAuditorium
							{
								Id = new Guid(),
								HourOfSemesterRecordId = recelem.Id,
								AuditoriumId = auditor.AuditoriumId,
								Priority = auditor.Priority
							});
							context.SaveChanges();
						}
					}
					context.HourOfSemesterAuditoriums.RemoveRange(auditoriums);
					context.SaveChanges();
					#endregion

					#region periods
					var periods = context.HourOfSemesterPeriods.Where(x => x.HourOfSemesterRecordId == recelem.Id).ToList();
					foreach (var period in record.HourOfSemesterPeriods)
					{
						var per = periods.FirstOrDefault(x => x.PeriodId == period.PeriodId);
						if (per != null)
						{
							per.HoursFirstWeek = period.HoursFirstWeek;
							per.HoursSecondWeek = period.HoursSecondWeek;
							context.SaveChanges();
							periods.Remove(per);
						}
						else
						{
							per = new HourOfSemesterPeriod
							{
								Id = new Guid(),
								HourOfSemesterRecordId = recelem.Id,
								PeriodId = period.PeriodId,
								HoursFirstWeek = period.HoursFirstWeek,
								HoursSecondWeek = period.HoursSecondWeek
							};
							context.HourOfSemesterPeriods.Add(per);
							context.SaveChanges();
						}
						SyncScheduleWeek(context, per.HoursFirstWeek, 1, per.Id);
						SyncScheduleWeek(context, per.HoursSecondWeek, 2, per.Id);
					}
					context.HourOfSemesterPeriods.RemoveRange(periods);
					context.SaveChanges();
					#endregion
				}
				transaction.Commit();
			}
			catch(Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

		public ScheduleRecordsForLoadViewModel GetScheduleRecordsForLoad(ScheduleRecordsForLoadBindingModel model)
		{
			using var context = GetContext;
			var schedule = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord)
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemester)
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemesterAuditoriums).FirstOrDefault(x => x.Id == model.ScheduleId);
			if (schedule == null)
			{
				throw new Exception("Не найдена запись расписания по идентификатору");
			}
			var view = new ScheduleRecordsForLoadViewModel
			{
				NumberWeek = schedule.NumberWeeks,
				StudyGroupSubGroupLoads = context.Schedules
					.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemester)
					.Where(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemester.StudyGroupId ==
																		schedule.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemester.StudyGroupId
						&& x.HourOfSemesterPeriod.HourOfSemesterRecord.SubgroupNumber == schedule.HourOfSemesterPeriod.HourOfSemesterRecord.SubgroupNumber
						&& x.NumberWeeks == schedule.NumberWeeks)
					.Select(ConvertToScheduleViewModelMin)
					.ToList(),
				TeachersLoads = context.Schedules
					.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord)
					.Where(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.TeacherId == schedule.HourOfSemesterPeriod.HourOfSemesterRecord.TeacherId
																									&& x.NumberWeeks == schedule.NumberWeeks)
					.Select(ConvertToScheduleViewModelMin)
					.ToList(),
				AuditoriumLoads = context.Schedules
					.Where(x => x.AuditoriumId == model.AuditoriumId && x.NumberWeeks == schedule.NumberWeeks)
					.Select(ConvertToScheduleViewModelMin).ToList()
			};
			var flowId = schedule.HourOfSemesterPeriod?.HourOfSemesterRecord?.FlowId;
			if (flowId != null)
			{
				var studyGroupsId = context.Flows.Include(x => x.FlowStudyGroups).FirstOrDefault(x => x.Id == flowId)?.FlowStudyGroups.Select(x => x.StudyGroupId);
				view.FlowLoads = context.Schedules
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemester)
				.Where(x => studyGroupsId.Any(y => y == x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemester.StudyGroupId) &&
																									x.NumberWeeks == schedule.NumberWeeks)
				.Select(ConvertToScheduleViewModelMin).ToList();
			}
			return view;
		}

		public void SetLesson(LessonBindingModel model)
		{
			using var context = GetContext;
			var schedule = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord)
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemester).FirstOrDefault(x => x.Id == model.ScheduleId);
			if (schedule == null)
			{
				throw new Exception("Не найдена запись расписания по идентификатору");
			}

			// проверки, что пару можно ставить
			var exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord)
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemester)
				.Where(x => x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId && x.NumberWeeks == schedule.NumberWeeks
						&& x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId);
			if (exsist != null)
			{

			}


			schedule.DayOfTheWeek = model.DayOfTheWeek;
			schedule.ClassTimeId = model.ClassTimeId;
			context.SaveChanges();
		}

		private static ScheduleViewModel ConvertToScheduleViewModelMin(Schedule entity) => new()
		{
			DayOfTheWeek = entity.DayOfTheWeek,
			NumberWeeks = entity.NumberWeeks,
			ClassTimeId = entity.ClassTimeId
		};

		public AuditoriumsByScheduleRecordViewModel GetAuditoriumsByScheduleRecord(AuditoriumsByScheduleRecordBindingModel model)
		{
			using var context = GetContext;
			var view = new AuditoriumsByScheduleRecordViewModel
			{
				Auditoriums = context.Schedules
				.Include(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemesterAuditoriums)
				.ThenInclude(x => x.Auditorium)
				.Where(x => x.Id == model.ScheduleId)
				.ToList()
				.SelectMany(x => x.HourOfSemesterPeriod.HourOfSemesterRecord.HourOfSemesterAuditoriums, (x, aud) => (aud.AuditoriumId, aud.Auditorium.Number))
				.ToList()
			};
			return view;
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
						while (schedules.Count > countLessinsOnWeek)
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