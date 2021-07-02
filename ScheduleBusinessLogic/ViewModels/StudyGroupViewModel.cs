using ScheduleBusinessLogic.Attributes;
using ScheduleModels;
using System;

namespace ScheduleBusinessLogic.ViewModels
{
	public class StudyGroupViewModel
    {
        [Column(title: "id", visible: false)]
        public Guid Id { get; set; }

        [Column(title: "Название", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Title { get; set; }

        public Guid SpecialtyId { get; set; }

        [Column(title: "Специальность", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SpecialtyTitle { get; set; }

        [Column(title: "Тип обучения", gridViewAutoSize: GridViewAutoSize.Fill)]
        public TypeEducation TypeEducation { get; set; }

        [Column(title: "Форма обучения", gridViewAutoSize: GridViewAutoSize.Fill)]
        public FormEducation FormEducation { get; set; }

        [Column(title: "Номер группы", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int GroupNumber { get; set; }

        public int Course { get; set; }

        [Column(title: "Кол-во студентов", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int NumderStudents { get; set; }

        public int NumderSubgroups { get; set; }
    }
}