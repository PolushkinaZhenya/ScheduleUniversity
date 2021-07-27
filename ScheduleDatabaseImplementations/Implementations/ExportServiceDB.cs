using Microsoft.Office.Interop.Excel;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class ExportServiceDB : IExportService
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
		public void SaveHtmlTeachers(HtmlTeachersBindingModel model)
		{
			if (Directory.Exists(model.SelectedPath))
			{
				var dirInfo = new DirectoryInfo(model.SelectedPath);
				foreach (FileInfo file in dirInfo.GetFiles())
				{
					file.Delete();
				}
			}
			using var sw = new StreamWriter(@$"{model.SelectedPath}\praspisan.html", false, Encoding.UTF8);
			sw.WriteLine("<HTML>");
			sw.WriteLine("\t<HEAD>");
			sw.WriteLine("\t\t<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=windows-1251\">");
			sw.WriteLine("\t\t<META NAME=\"Generator\" CONTENT=\"Microsoft Word 97\">");
			sw.WriteLine("\t\t<TITLE>praspisan</TITLE>");
			sw.WriteLine("\t</HEAD>");
			sw.WriteLine("\t<BODY LINK=\"#0000ff\" VLINK=\"#800080\">");
			sw.WriteLine("\t\t<FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#0000ff\"><P>Расписание занятий преподавателей</P></FONT>");
			sw.WriteLine("\t\t<FONT SIZE=5></FONT>");
			sw.WriteLine("\t\t<TABLE BORDER CELLSPACING=1 CELLPADDING=3 WIDTH=623>");
			sw.WriteLine("\t\t\t<TR>");
			sw.WriteLine("\t\t\t\t<TD WIDTH=\"17%\" VALIGN=\"TOP\">");
			sw.WriteLine("\t\t\t\t<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#ff00ff\"><P ALIGN=\"CENTER\">ФИО, кафедра</FONT>");
			sw.WriteLine("\t\t\t\t</TD>");
			sw.WriteLine("\t\t\t</TR>");

			//для каждого преподавателя
			for (int i = 0; i < model.Data.Count; i++)
			{
				string teacher = $"<TR><TD WIDTH=\"17%\" VALIGN=\"TOP\">\n <P ALIGN=\"CENTER\"><A HREF=\"{model.Data[i].ShortName}.html\"><FONT FACE=\"Times New Roman\">{model.Data[i].ShortName}</FONT></A></TD>\n</TR>\n";
				sw.WriteLine(model.SelectedPath + @"\praspisan.html", teacher);
				CreateTeacherSchedule(model.SelectedPath, model.Data[i], model.Lessons.Where(x => x.TeacherId == model.Data[i].Id).ToList(), model.Classtimes);
			}
			// конец html
			sw.WriteLine("\t\t</TABLE>");
			sw.WriteLine("\t</BODY>");
			sw.WriteLine("</HTML>");
		}

		private static void CreateTeacherSchedule(string selectedPath, TeacherViewModel teacher, List<ScheduleViewModel> lessons, List<ClassTimeViewModel> classtimes)
		{
			using var sw = new StreamWriter(@$"{selectedPath}\{teacher.ShortName}.html", false, Encoding.UTF8);
			sw.WriteLine("<HTML>");
			sw.WriteLine("\t<HEAD>");
			sw.WriteLine("\t\t<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=windows-1251\">");
			sw.WriteLine("\t\t<META NAME=\"Generator\" CONTENT=\"Microsoft Word 97\">");
			sw.WriteLine($"\t\t<TITLE>{teacher.ShortName}</TITLE>");
			sw.WriteLine("\t\t<META NAME=\"Template\" CONTENT=\"C:\\PROGRAM FILES\\MICROSOFT OFFICE\\OFFICE\\html.dot\">");
			sw.WriteLine("\t</HEAD>");
			sw.WriteLine("\t<BODY>");
			for (int week = 1; week < 3; week++)
			{
				sw.WriteLine($"\t\t<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#0000ff\"><P>Расписание занятий преподавателя:</FONT><FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#ff00ff\">{teacher.ShortName}<BR> Неделя: {week}-я</P></FONT>");
				sw.WriteLine("\t\t<TABLE BORDER CELLSPACING=3 BORDERCOLOR=\"#000000\" CELLPADDING=2 WIDTH=801>");
				sw.WriteLine("\t\t\t<TR>");
				sw.WriteLine("\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">Пары</FONT></TD>");
				for (int i = 0; i < classtimes.Count; ++i)
				{
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><FONT FACE=\"Arial\"><P ALIGN=\"CENTER\">{(i + 1)}-я</FONT></TD>");
				}
				sw.WriteLine("\t\t\t</TR>");

				sw.WriteLine("\t\t\t<TR>");
				sw.WriteLine("\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">Время</FONT></TD>");
				for (int i = 0; i < classtimes.Count; ++i)
				{
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\">{classtimes[i].StartTime:hh\\:mm}-{classtimes[i].EndTime:hh\\:mm}</TD>");
				}
				sw.WriteLine("\t\t\t</TR>");

				foreach (DayOfTheWeek dow in Enum.GetValues(typeof(DayOfTheWeek)))
				{
					sw.WriteLine("\t\t\t<TR>");
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">{dow}</FONT></I></B></TD>");
					for (int i = 0; i < classtimes.Count; ++i)
					{
						var les = lessons.Where(x => x.NumberWeeks == week && x.DayOfTheWeek == dow && x.ClassTimeId == classtimes[i].Id);
						var str = les == null || !les.Any() ? "_</br></br>" : string.Join("</br>", les.Select(l => $"{l.StudyGroupTitle}</br>{l.TypeOfClassShort}.{l.DisciplineTitle}</br>{l.AuditoriumNumber}"));
						sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">{str}</FONT></TD>");
					}
					sw.WriteLine("\t\t\t</TR>");
				}
				sw.WriteLine("\t\t</TABLE>");
			}

			sw.WriteLine("\t</BODY>");
			sw.WriteLine("</HTML>");
		}

		//сохраняем html для учебных групп
		public void SaveHtmlStudyGroups(HtmlStudyGroupsBindingModel model)
		{
			if (Directory.Exists(model.SelectedPath))
			{
				var dirInfo = new DirectoryInfo(model.SelectedPath);
				foreach (FileInfo file in dirInfo.GetFiles())
				{
					file.Delete();
				}
			}
			using var sw = new StreamWriter(@$"{model.SelectedPath}\raspisan.html", false, Encoding.UTF8);
			sw.WriteLine("<HTML>");
			sw.WriteLine("\t<HEAD>");
			sw.WriteLine("\t\t<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=windows-1251\">");
			sw.WriteLine("\t\t<META NAME=\"Generator\" CONTENT=\"Microsoft Word 97\">");
			sw.WriteLine("\t\t<TITLE>raspisan</TITLE>");
			sw.WriteLine("\t</HEAD>");
			sw.WriteLine("\t<BODY LINK=\"#0000ff\" VLINK=\"#800080\">");
			sw.WriteLine("\t\t<FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#0000ff\"><P>Расписание занятий студентов</P></FONT>");
			sw.WriteLine("\t\t<FONT SIZE=5></FONT>");
			sw.WriteLine("\t\t<TABLE BORDER CELLSPACING=1 CELLPADDING=3 WIDTH=680>");
			sw.WriteLine("\t\t\t<TR>");
			var courses = model.Data.Select(x => x.Course).Distinct().OrderBy(x => x).ToList();
			for (int i = 0; i < courses.Count; ++i)
			{
				sw.WriteLine($"\t\t\t\t<TD WIDTH=\"{100 / courses.Count}%\" VALIGN=\"TOP\">");
				sw.WriteLine($"\t\t\t\t<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#ff00ff\"><P ALIGN=\"CENTER\"> {courses[i]} курс </FONT>");
				sw.WriteLine("\t\t\t\t</TD>");
			}
			sw.WriteLine("\t\t\t</TR>");

			model.Data = model.Data.OrderBy(x => x.Course).ThenBy(x => x.Title).ToList();
			var counters = new int[courses.Count];
			while (model.Data.Count > 0)
			{
				sw.WriteLine("\t\t\t<TR>");
				for (int i = 0; i < courses.Count; ++i)
				{
					var group = model.Data.FirstOrDefault(x => x.Course == courses[i]);
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"{100 / courses.Count}%\" VALIGN=\"TOP\">");
					if (group != null)
					{
						sw.WriteLine($"\t\t\t\t<P ALIGN=\"CENTER\"><A HREF=\"{courses[i]}{counters[i]}.html\"><FONT FACE=\"Times New Roman\">{group.Title}</FONT></A>");
						model.Data.Remove(group);
						CreateStudyGroupSchedule(model.SelectedPath, $"{courses[i]}{counters[i]}", group, model.Lessons, model.Classtimes);
					}
					else
					{
						sw.WriteLine($"\t\t\t\t<P ALIGN=\"CENTER\"><A HREF=\"{courses[i]}{counters[i]}.html\"><FONT FACE=\"Times New Roman\"></FONT></A>");
					}
					sw.WriteLine("\t\t\t\t</TD>");
				}
				sw.WriteLine("\t\t\t</TR>");
			}
			// конец html
			sw.WriteLine("\t\t</TABLE>");
			sw.WriteLine("\t</BODY>");
			sw.WriteLine("</HTML>");
		}

		private static void CreateStudyGroupSchedule(string selectedPath, string fileName, StudyGroupViewModel studyGroup, List<ScheduleViewModel> lessons, List<ClassTimeViewModel> classtimes)
		{
			using var sw = new StreamWriter(@$"{selectedPath}\{fileName}.html", false, Encoding.UTF8);
			sw.WriteLine("<HTML>");
			sw.WriteLine("\t<HEAD>");
			sw.WriteLine("\t\t<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=windows-1251\">");
			sw.WriteLine("\t\t<META NAME=\"Generator\" CONTENT=\"Microsoft Word 97\">");
			sw.WriteLine($"\t\t<TITLE>{fileName}</TITLE>");
			sw.WriteLine("\t\t<META NAME=\"Template\" CONTENT=\"C:\\PROGRAM FILES\\MICROSOFT OFFICE\\OFFICE\\html.dot\">");
			sw.WriteLine("\t</HEAD>");
			sw.WriteLine("\t<BODY>");
			for (int week = 1; week < 3; week++)
			{
				sw.WriteLine($"\t\t<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#0000ff\"><P>Расписание занятий учебной группы:</FONT><FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#ff00ff\">{studyGroup.Title}<BR> Неделя: {week}-я</P></FONT>");
				sw.WriteLine("\t\t<TABLE BORDER CELLSPACING=3 BORDERCOLOR=\"#000000\" CELLPADDING=2 WIDTH=801>");
				sw.WriteLine("\t\t\t<TR>");
				sw.WriteLine("\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">Пары</FONT></TD>");
				for (int i = 0; i < classtimes.Count; ++i)
				{
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><FONT FACE=\"Arial\"><P ALIGN=\"CENTER\">{(i + 1)}-я</FONT></TD>");
				}
				sw.WriteLine("\t\t\t</TR>");

				sw.WriteLine("\t\t\t<TR>");
				sw.WriteLine("\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">Время</FONT></TD>");
				for (int i = 0; i < classtimes.Count; ++i)
				{
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\">{classtimes[i].StartTime:hh\\:mm}-{classtimes[i].EndTime:hh\\:mm}</TD>");
				}
				sw.WriteLine("\t\t\t</TR>");

				foreach (DayOfTheWeek dow in Enum.GetValues(typeof(DayOfTheWeek)))
				{
					sw.WriteLine("\t\t\t<TR>");
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">{dow}</FONT></I></B></TD>");
					for (int i = 0; i < classtimes.Count; ++i)
					{
						var les = lessons.Where(x => x.NumberWeeks == week && x.DayOfTheWeek == dow && x.ClassTimeId == classtimes[i].Id);
						var str = les == null || !les.Any() ? "_</br></br>" : string.Join("</br>", les.Select(l => $"{l.StudyGroupTitle}</br>{l.TypeOfClassShort}.{l.DisciplineTitle}</br>{l.AuditoriumNumber}"));
						sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">{str}</FONT></TD>");
					}
					sw.WriteLine("\t\t\t</TR>");
				}
				sw.WriteLine("\t\t</TABLE>");
			}

			sw.WriteLine("\t</BODY>");
			sw.WriteLine("</HTML>");
		}

		//сохраняем html для учебных групп
		public void SaveHtmlAuditoriums(HtmlAuditoriumsBindingModel model)
		{
			if (Directory.Exists(model.SelectedPath))
			{
				var dirInfo = new DirectoryInfo(model.SelectedPath);
				foreach (FileInfo file in dirInfo.GetFiles())
				{
					file.Delete();
				}
			}
			using var sw = new StreamWriter(@$"{model.SelectedPath}\aaspisan.html", false, Encoding.UTF8);
			sw.WriteLine("<HTML>");
			sw.WriteLine("\t<HEAD>");
			sw.WriteLine("\t\t<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=windows-1251\">");
			sw.WriteLine("\t\t<META NAME=\"Generator\" CONTENT=\"Microsoft Word 97\">");
			sw.WriteLine("\t\t<TITLE>aaspisan</TITLE>");
			sw.WriteLine("\t</HEAD>");
			sw.WriteLine("\t<BODY LINK=\"#0000ff\" VLINK=\"#800080\">");
			sw.WriteLine("\t\t<FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#0000ff\"><P>Расписание занятий аудиторий</P></FONT>");
			sw.WriteLine("\t\t<FONT SIZE=5></FONT>");
			sw.WriteLine("\t\t<TABLE BORDER CELLSPACING=1 CELLPADDING=3 WIDTH=680>");
			sw.WriteLine("\t\t\t<TR>");
			var buildings = model.Data.Select(x => x.EducationalBuilding).Distinct().OrderBy(x => x).ToList();
			for (int i = 0; i < buildings.Count; ++i)
			{
				sw.WriteLine($"\t\t\t\t<TD WIDTH=\"{100 / buildings.Count}%\" VALIGN=\"TOP\">");
				sw.WriteLine($"\t\t\t\t<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#ff00ff\"><P ALIGN=\"CENTER\">{buildings[i]}</FONT>");
				sw.WriteLine("\t\t\t\t</TD>");
			}
			sw.WriteLine("\t\t\t</TR>");

			model.Data = model.Data.OrderBy(x => x.EducationalBuilding).ThenBy(x => x.Number).ToList();
			var counters = new int[buildings.Count];
			while (model.Data.Count > 0)
			{
				sw.WriteLine("\t\t\t<TR>");
				for (int i = 0; i < buildings.Count; ++i)
				{
					var aud = model.Data.FirstOrDefault(x => x.EducationalBuilding == buildings[i]);
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"{100 / buildings.Count}%\" VALIGN=\"TOP\">");
					if (aud != null)
					{
						sw.WriteLine($"\t\t\t\t<P ALIGN=\"CENTER\"><A HREF=\"{buildings[i]}{counters[i]}.html\"><FONT FACE=\"Times New Roman\">{aud.Number}</FONT></A>");
						model.Data.Remove(aud);
						CreatelAuditoriumSchedule(model.SelectedPath, $"{buildings[i]}{counters[i]}", aud, model.Lessons, model.Classtimes);
					}
					else
					{
						sw.WriteLine($"\t\t\t\t<P ALIGN=\"CENTER\"><A HREF=\"{buildings[i]}{counters[i]}.html\"><FONT FACE=\"Times New Roman\"></FONT></A>");
					}
					sw.WriteLine("\t\t\t\t</TD>");
				}
				sw.WriteLine("\t\t\t</TR>");
			}
			// конец html
			sw.WriteLine("\t\t</TABLE>");
			sw.WriteLine("\t</BODY>");
			sw.WriteLine("</HTML>");
		}

		private static void CreatelAuditoriumSchedule(string selectedPath, string fileName, AuditoriumViewModel auditorium, List<ScheduleViewModel> lessons, List<ClassTimeViewModel> classtimes)
		{
			using var sw = new StreamWriter(@$"{selectedPath}\{fileName}.html", false, Encoding.UTF8);
			sw.WriteLine("<HTML>");
			sw.WriteLine("\t<HEAD>");
			sw.WriteLine("\t\t<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=windows-1251\">");
			sw.WriteLine("\t\t<META NAME=\"Generator\" CONTENT=\"Microsoft Word 97\">");
			sw.WriteLine($"\t\t<TITLE>{fileName}</TITLE>");
			sw.WriteLine("\t\t<META NAME=\"Template\" CONTENT=\"C:\\PROGRAM FILES\\MICROSOFT OFFICE\\OFFICE\\html.dot\">");
			sw.WriteLine("\t</HEAD>");
			sw.WriteLine("\t<BODY>");
			for (int week = 1; week < 3; week++)
			{
				sw.WriteLine($"\t\t<FONT FACE=\"Times New Roman\" SIZE=5 COLOR=\"#0000ff\"><P>Расписание занятий аудитории:</FONT><FONT FACE=\"Times New Roman\" SIZE=6 COLOR=\"#ff00ff\">{auditorium.Number}<BR> Неделя: {week}-я</P></FONT>");
				sw.WriteLine("\t\t<TABLE BORDER CELLSPACING=3 BORDERCOLOR=\"#000000\" CELLPADDING=2 WIDTH=801>");
				sw.WriteLine("\t\t\t<TR>");
				sw.WriteLine("\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">Пары</FONT></TD>");
				for (int i = 0; i < classtimes.Count; ++i)
				{
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><FONT FACE=\"Arial\"><P ALIGN=\"CENTER\">{(i + 1)}-я</FONT></TD>");
				}
				sw.WriteLine("\t\t\t</TR>");

				sw.WriteLine("\t\t\t<TR>");
				sw.WriteLine("\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">Время</FONT></TD>");
				for (int i = 0; i < classtimes.Count; ++i)
				{
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><P ALIGN=\"CENTER\">{classtimes[i].StartTime:hh\\:mm}-{classtimes[i].EndTime:hh\\:mm}</TD>");
				}
				sw.WriteLine("\t\t\t</TR>");

				foreach (DayOfTheWeek dow in Enum.GetValues(typeof(DayOfTheWeek)))
				{
					sw.WriteLine("\t\t\t<TR>");
					sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><B><I><FONT FACE=\"Arial\" SIZE=2><P ALIGN=\"CENTER\"><FONT FACE=\"Arial\">{dow}</FONT></I></B></TD>");
					for (int i = 0; i < classtimes.Count; ++i)
					{
						var les = lessons.Where(x => x.NumberWeeks == week && x.DayOfTheWeek == dow && x.ClassTimeId == classtimes[i].Id);
						var str = les == null || !les.Any() ? "_</br></br>" : string.Join("</br>", les.Select(l => $"{l.StudyGroupTitle}</br>{l.TypeOfClassShort}.{l.DisciplineTitle}</br>{l.TeacherShortName}"));
						sw.WriteLine($"\t\t\t\t<TD WIDTH=\"11%\" VALIGN=\"TOP\" HEIGHT=28><FONT FACE=\"Arial\" SIZE=1><P ALIGN=\"CENTER\">{str}</FONT></TD>");
					}
					sw.WriteLine("\t\t\t</TR>");
				}
				sw.WriteLine("\t\t</TABLE>");
			}

			sw.WriteLine("\t</BODY>");
			sw.WriteLine("</HTML>");
		}
	}
}
