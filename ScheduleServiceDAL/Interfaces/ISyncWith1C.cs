using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.ViewModels;

namespace ScheduleServiceDAL.Interfaces
{
	public interface ISyncWith1C
	{
		SyncWith1CViewModel SyncWith1C(SyncWith1CBindingModel model);
	}
}