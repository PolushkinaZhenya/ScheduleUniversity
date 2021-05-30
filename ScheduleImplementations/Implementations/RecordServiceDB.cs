using ScheduleServiceDAL.Interfaces;
using System;
using Microsoft.Office.Interop.Excel;
using System.IO;
using ScheduleServiceDAL.ViewModels;
using System.Collections.Generic;
using System.Configuration;

namespace ScheduleImplementations.Implementations
{
    public class RecordServiceDB : IRecordService
    {
        //сохраняем эксель
        public void SaveExcel(string FileName)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                //или создаем excel-файл, или открываем существующий    
                if (File.Exists(FileName))
                {
                    excel.Workbooks.Open(FileName, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(FileName, XlFileFormat.xlExcel8, Type.Missing,
                        Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                Sheets excelsheets = excel.Workbooks[1].Worksheets;
                //Получаем ссылку на лист       
                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                //очищаем ячейки           
                excelworksheet.Cells.Clear();
                //настройки страницы              
                excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                excelworksheet.PageSetup.CenterHorizontally = true;
                excelworksheet.PageSetup.CenterVertically = true;
                //получаем ссылку на первые 3 ячейки             
                Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range("A1", "E1");
                //объединяем их           
                excelcells.Merge(Type.Missing);
                //задаем текст, настройки шрифта и ячейки  
                excelcells.Font.Bold = true;
                excelcells.Value2 = "Расписание";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                //дата
                //excelcells = excelworksheet.get_Range("A2", "C2");
                //excelcells.Merge(Type.Missing);
                //excelcells.Value2 = "на" + DateTime.Now.ToShortDateString();
                //excelcells.RowHeight = 20;
                //excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                //excelcells.Font.Name = "Times New Roman";
                //excelcells.Font.Size = 12;


                //var dict = GetStoragesLoad();
                //if (dict != null)
                //{
                //    excelcells = excelworksheet.get_Range("C1", "C1");
                //    foreach (var elem in dict)
                //    {
                //        //спускаемся на 2 ячейку вниз и 2 ячейкт влево 
                //        excelcells = excelcells.get_Offset(2, -2);
                //        excelcells.ColumnWidth = 15;
                //        excelcells.Value2 = elem.StorageName;
                //        excelcells = excelcells.get_Offset(1, 1);
                //        //обводим границы                   
                //        if (elem.Parts.Count() > 0)
                //        {
                //            //получаем ячейкт для выбеления рамки под таблицу    
                //            var excelBorder =
                //                excelworksheet.get_Range(excelcells,
                //                excelcells.get_Offset(elem.Parts.Count() - 1, 1));
                //            excelBorder.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                //            excelBorder.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                //            excelBorder.HorizontalAlignment = Constants.xlCenter;
                //            excelBorder.VerticalAlignment = Constants.xlCenter;
                //            excelBorder.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
                //                Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,
                //                Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                //                1);

                //            foreach (var listElem in elem.Parts)
                //            {
                //                excelcells.Value2 = listElem.Item1;
                //                excelcells.ColumnWidth = 10;
                //                excelcells.get_Offset(0, 1).Value2 = listElem.Item2;
                //                excelcells = excelcells.get_Offset(1, 0);
                //            }
                //        }
                //        excelcells = excelcells.get_Offset(0, -1);
                //        excelcells.Value2 = "Итого";
                //        excelcells.Font.Bold = true;
                //        excelcells = excelcells.get_Offset(0, 2);
                //        excelcells.Value2 = elem.TotalCount;
                //        excelcells.Font.Bold = true;
                //    }
                //}

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

        //сохраняем html для учебных занятий
        public void SaveHtmlStudyGroups(string SelectedPath, List<StudyGroupViewModel> studyGroups)
        {
            try
            {
                //копируем общий файл
                File.Copy(@"D:\ПИбд\4 курс\Диплом\ScheduleUniversity\ScheduleView\Templates\StudyGroups.html", SelectedPath + @"\praspisan.html");

                //для каждой группы

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
