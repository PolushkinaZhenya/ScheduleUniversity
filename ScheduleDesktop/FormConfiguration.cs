using System;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormConfiguration : Form
	{
		public FormConfiguration()
		{
			InitializeComponent();
			var subd = Program.ReadAppSettingConfig(Program.DbType);
			if (!string.IsNullOrEmpty(subd))
			{
				comboBoxSUBD.SelectedIndex = comboBoxSUBD.Items.IndexOf(subd);
			}
			textBoxConnectionString.Text = Program.GetConnectionString();
		}

		private bool ValidateData()
		{
			if (string.IsNullOrEmpty(textBoxConnectionString.Text))
			{
				Program.ShowError("Строка подключения не заполнена", "Ошибка заполнения");
				return false;
			}
			if (comboBoxSUBD.SelectedIndex == -1)
			{
				Program.ShowError("Тип СУБД", "Ошибка заполнения");
				return false;
			}
			return true;
		}

		private void ButtonCheck_Click(object sender, EventArgs e)
		{
			if(!ValidateData())
			{
				return;
			}
			if (Program.CheckConnectToBD(textBoxConnectionString.Text, comboBoxSUBD.SelectedText))
			{
				Program.ShowInfo("Подключение успешно", "Проверка подключения");
			}
			else
			{
				Program.ShowInfo("Подключение не установлено", "Проверка подключения");
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (!ValidateData())
			{
				return;
			}

			Program.AddUpdateAppSettings(Program.DbType, comboBoxSUBD.Text);
			Program.SetConnectionString(textBoxConnectionString.Text);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}