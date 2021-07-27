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
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var record = context.HourOfSemesterPeriods.Include(x => x.HourOfSemesterRecord).Include(x => x.HourOfSemesterRecord.HourOfSemester)
					.FirstOrDefault(x => x.Id == model.HourOfSemesterPeriodId);
				if (record == null)
				{
					throw new Exception("Не найдена запись расчасовки по идентификатору");
				}
				record.HoursFirstWeek = model.FirstWeekCountLessons;
				record.HoursSecondWeek = model.SecondWeekCountLessons;
				context.SaveChanges();
				HourOfSemesterServiceDB.SyncScheduleWeek(context, record.HoursFirstWeek, 1, record);
				HourOfSemesterServiceDB.SyncScheduleWeek(context, record.HoursSecondWeek, 2, record);

				if (record.HourOfSemesterRecord.FlowId.HasValue)
				{
					var records = context.HourOfSemesterPeriods.Include(x => x.HourOfSemesterRecord).Include(x => x.HourOfSemesterRecord.HourOfSemester)
						.Where(x => x.HourOfSemesterRecord.FlowId == record.HourOfSemesterRecord.FlowId && x.PeriodId == record.PeriodId &&
						x.HourOfSemesterRecord.HourOfSemester.SemesterId == record.HourOfSemesterRecord.HourOfSemester.SemesterId &&
						x.HourOfSemesterRecord.HourOfSemester.DisciplineId == record.HourOfSemesterRecord.HourOfSemester.DisciplineId);
					foreach(var rec in records)
					{
						rec.HoursFirstWeek = model.FirstWeekCountLessons;
						rec.HoursSecondWeek = model.SecondWeekCountLessons;
						context.SaveChanges();
						HourOfSemesterServiceDB.SyncScheduleWeek(context, record.HoursFirstWeek, 1, rec);
						HourOfSemesterServiceDB.SyncScheduleWeek(context, record.HoursSecondWeek, 2, rec);
					}
				}
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
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
							FlowId = record.FlowId
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
					var periods = context.HourOfSemesterPeriods.Include(x => x.HourOfSemesterRecord).Where(x => x.HourOfSemesterRecordId == recelem.Id).ToList();
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
						HourOfSemesterServiceDB.SyncScheduleWeek(context, per.HoursFirstWeek, 1, per);
						HourOfSemesterServiceDB.SyncScheduleWeek(context, per.HoursSecondWeek, 2, per);
					}
					context.HourOfSemesterPeriods.RemoveRange(periods);
					context.SaveChanges();
					#endregion
				}
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

		public ScheduleRecordsForLoadViewModel GetScheduleRecordsForLoad(ScheduleRecordsForLoadBindingModel model)
		{
			using var context = GetContext;
			var schedule = context.Schedules.FirstOrDefault(x => x.Id == model.ScheduleId);
			if (schedule == null)
			{
				throw new Exception("Не найдена запись расписания по идентификатору");
			}
			var view = new ScheduleRecordsForLoadViewModel
			{
				NumberWeek = schedule.NumberWeeks,
				StudyGroupSubGroupLoads = context.Schedules
					.Include(x => x.Discipline).Include(x => x.StudyGroup).Include(x => x.Auditorium).Include(x => x.Teacher).Include(x => x.TypeOfClass)
					.Where(x => x.StudyGroupId == schedule.StudyGroupId && x.SubgroupNumber == schedule.SubgroupNumber && x.NumberWeeks == schedule.NumberWeeks)
					.Select(ConvertToScheduleViewModelMin)
					.ToList(),
				TeachersLoads = context.Schedules
					.Include(x => x.Discipline).Include(x => x.StudyGroup).Include(x => x.Auditorium).Include(x => x.Teacher).Include(x => x.TypeOfClass)
					.Where(x => x.TeacherId == schedule.TeacherId && x.NumberWeeks == schedule.NumberWeeks)
					.Select(ConvertToScheduleViewModelMin)
					.ToList(),
				AuditoriumLoads = context.Schedules
					.Include(x => x.Discipline).Include(x => x.StudyGroup).Include(x => x.Auditorium).Include(x => x.Teacher).Include(x => x.TypeOfClass)
					.Where(x => x.AuditoriumId == model.AuditoriumId && x.NumberWeeks == schedule.NumberWeeks)
					.Select(ConvertToScheduleViewModelMin).ToList()
			};
			if (schedule.FlowId.HasValue)
			{
				var studyGroupsId = context.Flows.Include(x => x.FlowStudyGroups).FirstOrDefault(x => x.Id == schedule.FlowId)?.FlowStudyGroups.Select(x => x.StudyGroupId);
				view.FlowLoads = context.Schedules
					.Include(x => x.Discipline).Include(x => x.StudyGroup).Include(x => x.Auditorium).Include(x => x.Teacher).Include(x => x.TypeOfClass)
					.Where(x => studyGroupsId.Any(y => y == x.StudyGroupId) && x.NumberWeeks == schedule.NumberWeeks)
					.Select(ConvertToScheduleViewModelMin).ToList();
			}
			return view;
		}

		public void SetLesson(LessonBindingModel model)
		{
			using var context = GetContext;
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var schedule = context.Schedules.Include(x => x.HourOfSemesterPeriod).FirstOrDefault(x => x.Id == model.ScheduleId);
				if (schedule == null)
				{
					throw new Exception("Не найдена запись расписания по идентификатору");
				}

				if (model.ForcedSet)
				{
					DropSchedules(context, model, schedule);
				}
				else
				{
					CheckCanSetLesson(context, model, schedule);
				}

				schedule.DayOfTheWeek = model.DayOfTheWeek;
				schedule.ClassTimeId = model.ClassTimeId;
				schedule.AuditoriumId = model.AuditoriumId;
				context.SaveChanges();
				if (schedule.FlowId.HasValue)
				{
					SetFlowSchedules(context, schedule);
				}
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

		public void DropLesson(LessonBindingModel model)
		{
			using var context = GetContext;
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var schedule = context.Schedules.Include(x => x.HourOfSemesterPeriod).FirstOrDefault(x => x.Id == model.ScheduleId);
				if (schedule == null)
				{
					throw new Exception("Не найдена запись расписания по идентификатору");
				}

				schedule.DayOfTheWeek = null;
				schedule.ClassTimeId = null;
				schedule.AuditoriumId = null;
				context.SaveChanges();
				if (schedule.FlowId.HasValue)
				{
					DropFlowSchedules(context, schedule);
				}
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

		public void MoveLesson(LessonBindingModel model)
		{
			using var context = GetContext;
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var schedule = context.Schedules.Include(x => x.HourOfSemesterPeriod).FirstOrDefault(x => x.Id == model.ScheduleId);
				if (schedule == null)
				{
					throw new Exception("Не найдена запись расписания по идентификатору");
				}

				CheckCanSetLesson(context, model, schedule);

				if (schedule.FlowId.HasValue)
				{
					MoveFlowSchedules(context, schedule, model);
				}
				schedule.DayOfTheWeek = model.DayOfTheWeek;
				schedule.ClassTimeId = model.ClassTimeId;
				schedule.AuditoriumId = model.AuditoriumId;
				context.SaveChanges();
				transaction.Commit();
			}
			catch (Exception)
			{
				transaction.Rollback();
				throw;
			}
		}

		private static ScheduleViewModel ConvertToScheduleViewModelMin(Schedule entity) => new()
		{
			DayOfTheWeek = entity.DayOfTheWeek,
			NumberWeeks = entity.NumberWeeks,
			ClassTimeId = entity.ClassTimeId,
			AuditoriumNumber = entity.Auditorium?.Number,
			DisciplineTitle = entity.Discipline?.AbbreviatedTitle,
			StudyGroupTitle = entity.StudyGroup?.Title,
			SubgroupNumber = entity.SubgroupNumber,
			TeacherShortName = entity.Teacher?.ShortName,
			TypeOfClassShort = entity.TypeOfClass.AbbreviatedTitle
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
		/// Сброс занятий, установленных у группы, аудитории и преподавателя
		/// </summary>
		/// <param name="context"></param>
		/// <param name="model"></param>
		/// <param name="schedule"></param>
		private static void DropSchedules(ScheduleDbContext context, LessonBindingModel model, Schedule schedule)
		{
			//сброс занятий у группы
			var exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Where(x => x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId
						&& x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId
						&& x.StudyGroupId == schedule.StudyGroupId
						&& (x.SubgroupNumber == schedule.SubgroupNumber || (!x.SubgroupNumber.HasValue && schedule.SubgroupNumber.HasValue)));
			if (exsist != null && exsist.Any())
			{
				foreach (var ex in exsist)
				{
					ex.DayOfTheWeek = null;
					ex.ClassTimeId = null;
					ex.AuditoriumId = null;
					context.SaveChanges();
				}
			}
			//сброс занятий у преподавателя
			exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Where(x => x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId
						&& x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId
						&& x.TeacherId == schedule.TeacherId && (x.FlowId != schedule.FlowId || x.FlowId == null));
			if (exsist != null && exsist.Any())
			{
				foreach (var ex in exsist)
				{
					ex.DayOfTheWeek = null;
					ex.ClassTimeId = null;
					ex.AuditoriumId = null;
					context.SaveChanges();
				}
			}
			//сброс поточных занятий
			if (schedule.FlowId.HasValue)
			{
				var flowGroups = context.FlowStudyGroups.Include(x => x.StudyGroup).Where(x => x.FlowId == schedule.FlowId);
				foreach (var gr in flowGroups)
				{
					if (gr.StudyGroupId == schedule.StudyGroupId)
					{
						continue;
					}
					exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
						.Where(x => x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId
									&& x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId
									&& x.StudyGroupId == gr.StudyGroupId && (x.FlowId != schedule.FlowId || x.FlowId == null));
					if (exsist != null && exsist.Any())
					{
						foreach (var ex in exsist)
						{
							ex.DayOfTheWeek = null;
							ex.ClassTimeId = null;
							ex.AuditoriumId = null;
							context.SaveChanges();
						}
					}
				}
			}
			//сброс занятий аудитории
			exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Where(x => x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId
						&& x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId
						&& x.AuditoriumId == model.AuditoriumId && (x.FlowId != schedule.FlowId || x.FlowId == null));
			if (exsist != null && exsist.Any())
			{
				foreach (var ex in exsist)
				{
					ex.DayOfTheWeek = null;
					ex.ClassTimeId = null;
					ex.AuditoriumId = null;
					context.SaveChanges();
				}
			}
		}

		/// <summary>
		/// Проверка можно ли ставить занятие и смена аудитории, если допустимо
		/// </summary>
		/// <param name="context"></param>
		/// <param name="model"></param>
		/// <param name="schedule"></param>
		private static void CheckCanSetLesson(ScheduleDbContext context, LessonBindingModel model, Schedule schedule)
		{
			// проверка 1, у группы или подгруппы нет занятия в эту пару
			var exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Where(x => x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId
						&& x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId
						&& x.StudyGroupId == schedule.StudyGroupId
						&& (x.SubgroupNumber == schedule.SubgroupNumber || (!x.SubgroupNumber.HasValue && schedule.SubgroupNumber.HasValue)));
			if (exsist != null && exsist.Any())
			{
				throw new Exception("У (под)группы уже стоит занятие в эту пару");
			}
			// проверка 2, у преподавателя нет пары в это время
			exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Where(x => x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId
						&& x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId
						&& x.TeacherId == schedule.TeacherId && (x.FlowId != schedule.FlowId || x.FlowId == null));
			if (exsist != null && exsist.Any())
			{
				throw new Exception("У преподавателя уже стоит занятие в эту пару");
			}
			// проверка 3, на поточные занятия
			if (schedule.FlowId.HasValue)
			{
				var flowGroups = context.FlowStudyGroups.Include(x => x.StudyGroup).Where(x => x.FlowId == schedule.FlowId);
				foreach (var gr in flowGroups)
				{
					if (gr.StudyGroupId == schedule.StudyGroupId)
					{
						continue;
					}
					exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
						.Where(x => x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId
										&& x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId
										&& x.StudyGroupId == gr.StudyGroupId && (x.FlowId != schedule.FlowId || x.FlowId == null));
					if (exsist != null && exsist.Any())
					{
						throw new Exception($"У группы {gr.StudyGroup.Title} уже стоит занятие в эту пару");
					}
				}
			}
			// проверка 4, в аудитории нет пары в это время
			exsist = context.Schedules.Include(x => x.HourOfSemesterPeriod)
				.Where(x => x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId
						&& x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId
						&& x.AuditoriumId == model.AuditoriumId && (x.FlowId != schedule.FlowId || x.FlowId == null));
			if (exsist != null && exsist.Any())
			{
				if (model.SetToFreeAuditorium)
				{
					// ищем подмену аудитории
					var audCurrent = context.Auditoriums.FirstOrDefault(x => x.Id == model.AuditoriumId);
					// сначала среди кафедральных
					var auds = context.Auditoriums.Where(x => x.DepartmentId == audCurrent.DepartmentId && x.TypeOfAudienceId == audCurrent.TypeOfAudienceId);
					foreach (var aud in auds)
					{
						if (context.Schedules.Include(x => x.HourOfSemesterPeriod).Any(x => x.AuditoriumId == aud.Id &&
								x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId && 
								x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId))
						{
							continue;
						}
						model.AuditoriumId = aud.Id;
						return;
					}
					// потом в том же корпусе
					auds = context.Auditoriums.Where(x => x.EducationalBuildingId == audCurrent.EducationalBuildingId && x.DepartmentId != audCurrent.DepartmentId
													&& x.TypeOfAudienceId == audCurrent.TypeOfAudienceId);
					foreach (var aud in auds)
					{
						if (context.Schedules.Include(x => x.HourOfSemesterPeriod).Any(x => x.AuditoriumId == aud.Id &&
								x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId &&
								x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId))
						{
							continue;
						}
						model.AuditoriumId = aud.Id;
						return;
					}
					// везде
					auds = context.Auditoriums.Where(x => x.EducationalBuildingId != audCurrent.EducationalBuildingId && x.DepartmentId != audCurrent.DepartmentId
													&& x.TypeOfAudienceId == audCurrent.TypeOfAudienceId);
					foreach (var aud in auds)
					{
						if (context.Schedules.Include(x => x.HourOfSemesterPeriod).Any(x => x.AuditoriumId == aud.Id &&
								x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId &&
								x.NumberWeeks == schedule.NumberWeeks && x.DayOfTheWeek == model.DayOfTheWeek && x.ClassTimeId == model.ClassTimeId))
						{
							continue;
						}
						model.AuditoriumId = aud.Id;
						return;
					}
					throw new Exception("Не удалост найти аудиторию того же типа для подмены");
				}
				else
				{
					throw new Exception("У аудитории уже стоит занятие в эту пару");
				}
			}
		}

		/// <summary>
		/// Установка пары у поточного занятия для других групп
		/// </summary>
		/// <param name="context"></param>
		/// <param name="schedule"></param>
		private static void SetFlowSchedules(ScheduleDbContext context, Schedule schedule)
		{
			var flowGroups = context.FlowStudyGroups.Where(x => x.FlowId == schedule.FlowId && x.StudyGroupId != schedule.StudyGroupId);
			foreach (var gr in flowGroups)
			{
				var sched = context.Schedules.Include(x => x.HourOfSemesterPeriod)
						.FirstOrDefault(x => x.NumberWeeks == schedule.NumberWeeks && x.ClassTimeId == null && x.DayOfTheWeek == null &&
											x.AuditoriumId == null && x.FlowId == schedule.FlowId && x.StudyGroupId == gr.StudyGroupId && 
											x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId);
				if (sched == null)
				{
					throw new Exception($"Не найдена запись расписания для поточной пары у группы {gr.StudyGroup.Title}");
				}
				sched.DayOfTheWeek = schedule.DayOfTheWeek;
				sched.ClassTimeId = schedule.ClassTimeId;
				sched.AuditoriumId = schedule.AuditoriumId;
				context.SaveChanges();
			}
		}

		/// <summary>
		/// Перемещение пары у поточного занятия для других групп
		/// </summary>
		/// <param name="context"></param>
		/// <param name="schedule"></param>
		private static void MoveFlowSchedules(ScheduleDbContext context, Schedule schedule, LessonBindingModel model)
		{
			var flowGroups = context.FlowStudyGroups.Where(x => x.FlowId == schedule.FlowId && x.StudyGroupId != schedule.StudyGroupId);
			foreach (var gr in flowGroups)
			{
				var sched = context.Schedules.Include(x => x.HourOfSemesterPeriod)
						.FirstOrDefault(x => x.NumberWeeks == schedule.NumberWeeks && x.ClassTimeId == schedule.ClassTimeId && x.DayOfTheWeek == schedule.DayOfTheWeek &&
											x.AuditoriumId == schedule.AuditoriumId && x.FlowId == schedule.FlowId && x.StudyGroupId == gr.StudyGroupId &&
											x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId);
				if (sched == null)
				{
					throw new Exception($"Не найдена запись расписания для поточной пары у группы {gr.StudyGroup.Title}");
				}
				sched.DayOfTheWeek = model.DayOfTheWeek;
				sched.ClassTimeId = model.ClassTimeId;
				sched.AuditoriumId = model.AuditoriumId;
				context.SaveChanges();
			}
		}

		/// <summary>
		/// Установка пары у поточного занятия для других групп
		/// </summary>
		/// <param name="context"></param>
		/// <param name="schedule"></param>
		private static void DropFlowSchedules(ScheduleDbContext context, Schedule schedule)
		{
			var flowGroups = context.FlowStudyGroups.Where(x => x.FlowId == schedule.FlowId && x.StudyGroupId != schedule.StudyGroupId);
			foreach (var gr in flowGroups)
			{
				var sched = context.Schedules.Include(x => x.HourOfSemesterPeriod)
						.FirstOrDefault(x => x.NumberWeeks == schedule.NumberWeeks && x.ClassTimeId == null && x.DayOfTheWeek == null &&
											x.AuditoriumId == null && x.FlowId == schedule.FlowId && x.StudyGroupId == gr.StudyGroupId &&
											x.DisciplineId == schedule.DisciplineId && x.HourOfSemesterPeriod.PeriodId == schedule.HourOfSemesterPeriod.PeriodId);
				if (sched == null)
				{
					throw new Exception($"Не найдена запись расписания для поточной пары у группы {gr.StudyGroup.Title}");
				}
				sched.DayOfTheWeek = null;
				sched.ClassTimeId = null;
				sched.AuditoriumId = null;
				context.SaveChanges();
			}
		}
	}
}