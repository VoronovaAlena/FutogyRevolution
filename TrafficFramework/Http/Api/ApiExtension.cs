using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTraffic
{
	public static class ApiExtension
	{
		/// <summary>Гет запрос.</summary>
		/// <param name="client">Управляемый клиент.</param>
		/// <param name="request">Запрос.</param>
		/// <param name="args">Аргументы запроса.</param>
		/// <returns>Ответ запроса.</returns>
		public static async Task<HttpResponseMessage> GetByID(this HttpClient client, string request, params string[] args)
		{
			string res = string.Format(request, args);
			return await client.SendAsync(new HttpRequestMessage(HttpMethod.Get,res));
		}

		/// <summary>Пост запрос.</summary>
		/// <param name="client">Управляемый клиент.</param>
		/// <param name="request">Запрос.</param>
		/// <param name="stream">Контекст запроса.</param>
		/// <param name="args">Аргументы запроса.</param>
		/// <returns>Ответ запроса.</returns>
		public static async Task<HttpResponseMessage> Post(this HttpClient client, string request, string stream, params string[] args)
		{
			string res = string.Format(request, args);
			/*var requestMsg = new HttpRequestMessage(HttpMethod.Post, res);
			if(stream != null)
			{
				requestMsg.Content = new StringContent(stream);
			}*/
			//return await client.SendAsync(requestMsg);

			return await client.PostAsync(res,new StringContent(stream));
		}
	}
}
