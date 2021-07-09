using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleModels
{
	/// <summary>
	/// тип аудитории
	/// </summary>
	public class TypeOfAudience : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [ForeignKey("TypeOfAudienceId")]
        public virtual List<Auditorium> Auditoriums { get; set; }
    }
}