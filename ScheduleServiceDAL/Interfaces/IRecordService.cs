using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleServiceDAL.Interfaces
{
    public interface IRecordService
    {
        void SaveExcel(string FileName);

        void SaveHtml(string FileName);
    }
}
