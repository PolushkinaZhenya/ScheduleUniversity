using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleModels
{
	public class BaseEntity
	{
		[Required]
		public Guid Id { get; set; }
	}
}