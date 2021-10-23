using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTraffic
{
	public static class ApiExtension
	{
		public static async Task<HttpResponseMessage> GetByID(this HttpClient client, string data, long id)
		{
			string res = string.Format(data,id.ToString());
			return await client.SendAsync(new HttpRequestMessage(HttpMethod.Get,res));
		}
	}
}
