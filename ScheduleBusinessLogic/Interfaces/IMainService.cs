using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleBusinessLogic.Interfaces
{
	/// <summary>
	/// Интерфйс для методов, не укладывающихся в рамки IBaseService
	/// </summary>
	public interface IMainService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		List<PeriodWithAcademicYearViewModel> GetPeriods();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		PeriodWithAcademicYearViewModel GetPeriod(Guid id);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		List<PeriodForHousOfSemesterViewModel> GetHourOfSemestersPeriodRecords(PeriodForHousOfSemesterBindingModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void UpdateHours(UpdateHoursBindingModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		void CreateDuplicateByHourOfSemesters(CreateDuplicateByHOSBindingModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		ScheduleRecordsForLoadViewModel GetScheduleRecordsForLoad(ScheduleRecordsForLoadBindingModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		AuditoriumsByScheduleRecordViewModel GetAuditoriumsByScheduleRecord(AuditoriumsByScheduleRecordBindingModel model);

		void SetLesson(LessonBindingModel model);
	}
}