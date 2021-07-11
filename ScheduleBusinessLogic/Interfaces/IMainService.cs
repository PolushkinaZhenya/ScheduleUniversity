using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBusinessLogic.Interfaces
{
	/// <summary>
	/// Интерфйс для методов, не укладывающихся в рамки IBaseService
	/// </summary>
	public interface IMainService
	{
		List<PeriodWithAcademicYearViewModel> GetPeriods();


		PeriodWithAcademicYearViewModel GetPeriod(Guid id);
	}
}