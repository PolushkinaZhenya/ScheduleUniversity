using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormUpload : Form
	{
		private bool _canUploadStudyGroups;

		private bool _canUploadTeachers;

		private bool _canUploadAuditoirums;

		public FormUpload()
		{
			InitializeComponent();
			_canUploadStudyGroups = _canUploadTeachers = _canUploadAuditoirums = false;
		}

		private void ButtonUploadStudyGroupSelectFolder_Click(object sender, EventArgs e)
		{
			var fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				buttonUploadStudyGroupSelectFolder.Text = fbd.SelectedPath;
				_canUploadStudyGroups = true;
			}
		}

		private async void ButtonLaunchUploadStudyGroups_Click(object sender, EventArgs e)
		{
			if (!_canUploadStudyGroups)
			{
				Program.ShowError("Не выбран путь до папки", "Ошибка");
				return;
			}
			var foplderPath = buttonUploadStudyGroupSelectFolder.Text;

			await Task.Run(() => {
				try
				{
					Guid? periodId = null;
					var period = Program.ReadAppSettingConfig(Program.CurrentPeriod);

					if (period.IsNotEmpty())
					{
						periodId = new Guid(period);
					}
					if (!periodId.HasValue)
					{
						throw new Exception("Не определен период");
					}
					var exportService = DependencyManager.Instance.Resolve<IExportService>();
					var classTiemService = DependencyManager.Instance.Resolve<IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel>>();
					var studyGroupService = DependencyManager.Instance.Resolve<IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel>>();
					var schedulesService = DependencyManager.Instance.Resolve<IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel>>();
					exportService.SaveHtmlStudyGroups(new HtmlStudyGroupsBindingModel
					{
						SelectedPath = foplderPath,
						Classtimes = classTiemService.GetList(),
						Data = studyGroupService.GetList(),
						Lessons = schedulesService.GetList(new ScheduleSearchModel { PeriodId = periodId })
					});
					Program.ShowInfo("Выгрузка по группам в html прошла успешно!", "Результат выгрузки");
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка выгрузки списка занятий по группам в html");
					return;
				} 
			});
		}

		private void ButtonUploadTeacherSelectFolder_Click(object sender, EventArgs e)
		{
			var fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				buttonUploadTeacherSelectFolder.Text = fbd.SelectedPath;
				_canUploadTeachers = true;
			}
		}

		private async void ButtonLaunchUploadTeachers_Click(object sender, EventArgs e)
		{
			if (!_canUploadTeachers)
			{
				Program.ShowError("Не выбран путь до папки", "Ошибка");
				return;
			}
			var foplderPath = buttonUploadTeacherSelectFolder.Text;

			await Task.Run(() => {
				try
				{
					Guid? periodId = null;
					var period = Program.ReadAppSettingConfig(Program.CurrentPeriod);

					if (period.IsNotEmpty())
					{
						periodId = new Guid(period);
					}
					if (!periodId.HasValue)
					{
						throw new Exception("Не определен период");
					}
					var exportService = DependencyManager.Instance.Resolve<IExportService>();
					var classTiemService = DependencyManager.Instance.Resolve<IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel>>();
					var teacherService = DependencyManager.Instance.Resolve<IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel>>();
					var schedulesService = DependencyManager.Instance.Resolve<IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel>>();
					exportService.SaveHtmlTeachers(new HtmlTeachersBindingModel
					{
						SelectedPath = foplderPath,
						Classtimes = classTiemService.GetList(),
						Data = teacherService.GetList(),
						Lessons = schedulesService.GetList(new ScheduleSearchModel { PeriodId = periodId })
					});
					Program.ShowInfo("Выгрузка по преподавателям в html прошла успешно!", "Результат выгрузки");
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка выгрузки списка занятий по преподавателям в html");
					return;
				}
			});
		}

		private void ButtonUploadAuditoriumSelectFolder_Click(object sender, EventArgs e)
		{
			var fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				buttonUploadAuditoriumSelectFolder.Text = fbd.SelectedPath;
				_canUploadAuditoirums = true;
			}
		}

		private async void ButtonLaunchUploadAuditoriums_Click(object sender, EventArgs e)
		{
			if (!_canUploadAuditoirums)
			{
				Program.ShowError("Не выбран путь до папки", "Ошибка");
				return;
			}
			var foplderPath = buttonUploadAuditoriumSelectFolder.Text;

			await Task.Run(() => {
				try
				{
					Guid? periodId = null;
					var period = Program.ReadAppSettingConfig(Program.CurrentPeriod);

					if (period.IsNotEmpty())
					{
						periodId = new Guid(period);
					}
					if (!periodId.HasValue)
					{
						throw new Exception("Не определен период");
					}
					var exportService = DependencyManager.Instance.Resolve<IExportService>();
					var classTiemService = DependencyManager.Instance.Resolve<IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel>>();
					var auditoriumService = DependencyManager.Instance.Resolve<IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel>>();
					var schedulesService = DependencyManager.Instance.Resolve<IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel>>();
					exportService.SaveHtmlAuditoriums(new HtmlAuditoriumsBindingModel
					{
						SelectedPath = foplderPath,
						Classtimes = classTiemService.GetList(),
						Data = auditoriumService.GetList(),
						Lessons = schedulesService.GetList(new ScheduleSearchModel { PeriodId = periodId })
					});
					Program.ShowInfo("Выгрузка по аудиториям в html прошла успешно!", "Результат выгрузки");
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка выгрузки списка занятий по аудиториям в html");
					return;
				}
			});
		}
	}
}
