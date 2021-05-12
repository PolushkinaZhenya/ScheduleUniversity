using ScheduleServiceDAL.Interfaces;
using System;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;

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

        //сохраняем html
        public void SaveHtml(string FileName)
        {
            try
            {
                //HtmlDocument htmldoc;

                ////создадим WebBrowser и загрузим в него пустой документ
                //WebBrowser wb = new WebBrowser();
                //wb.DocumentText = "";
                //while (wb.ReadyState != WebBrowserReadyState.Complete) Application.DoEvents();
                ///*На практике загрузка пустой строки произойдет очень быстро, поэтому
                // можно использовать блокирующий цикл вместо подписки на событие DocumentCompleted*/

                ////заполним содержимое документа
                //htmldoc = wb.Document;
                //htmldoc.Title = "Hello";

                //HtmlElement el = htmldoc.CreateElement("h1");
                //el.InnerText = "Hello, world!";
                //htmldoc.Body.AppendChild(el);

                //el = htmldoc.CreateElement("div");
                //el.InnerText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
                //htmldoc.Body.AppendChild(el);

                ////получаем все содержимое документа в виде html
                //string s = htmldoc.GetElementsByTagName("html")[0].OuterHtml;


                //потом цикл с авто созданием файлов

                StreamWriter streamwriter = new StreamWriter(@FileName);
                streamwriter.WriteLine("<html>");
                streamwriter.WriteLine("<head>");
                streamwriter.WriteLine("  <title>HTML-Document</title>");
                streamwriter.WriteLine("  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
                streamwriter.WriteLine("</head>");
                streamwriter.WriteLine("<body>");
                streamwriter.WriteLine("Привет");
                streamwriter.WriteLine("</body>");
                streamwriter.WriteLine("</html>");
                streamwriter.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
