using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModels
{
    /// <summary>
    /// связь расчасовка - аудитория
    /// </summary>
    public class HourOfSemesterAuditorium : BaseEntity
    {
        [Required]
        public Guid HourOfSemesterRecordId { get; set; }

        public virtual HourOfSemesterRecord HourOfSemesterRecord { get; set; }

        [Required]
        public Guid AuditoriumId { get; set; }

        public virtual Auditorium Auditorium { get; set; }

        public int Priority { get; set; }
    }
}