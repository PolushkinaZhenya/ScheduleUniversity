using ScheduleBusinessLogic.Interfaces;
using System;
using Microsoft.Office.Interop.Excel;
using System.IO;
using ScheduleBusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Configuration;

namespace ScheduleDatabaseImplementations.Implementations
{
    public class RecordServiceDB : IRecordService
    {
        //сохраняем эксель
        public void SaveExcel(string FileName, List<StudyGroupViewModel> studyGroups)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                //создаем excel-файл, или открываем существующий    
                if (File.Exists(FileName))
                {
                    excel.Workbooks.Open(FileName, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);
                }
                else
                {
                    //кол-во листов
                    excel.SheetsInNewWorkbook = 6;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(FileName, XlFileFormat.xlExcel8, Type.Missing,
                        Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                for (int i = 0; i < 6; i++)
                {
                    Sheets excelsheets = excel.Workbooks[1].Worksheets;
                    //Получаем ссылку на лист       
                    var excelworksheet = (Worksheet)excelsheets.get_Item(i + 1);

                    //очищаем ячейки           
                    excelworksheet.Cells.Clear();

                    //настройки страницы              
                    excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                    excelworksheet.PageSetup.CenterHorizontally = true;
                    excelworksheet.PageSetup.CenterVertically = true;
                    excelworksheet.Name = i + 1 + " курс";


                    //получаем ссылку на первые 4 ячейки             
                    Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range(
                        (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[1, 1],
                        (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[2, 2]
                    );
                    //объединяем их           
                    excelcells.Merge(Type.Missing);
                    //задаем текст, настройки шрифта и ячейки  
                    //excelcells.Font.Bold = true;
                    excelcells.Value2 = "\"УТВЕРЖДАЮ\"\n______________\nПроректор по УР\nА.Н.Бескопыльный";
                    //excelcells.RowHeight = 25;
                    excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    excelcells.Font.Name = "Calibri";
                    excelcells.Font.Size = 6;
                    excelcells.Rows.RowHeight = 40;

                    //получаем ссылку на ячейки             
                    excelcells = excelworksheet.get_Range(
                         (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[3, 1],
                         (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[3, 1]
                     );
                    //задаем текст, настройки шрифта и ячейки
                    excelcells.Value2 = "Дни";
                    //excelcells.RowHeight = 25;
                    excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    excelcells.Font.Name = "Calibri";
                    excelcells.Font.Size = 11;
                    excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelcells.Columns.ColumnWidth = 5;
                    excelcells.Rows.RowHeight = 30;


                    //получаем ссылку на ячейки             
                    excelcells = excelworksheet.get_Range(
                         (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[3, 2],
                         (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[3, 2]
                     );
                    //задаем текст, настройки шрифта и ячейки
                    excelcells.Value2 = "Часы";
                    excelcells.RowHeight = 25;
                    excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    excelcells.Font.Name = "Calibri";
                    excelcells.Font.Size = 11;
                    excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelcells.Columns.ColumnWidth = 5;


                    List<string> days = new List<string>() { "П\nО\nН\nЕ\nД\nЕ\nЛ\nЬ\nН\nИ\nК", "В\nТ\nО\nР\nН\nИ\nК", "С\nР\nЕ\nД\nА", "Ч\nЕ\nТ\nВ\nЕ\nР\nГ",
                        "П\nЯ\nТ\nН\nИ\nЦ\nА", "С\nУ\nБ\nБ\nО\nТ\nА", "В\nО\nС\nК\nР\nЕ\nС\nЕ\nН\nЬ\nЕ" };
                    List<string> times = new List<string>() { "08.00-\n09.30", "09.40-\n11.10", "11.30-\n13.00", "13.10-\n14.40", "14.50-\n16.20", "16.30-\n18.00", "18.10-\n19.40", "19.50-\n21.20" };

                    for (int day = 0; day < days.Count; day++)
                    {
                        //получаем ссылку на ячейки             
                        excelcells = excelworksheet.get_Range(
                             (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[4 + 8 * day, 1],
                             (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[4 + 8 * day + 7, 1]
                         );
                        //объединяем их           
                        excelcells.Merge(Type.Missing);
                        //задаем текст, настройки шрифта и ячейки
                        excelcells.Font.Bold = true;
                        excelcells.Value2 = days[day];
                        excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelcells.Font.Name = "Calibri";
                        excelcells.Font.Size = 10;
                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                        for (int time = 0; time < times.Count; time++)
                        {
                            //получаем ссылку на ячейки             
                            excelcells = excelworksheet.get_Range(
                                 (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[4 + time + 8 * day, 2],
                                 (Microsoft.Office.Interop.Excel.Range)excelworksheet.Cells[4 + time + 8 * day, 2]
                             );
                            //задаем текст, настройки шрифта и ячейки
                            excelcells.Value2 = times[time];
                            excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            excelcells.Font.Name = "Calibri";
                            excelcells.Font.Size = 11;
                            excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelcells.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                            excelcells.Rows.RowHeight = 50;
                        }
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
        }

        //сохраняем html для преподавателей
        public void SaveHtmlTeachers(string SelectedPath, List<TeacherViewModel> teachers)
        {
            try
            {
                //копируем общий файл
                File.Copy(@"D:\ПИбд\4 курс\Диплом\ScheduleUniversity\ScheduleView\Templates\teachers.html", SelectedPath + @"\praspisan.html");

                //для каждого преподавателя
                for (int i = 0; i < teachers.Count; i++)
                {
                    //заполняем общий файл с таблицей
                    string teacher = "<TR><TD WIDTH=\"17%\" VALIGN=\"TOP\">\n <P ALIGN=\"CENTER\"><A HREF=\"" +
                    teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) +
                    ".html\"><FONT FACE=\"Times New Roman\">" + teachers[i].Surname + " " + teachers[i].Name.Substring(0, 1) + " " +
                    teachers[i].Patronymic.Substring(0, 1) + "</FONT></A></TD>\n</TR>\n";

                    File.AppendAllText(SelectedPath + @"\praspisan.html", teacher);


                    //создаем файл преподавателя
                    StreamWriter sw = new StreamWriter(SelectedPath + @"\" + teachers[i].Surname + teachers[i].Name.Substring(0, 1) + teachers[i].Patronymic.Substring(0, 1) + ".html");
                    sw.Close();
                }
                // конец html
                string end = "\n" + "</TABLE>" + "\n" + "</BODY>" + "</HTML>";

                File.AppendAllText(SelectedPath + @"\praspisan.html", end);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //сохраняем html для учебных групп
        public void SaveHtmlStudyGroups(string SelectedPath, List<StudyGroupViewModel> studyGroups)
        {
            try
            {
                //копируем общий файл
                File.Copy(@"D:\ПИбд\4 курс\Диплом\ScheduleUniversity\ScheduleView\Templates\StudyGroups.html", SelectedPath + @"\praspisan.html");

                //для всех групп
                for (int i = 0; i < studyGroups.Count; i++)
                {
                    //создаем файл группы
                    StreamWriter sw = new StreamWriter(SelectedPath + @"\" + studyGroups[i].Title + ".html");
                    sw.Close();
                }

                List<StudyGroupViewModel> studyGroupsCopy = studyGroups;

                while (studyGroupsCopy.Count > 0)
                {
                    string str = "<TR>\n";
                    File.AppendAllText(SelectedPath + @"\praspisan.html", str);

                    int cours = 1;
                    while (cours < 7)
                    {
                        bool search = false;
                        for (int j = 0; j < studyGroupsCopy.Count; j++)
                        {
                            if (studyGroupsCopy[j].Course == cours)
                            {
                                //формируем значение ячейки
                                str = "<TD WIDTH=\"17%\" VALIGN=\"TOP\">\n" +
                                    "<P ALIGN=\"CENTER\"><A HREF=\"" + studyGroupsCopy[j].Title +
                                    ".html\"><FONT FACE=\"Times New Roman\">" + studyGroupsCopy[j].Title + "</FONT></A></TD>\n";

                                File.AppendAllText(SelectedPath + @"\praspisan.html", str);

                                studyGroupsCopy.Remove(studyGroupsCopy[j]);//удаляем из списка добавленную группу
                                search = true;
                                break;
                            }
                        }
                        if (!search)
                        {
                            str = "<TD WIDTH=\"17%\" VALIGN=\"TOP\">\n<P ALIGN=\"CENTER\"><A HREF=\"\"><FONT FACE=\"Times New Roman\"></FONT></A></TD>\n";
                            File.AppendAllText(SelectedPath + @"\praspisan.html", str);
                        }
                        cours++;
                    }

                    str = "\n</TR>";
                    File.AppendAllText(SelectedPath + @"\praspisan.html", str);
                }
                // конец html
                string end = "\n" + "</TABLE>" + "\n" + "</BODY>" + "</HTML>";

                File.AppendAllText(SelectedPath + @"\praspisan.html", end);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
