using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

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

        private readonly ISpecialtyService serviceSp;

        private readonly IFlowService serviceF;

        private readonly IStudyGroupService serviceSG;

        List<string> listBy = new List<string>() { "Учебным занятиям", "Преподавателям"};

        List<string> listIn = new List<string>() { "HTML", "Excel" };

        List<string> listWeek = new List<string>() { "1 неделя", "2 неделя" };

        List<string> faculties = new List<string>();

        System.Windows.Forms.CheckBox checkBox = new System.Windows.Forms.CheckBox();

        public FormSave(IFacultyService service, ITeacherService serviceT, IRecordService serviceR, IScheduleService serviceS, IAuditoriumService serviceA,
            ILoadTeacherService serviceLT, IFlowService serviceF, ISpecialtyService serviceSp, IStudyGroupService serviceSG)
        {
            InitializeComponent();
            this.service = service;
            this.serviceT = serviceT;
            this.serviceR = serviceR;
            this.serviceS = serviceS;
            this.serviceA = serviceA;
            this.serviceLT = serviceLT;
            this.serviceF = serviceF;
            this.serviceSp = serviceSp;
            this.serviceSG = serviceSG;
        }

        private void FormSave_Load(object sender, EventArgs e)
        {
            try
            {
                if (listBy != null)
                {
                    comboBoxBy.DataSource = listBy;
                    comboBoxBy.SelectedItem = listBy[0];
                }

                if (listIn != null)
                {
                    comboBoxIn.DataSource = listIn;
                    comboBoxIn.SelectedItem = listIn[0];
                }

                if (listWeek != null)
                {
                    comboBoxWeek.DataSource = listWeek;
                    comboBoxWeek.SelectedItem = listWeek[0];
                }

                List<FacultyViewModel> faculty = service.GetList();

                for (int i = 0; i < faculty.Count; i++)
                {
                    checkBox = new System.Windows.Forms.CheckBox();
                    checkBox.AutoSize = true;
                    checkBox.Location = new System.Drawing.Point(7, 22 + (27 * i));
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

                        List<StudyGroupViewModel> studyGroups = GetCheckStudyGroups();//new List<StudyGroupViewModel>();


                        if (studyGroups.Count > 0)
                        {
                            //делаем сохранение общего файла и файлов групп
                            serviceR.SaveHtmlStudyGroups(FBD.SelectedPath, studyGroups);

                            //считываем шаблон с таблицей дней и пар
                            StreamReader sr = new StreamReader(@"D:\ПИбд\4 курс\Диплом\ScheduleUniversity\ScheduleView\Templates\WeekAndTime.html");
                            string WeekAndTime = "";
                            while (!sr.EndOfStream)
                            {
                                WeekAndTime = sr.ReadToEnd();
                            }
                            sr.Close();

                            studyGroups = GetCheckStudyGroups();
                            //заполняем файл каждой группы
                            for (int i = 0; i < studyGroups.Count; i++)
                            {
                                //расставленные пары группы
                                List<ScheduleViewModel> scheduleByStudyGroupFill = serviceS.GetListByPeroidAndStudyGroupFill(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), studyGroups[i].Id, "Занятие");

                                string str;

                                //заполняем файл группы
                                for (int j = 1; j < 3; j++)
                                {
                                    //неделя
                                    str = "<HTML>\n<HEAD>\n<TITLE>" + studyGroups[i].Title +
                                        "</TITLE>\n</HEAD>\n<BODY>\n" +
                                        "<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#0000ff\"><P>Расписание занятий учебной группы: </FONT>" +
                                        "<FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#ff00ff\">" + studyGroups[i].Title +
                                    "<BR> Неделя: " + j + "-я</P></FONT>\n" +
                                    "<TABLE BORDER CELLSPACING=3 BORDERCOLOR=\"#000000\" CELLPADDING=2 WIDTH=801>";

                                    File.AppendAllText(FBD.SelectedPath + @"\" + studyGroups[i].Title + ".html", str);

                                    File.AppendAllText(FBD.SelectedPath + @"\" + studyGroups[i].Title + ".html", WeekAndTime);

                                    List<string> days = new List<string>() { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
                                    for (int day = 0; day < days.Count; day++)
                                    {
                                        //запись дня недели
                                        str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                                    "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">" + days[day] + "</B></I></FONT></TD>";
                                        File.AppendAllText(FBD.SelectedPath + @"\" + studyGroups[i].Title + ".html", str);

                                        WriteDayOfTheWeekByStudyGroup(scheduleByStudyGroupFill, j, days[day], FBD.SelectedPath + @"\" + studyGroups[i].Title + ".html");

                                        str = "</TR>";
                                        File.AppendAllText(FBD.SelectedPath + @"\" + studyGroups[i].Title + ".html", str);

                                        if (day == 6)
                                        {
                                            str = "\n</TABLE>";
                                            File.AppendAllText(FBD.SelectedPath + @"\" + studyGroups[i].Title + ".html", str);
                                        }
                                    }
                                }
                                //конец документа
                                str = "\n</BODY>\n</HTML>";
                                File.AppendAllText(FBD.SelectedPath + @"\" + studyGroups[i].Title + ".html", str);
                            }
                        }
                    }
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
                //для Excel
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "xls|*.xls|xlsx|*.xlsx"
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (faculties.Count == 0)
                            {
                                MessageBox.Show("Выберите хоть один факультет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            //список групп
                            List<StudyGroupViewModel> studyGroups = GetCheckStudyGroups();//new List<StudyGroupViewModel>();
                            //сохранение файла с шаблоном
                            serviceR.SaveExcel(sfd.FileName, studyGroups);

                            //сохранение данных в файл
                            var excel = new Microsoft.Office.Interop.Excel.Application();
                            try
                            {
                                //открываем excel-файл
                                excel.Workbooks.Open(sfd.FileName, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing);

                                for (int i = 0; i < 6; i++)
                                {
                                    Sheets excelsheets = excel.Workbooks[1].Worksheets;
                                    //Получаем ссылку на лист       
                                    var excelworksheet = (Worksheet)excelsheets.get_Item(i + 1);

                                    //пока курс группы как курс на вкладке
                                    int count = 0;
                                    while (studyGroups.Count > 0 && studyGroups[0].Course == i + 1)
                                    {
                                        //получаем ссылку на ячейки             
                                        Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range(
                                             (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[3, 3 + count],
                                             (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[3, 3 + count]
                                         );
                                        //задаем текст, настройки шрифта и ячейки
                                        excelcells.Font.Bold = true;
                                        excelcells.Value2 = studyGroups[0].Title;
                                        excelcells.RowHeight = 25;
                                        excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                        excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                        excelcells.Font.Name = "Calibri";
                                        excelcells.Font.Size = 24;
                                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                        excelcells.ColumnWidth = 60;

                                        //записываем пары группы
                                        int selectedweek = 0;
                                        if (comboBoxWeek.SelectedIndex == 0)
                                            selectedweek = 1;
                                        else selectedweek = 2;

                                        //расставленные пары группы
                                        List<ScheduleViewModel> scheduleByStudyGroupFill = serviceS.GetListByPeroidAndStudyGroupFill(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), studyGroups[0].Id, "Занятие");

                                        string str = "";

                                        List<string> days = new List<string>() { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскреснье" };
                                        List<string> times = new List<string>() { "08.00-\n09.30", "09.40-\n11.10", "11.30-\n13.00", "13.10-\n14.40", "14.50-\n16.20", "16.30-\n18.00", "18.10-\n19.40", "19.50-\n21.20" };

                                        //иду по дням
                                        for (int day = 0; day < days.Count; day++)
                                        {
                                            //иду по парам
                                            for (int time = 0; time < times.Count; time++)
                                            {
                                                bool search = false;//нашли ли пару

                                                if (scheduleByStudyGroupFill.Count > 0)
                                                {
                                                    for (int j = 0; j < scheduleByStudyGroupFill.Count; j++)
                                                    {
                                                        if (scheduleByStudyGroupFill[j].NumberWeeks == selectedweek && scheduleByStudyGroupFill[j].DayOfTheWeek.ToString() == days[day]
                                                                        && scheduleByStudyGroupFill[j].ClassTimeNumber == time + 1)
                                                        {
                                                            //формируем значение ячейки
                                                            string educationalbuilding = serviceA.GetElement((Guid)scheduleByStudyGroupFill[j].AuditoriumId).EducationalBuilding;// № корпуса

                                                            str = "";
                                                            str = WriteSceduleStudyGroupToExcel(scheduleByStudyGroupFill[j], educationalbuilding, str);


                                                            scheduleByStudyGroupFill.Remove(scheduleByStudyGroupFill[j]);//удалили добавленный
                                                            j = -1;


                                                            //ищем остальные с такими данными
                                                            for (int k = 0; k < scheduleByStudyGroupFill.Count; k++)
                                                            {
                                                                if (scheduleByStudyGroupFill[k].NumberWeeks == selectedweek && scheduleByStudyGroupFill[k].DayOfTheWeek.ToString() == days[day]
                                                                                                && scheduleByStudyGroupFill[k].ClassTimeNumber == time + 1)
                                                                {
                                                                    str = WriteSceduleStudyGroupToExcel(scheduleByStudyGroupFill[k], educationalbuilding, str);

                                                                    scheduleByStudyGroupFill.Remove(scheduleByStudyGroupFill[k]);//удалили добавленный
                                                                    k--;
                                                                    j = -1;
                                                                }
                                                            }

                                                            //записываем пару

                                                            //получаем ссылку на ячейки             
                                                            excelcells = excelworksheet.get_Range(
                                                                 (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[(4 + time + 8 * day), 3 + count],
                                                                 (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[(4 + time + 8 * day), 3 + count]
                                                             );

                                                            //задаем текст, настройки шрифта и ячейки
                                                            excelcells.Value2 = str;
                                                            excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                                            excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                                            excelcells.Font.Name = "Calibri";
                                                            excelcells.Font.Size = 8;
                                                            excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                            excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                            excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                            excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                                                            search = true;
                                                        }
                                                    }
                                                    //если не нашли пару
                                                    if (!search)
                                                    {
                                                        //получаем ссылку на ячейки             
                                                        excelcells = excelworksheet.get_Range(
                                                             (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[(4 + time + 8 * day), 3 + count],
                                                             (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[(4 + time + 8 * day), 3 + count]
                                                         );

                                                        //пустая ячейка
                                                        //задаем текст, настройки шрифта и ячейки
                                                        excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                                        excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                                        //excelcells.Font.Name = "Calibri";
                                                        //excelcells.Font.Size = 8;
                                                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                    }
                                                }
                                                //получаем ссылку на ячейки             
                                                excelcells = excelworksheet.get_Range(
                                                     (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[(4 + time + 8 * day), 3 + count],
                                                     (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[(4 + time + 8 * day), 3 + count]
                                                 );

                                                //пустая ячейка
                                                //задаем текст, настройки шрифта и ячейки
                                                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                                                //excelcells.Font.Name = "Calibri";
                                                //excelcells.Font.Size = 8;
                                                excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                                excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                            }
                                        }
                                        studyGroups.Remove(studyGroups[0]);
                                        count++;
                                    }
                                }

                                //сохраняем 
                                excel.Workbooks[1].Save();
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                            finally
                            {
                                //закрываем      
                                excel.Quit();
                            }

                            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
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

                            string str;

                            //заполняем файл преподавателя
                            for (int j = 1; j < 3; j++)
                            {
                                //неделя
                                str = "<HTML>\n<HEAD>\n<TITLE>" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) +
                                    "</TITLE>\n<META NAME=\"Template\" CONTENT=\"C:\\PROGRAM FILES\\MICROSOFT OFFICE\\OFFICE\\html.dot\">\n" +
                                    "</HEAD>\n<BODY>\n" +
                                    "<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#0000ff\"><P>Расписание занятий преподавателя: </FONT>" +
                                    "<FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#ff00ff\">" + teachers[i].Surname + " " + teachers[i].Name.Substring(0, 1) + " " +
                                teachers[i].Patronymic.Substring(0, 1) + "<BR> Неделя: " + j + "-я</P></FONT>\n" +
                                "<TABLE BORDER CELLSPACING=3 BORDERCOLOR=\"#000000\" CELLPADDING=2 WIDTH=801>";

                                File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                                File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", WeekAndTime);

                                List<string> days = new List<string>() { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
                                for (int day = 0; day < days.Count; day++)
                                {
                                    //запись дня недели
                                    str = "<TR><TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                                "<B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\">" + days[day] + "</B></I></FONT></TD>";
                                    File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                                    WriteDayOfTheWeek(scheduleByTeacherFill, j, days[day], FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");

                                    str = "</TR>";
                                    File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);

                                    if (day == 6)
                                    {
                                        str = "\n</TABLE>";
                                        File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);
                                    }
                                }
                            }
                            //конец документа
                            str = "\n</BODY>\n</HTML>";
                            File.AppendAllText(FBD.SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html", str);
                        }
                    }

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
            }

            ////для аудиторий в html
            //if (comboBoxBy.SelectedIndex == 2)
            //{

            //}
        }

        //получения групп выбранных факультетов
        List<StudyGroupViewModel> GetCheckStudyGroups()
        {
            List<StudyGroupViewModel> studyGroups = new List<StudyGroupViewModel>();

            for (int i = 0; i < faculties.Count; i++)
            {
                Guid facultyId = service.GetElementByTitle(faculties[i]).Id;//id факультета

                List<SpecialtyViewModel> specialtyList = serviceSp.GetListByFaculty(facultyId);//все специальности факультета
                for (int j = 0; j < specialtyList.Count; j++)
                {
                    studyGroups.AddRange(serviceSG.GetListBySpecialty(specialtyList[j].Id));//все группы специальности
                }
            }

            //var result = studyGroups.OrderBy(studyGroup => studyGroup.Course);

            List<StudyGroupViewModel> studyGroups_sort = studyGroups.OrderBy(studyGroup => studyGroup.Course).ToList();

            return studyGroups_sort;
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

        void WriteDayOfTheWeekByStudyGroup(List<ScheduleViewModel> scheduleByStudyGroupFill, int NumberWeeks, string DayOfTheWeek, string SelectedPath)
        {
            string str = "";
            //запись одного дня недели
            int kol = 0;
            while (kol < 8)
            {
                bool search = false;//нашли ли пару

                if (scheduleByStudyGroupFill.Count > 0)
                {
                    for (int j = 0; j < scheduleByStudyGroupFill.Count; j++)
                    {
                        if (scheduleByStudyGroupFill[j].NumberWeeks == NumberWeeks && scheduleByStudyGroupFill[j].DayOfTheWeek.ToString() == DayOfTheWeek
                                                                && scheduleByStudyGroupFill[j].ClassTimeNumber == kol + 1)
                        {
                            //формируем значение ячейки
                            string educationalbuilding = serviceA.GetElement((Guid)scheduleByStudyGroupFill[j].AuditoriumId).EducationalBuilding;// № корпуса

                            str = "<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                   "<FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">";

                            str = WriteSceduleStudyGroup(scheduleByStudyGroupFill[j], educationalbuilding, str);

                            scheduleByStudyGroupFill.Remove(scheduleByStudyGroupFill[j]);//удалили добавленный
                            j = -1;

                            //ищем остальные с такими данными
                            for (int k = 0; k < scheduleByStudyGroupFill.Count; k++)
                            {
                                if (scheduleByStudyGroupFill[k].NumberWeeks == NumberWeeks && scheduleByStudyGroupFill[k].DayOfTheWeek.ToString() == DayOfTheWeek
                                                                && scheduleByStudyGroupFill[k].ClassTimeNumber == kol + 1)
                                {
                                    str = WriteSceduleStudyGroup(scheduleByStudyGroupFill[k], educationalbuilding, str);

                                    scheduleByStudyGroupFill.Remove(scheduleByStudyGroupFill[k]);//удалили добавленный
                                    k--;
                                    j = -1;
                                }
                            }

                            str += "</FONT></TD>";

                            //записываем пару
                            File.AppendAllText(SelectedPath, str);

                            search = true;
                        }
                    }
                    if (!search)
                    {
                        str = "<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                "<FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">_</br></br></FONT></TD>";
                        File.AppendAllText(SelectedPath, str);
                    }
                    //kol++;

                }
                else
                {
                    str = "<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28>\n" +
                                    "<FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">_</br></br></FONT></TD>";
                    File.AppendAllText(SelectedPath, str);

                    //kol++;
                }
                kol++;
            }
        }

        string WriteSceduleStudyGroup(ScheduleViewModel scheduleByStudyGroupFill, string educationalbuilding, string str)
        {
            str += scheduleByStudyGroupFill.TypeOfClassTitle + " " + scheduleByStudyGroupFill.DisciplineTitle;

            if (scheduleByStudyGroupFill.Subgroups != null)
            {
                str += " - " + scheduleByStudyGroupFill.Subgroups + " п/г";
            }

            str += "<BR>" + scheduleByStudyGroupFill.TeacherSurname + " " +
                    educationalbuilding + "-" + scheduleByStudyGroupFill.AuditoriumNumber + "<BR>";

            return str;
        }

        string WriteSceduleStudyGroupToExcel(ScheduleViewModel scheduleByStudyGroupFill, string educationalbuilding, string str)
        {
            str += scheduleByStudyGroupFill.TypeOfClassTitle + " " + scheduleByStudyGroupFill.DisciplineTitle;

            if (scheduleByStudyGroupFill.Subgroups != null)
            {
                str += " - " + scheduleByStudyGroupFill.Subgroups + " п/г";
            }
            str += "\n" + scheduleByStudyGroupFill.TeacherSurname + " " +
                    educationalbuilding + "-" + scheduleByStudyGroupFill.AuditoriumNumber + "\n";

            return str;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender; // приводим отправителя к элементу типа CheckBox

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

        private void comboBoxIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIn.SelectedIndex == 1)
            {
                label4.Visible = true;
                comboBoxWeek.Visible = true;
            }
            else
            {
                label4.Visible = false;
                comboBoxWeek.Visible = false;
            }
        }
    }
}
