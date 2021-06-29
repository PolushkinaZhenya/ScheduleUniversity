using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;

namespace ScheduleBusinessLogic.Interfaces
{
	public interface ISyncWith1C
	{
		SyncWith1CViewModel SyncWith1C(SyncWith1CBindingModel model);
	}
}