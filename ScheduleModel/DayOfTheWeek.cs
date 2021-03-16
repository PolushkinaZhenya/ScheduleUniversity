using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModel
{
    //учебный день недели

    public enum DayOfTheWeek
    {
        Понедельник = 1,

        Вторник = 2,

        Среда = 3,

        Четверг = 4,

        Пятница = 5,

        Суббота = 6,

        Воскресенье = 7
    }
}
