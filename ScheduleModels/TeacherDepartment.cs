using System;

namespace ScheduleModels
{
	/// <summary>
	/// связь преподаватель - кафедра
	/// </summary>
	public class TeacherDepartment
    {
        public Guid Id { get; set; }

        public Guid TeacherId { get; set; }

        public Guid DepartmentId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Department Department { get; set; }
    }
}