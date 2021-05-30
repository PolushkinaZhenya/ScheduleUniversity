using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleView
{
    public partial class FormSave : Form
    {
        private readonly IFacultyService service;

        private readonly ITeacherService serviceT;

        private readonly IRecordService serviceR;

        private readonly IScheduleService serviceS;

        private readonly ILoadTeacherService serviceLT;

        private readonly IAuditoriumService serviceA;

        private readonly IFlowService serviceF;

        List<string> listBy = new List<string>() { "Учебным занятиям", "Преподавателям", "Аудиториям" };

        List<string> listIn = new List<string>() { "HTML", "Excel" };

        List<string> faculties = new List<string>();

        CheckBox checkBox = new CheckBox();

        public FormSave(IFacultyService service, ITeacherService serviceT, IRecordService serviceR, IScheduleService serviceS, IAuditoriumService serviceA,
            ILoadTeacherService serviceLT, IFlowService serviceF)
        {
            InitializeComponent();
            this.service = service;
            this.serviceT = serviceT;
            this.serviceR = serviceR;
            this.serviceS = serviceS;
            this.serviceA = serviceA;
            this.serviceLT = serviceLT;
            this.serviceF = serviceF;
        }

        private void FormSave_Load(object sender, EventArgs e)
        {
            try
            {
                if (listBy != null)
                {
                    //comboBoxBy.DisplayMember = "Title";
                    //comboBoxType.ValueMember = "Id";
                    comboBoxBy.DataSource = listBy;
                    comboBoxBy.SelectedItem = listBy[0];
                }

                if (listBy != null)
                {
                    //comboBoxBy.DisplayMember = "Title";
                    //comboBoxType.ValueMember = "Id";
                    comboBoxIn.DataSource = listIn;
                    comboBoxIn.SelectedItem = listIn[0];
                }

                List<FacultyViewModel> faculty = service.GetList();

                for (int i = 0; i < faculty.Count; i++)
                {
                    checkBox = new CheckBox();
                    checkBox.AutoSize = true;
                    checkBox.Location = new Point(7, 22 + (27 * i));
                    checkBox.Name = "checkBox" + faculty[i].Title;
                    checkBox.Size = new Size(98, 21);
                    checkBox.TabIndex = 0;
                    checkBox.Text = faculty[i].Title;
                    checkBox.UseVisualStyleBackColor = true;
                    checkBox.CheckedChanged += new EventHandler(this.checkBox_CheckedChanged);

                    groupBoxFaculty.Controls.Add(checkBox);

                    Height += 27;
                    groupBoxFaculty.Height += 27;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBy.SelectedIndex == 0)
            {
                groupBoxFaculty.Enabled = true;
                comboBoxIn.Enabled = true;
            }
            else
            {
                groupBoxFaculty.Enabled = false;
                comboBoxIn.SelectedItem = listIn[0];
                comboBoxIn.Enabled = false;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            //для учебных занятий
            if (comboBoxBy.SelectedIndex == 0)
            {
                //для html
                if (comboBoxIn.SelectedIndex == 0)
                {
                    FolderBrowserDialog FBD = new FolderBrowserDialog();
                    if (FBD.ShowDialog() == DialogResult.OK)
                    {
                        if (Directory.EnumerateFiles(FBD.SelectedPath, "*.*", SearchOption.AllDirectories).Count() != 0)
                        {
                            MessageBox.Show("Выберите пустую папку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (faculties.Count == 0)
                        {
                            MessageBox.Show("Выберите хоть один факультет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        List<StudyGroupViewModel> studyGroup= new List<StudyGroupViewModel>();

                        serviceR.SaveHtmlStudyGroups(FBD.SelectedPath, studyGroup);
                        for (int i = 0; i < faculties.Count; i++)
                        {

                        }

                    }



                }
                //для Excel
                else
                {


                }
            }
            //для преподавателей в html
            if (comboBoxBy.SelectedIndex == 1)
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    if (Directory.EnumerateFiles(FBD.SelectedPath, "*.*", SearchOption.AllDirectories).Count() != 0)
                    {
                        MessageBox.Show("Выберите пустую папку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //else
                    //{
                    List<TeacherViewModel> teachers = serviceT.GetList();

                    if (teachers.Count != 0)//если есть преподаватели
                    {
                        //делаем сохранение общего файла и файлов преподавателей
                        serviceR.SaveHtmlTeachers(FBD.SelectedPath, teachers);

                        //считываем шаблон с таблицей дней и пар
                        StreamReader sr = new StreamReader(@"D:\ПИбд\4 курс\Диплом\ScheduleUniversity\ScheduleView\Templates\WeekAndTime.html");
                        string WeekAndTime = "";
                        while (!sr.EndOfStream)
                        {
                            WeekAndTime = sr.ReadToEnd();
                        }
                        sr.Close();

                        //заполняем файл каждого преподавателя
                        for (int i = 0; i < teachers.Count; i++)
                        {
                            //расставленные пары препода
                            List<ScheduleViewModel> scheduleByTeacherFill = serviceS.GetListByPeroidAndTeacherFill(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), teachers[i].Id, "Занятие");

                            //дописываем файлы преподавателей
                            //заполняем файл преподавателя
                            //1ая неделя
                            string str = "<HTML>\n<HEAD>\n<TITLE>" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) +
                                "</TITLE>\n<META NAME=\"Template\" CONTENT=\"C:\\PROGRAM FILES\\MICROSOFT OFFICE\\OFFICE\\html.dot\">\n" +
                                "</HEAD>\n<BODY>\n" +
                                "<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#0000ff\"><P>Расписание занятий преподавателя: </FONT>" +
                                "<FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#ff00ff\">" + teachers[i].Surname + " " + teachers[i].Name.Substring(0, 1) + " " +
                            teachers[i].Patronymic.Substring(0, 1) + "<BR> Неделя: 1-я</P></FONT>\n" +
                            "<TABLE BORDER CELLSPACING=3 BORDERCOLOR=\"#000000\" CELLPADDING=2 WIDTH=801>";

                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", WeekAndTime);


                            //запись Понедельника 1й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Пнд</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 1, "Понедельник", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //запись Вторника 1й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Втр</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 1, "Вторник", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //запись Среды 1й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Срд</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 1, "Среда", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //запись Четверга 1й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Чтв</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 1, "Четверг", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            //запись Пятницы 1й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Птн</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 1, "Пятница", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            //запись Субботы 1й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Сбт</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 1, "Суббота", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //запись Воскресенья 1й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Вск</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 1, "Воскресенье", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>\n</TABLE>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);



                            //2ая неделя
                            str = "<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#0000ff\"><P>Расписание занятий преподавателя: </FONT>" +
                                "<FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#ff00ff\">" + teachers[i].Surname + " " + teachers[i].Name.Substring(0, 1) + " " +
                            teachers[i].Patronymic.Substring(0, 1) + "<BR> Неделя: 2-я</P></FONT>\n" +
                            "<TABLE BORDER CELLSPACING=3 BORDERCOLOR=\"#000000\" CELLPADDING=2 WIDTH=801>";

                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", WeekAndTime);

                            //запись Понедельника 2й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Пнд</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 2, "Понедельник", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //запись Вторника 2й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Втр</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 2, "Вторник", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //запись Среды 2й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Срд</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 2, "Среда", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //запись Четверга 2й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Чтв</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 2, "Четверг", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            //запись Пятницы 2й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Птн</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 2, "Пятница", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            //запись Субботы 2й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Сбт</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 2, "Суббота", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //запись Воскресенья 2й недели
                            str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                        "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">Вск</B></I></FONT></TD>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                            WriteDayOfTheWeek(scheduleByTeacherFill, 2, "Воскресенье", FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                            str = "</TR>\n</TABLE>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);


                            //конец дкумента
                            str = "</BODY>\n</HTML>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);
                        }
                    }
                    //}
                }
            }

            //для аудиторий в html
            if (comboBoxBy.SelectedIndex == 2)
            {

            }
        }

        void WriteDayOfTheWeek(List<ScheduleViewModel> scheduleByTeacherFill, int NumberWeeks, string DayOfTheWeek, string SelectedPath)
        {
            //запись одного дня недели
            int kol = 0;
            while (kol < 8)
            {
                bool search = false;
                for (int j = 0; j < scheduleByTeacherFill.Count; j++)
                {
                    if (scheduleByTeacherFill[j].NumberWeeks == NumberWeeks && scheduleByTeacherFill[j].DayOfTheWeek.ToString() == DayOfTheWeek
                                                            && scheduleByTeacherFill[j].ClassTimeNumber == kol + 1)
                    {

                        //формируем значение ячейки
                        string str;
                        string educationalbuilding = serviceA.GetElement((Guid)scheduleByTeacherFill[j].AuditoriumId).EducationalBuilding;// № корпуса

                        //есть ли группы в потоке
                        LoadTeacherViewModel loadTeacher = serviceLT.GetElement(scheduleByTeacherFill[j].LoadTeacherId);//расчасовка занятия
                        List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

                        if (flow.Count > 1)
                        {
                            str = "<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                           "<FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">";

                            for (int f = 0; f < flow.Count; f++)
                            {
                                if (flow[f].Subgroup != null)
                                {
                                    str += flow[f].StudyGroupTitle + " - " + flow[f].Subgroup + " п/г" + " ";
                                }
                                else
                                {
                                    str += flow[f].StudyGroupTitle + " ";
                                }
                            }

                            str += "</br>" + scheduleByTeacherFill[j].TypeOfClassTitle + ". " + scheduleByTeacherFill[j].DisciplineTitle + "</br>" + educationalbuilding + "-" +
                                scheduleByTeacherFill[j].AuditoriumNumber + "</FONT></TD>";


                            //пропустить пары преподавателя групп потока
                            j += flow.Count;
                        }
                        else
                        {
                            str = "<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                           "<FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">" + scheduleByTeacherFill[j].StudyGroupTitle;

                            if (scheduleByTeacherFill[j].Subgroups != null)
                            {
                                str += " - " + scheduleByTeacherFill[j].Subgroups + " п/г";
                            }

                            str += "</br>" + scheduleByTeacherFill[j].TypeOfClassTitle + ". " + scheduleByTeacherFill[j].DisciplineTitle + "</br>" + educationalbuilding + "-" +
                                scheduleByTeacherFill[j].AuditoriumNumber + "</FONT></TD>";
                        }


                        //записываем пару
                        //str = "<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                        //   "<FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">" + МНГДбд - 11 + "</br>" + пр..Профессиональный иностранный язык+"</br>" + 6 - 822 + "</FONT></TD>";
                        File.AppendAllText(SelectedPath, str);

                        search = true;
                    }
                }
                if (!search)
                {
                    string str = "<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                            "<FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">_</br></br></FONT></TD>";
                    File.AppendAllText(SelectedPath, str);
                }
                kol++;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox

            if (checkBox.Checked)
            {
                string i = checkBox.Text;
                faculties.Add(checkBox.Text);
            }
            else
            {
                faculties.Remove(checkBox.Text);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
