using Newtonsoft.Json;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ScheduleDatabaseImplementations.Implementations
{
	public class SyncWith1C : ISyncWith1C
	{
		private string _message;

		SyncWith1CViewModel ISyncWith1C.SyncWith1C(SyncWith1CBindingModel model)
		{
			var sb = new StringBuilder();
			var result = new SyncWith1CViewModel
			{
				IsSuccess = true
			};

			if (string.IsNullOrEmpty(model.BaseAddress))
			{
				sb.AppendLine("Не указан адрес сервера");
			}
			if (string.IsNullOrEmpty(model.Username))
			{
				sb.AppendLine("Не указано имя пользователя");
			}
			if (string.IsNullOrEmpty(model.Password))
			{
				sb.AppendLine("Не указан пароль");
			}
			if (sb.Length > 0)
			{
				result.IsSuccess = false;
				result.ErrorMessage = sb.ToString();
				return result;
			}

			var client = new HttpClient
			{
				BaseAddress = new Uri(model.BaseAddress)
			};
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{model.Username}:{model.Password}")));

			_message = string.Empty;

			var url = $"{model.BaseAddress}/univer_Testing/hs/Ulstu_StudentsInfo/v1/";

			if (model.UniverStructure.Sync)
			{
				if (!SyncUniverStructure(client, url, model.UniverStructure.Full))
				{
					sb.AppendLine($"Кафедры: {_message}");
					_message = string.Empty;
				}
			}
			if (model.AuditoriumStructure.Sync)
			{

			}
			if (model.Groups.Sync)
			{

			}
			if (model.StudyPlan.Sync)
			{

			}
			if (model.Chart.Sync)
			{

			}

			if (sb.Length > 0)
			{
				result.IsSuccess = false;
				result.ErrorMessage = sb.ToString();
			}

			return result;
		}

		private bool SyncUniverStructure(HttpClient client, string url, bool full)
		{
			try
			{
				HttpResponseMessage response = client.GetAsync($"{url}GetCurrentStudentsOfDepartment").Result;
				if (!response.IsSuccessStatusCode)
				{
					_message = "Не удалось получить список кафедр с сервера";					
					return false;
				}
				//var studentFromServer = JsonSerializer.Deserialize<StudentListSyncModel>(response.Content.ReadAsStringAsync().Result);

				return true;
			}
			catch(Exception ex)
			{
				_message = ex.Message;
				return false;
			}
		}
	}
}