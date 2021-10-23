using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.DataResponse
{
	public static class JsonParse 
	{
		public static T Deserialize<T>(string data) where T : class
		{
			return JsonConvert.DeserializeObject<T>(data);
		}
	}
}
