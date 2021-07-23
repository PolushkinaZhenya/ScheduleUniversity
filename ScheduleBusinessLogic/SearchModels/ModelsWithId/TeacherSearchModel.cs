namespace ScheduleBusinessLogic.SearchModels
{
	public class TeacherSearchModel : BaseSearchModel
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string ShortName { get; set; }

        public string SurnameFirstLetter { get; set; }
    }
}