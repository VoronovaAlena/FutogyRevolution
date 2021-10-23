using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.DataResponse
{
	public class StatusResponse
	{

		//"rc_response":{"result":{"status":1,"description":"OK_STATUS"},

		[JsonProperty("uuid")]
		public string GUID { get; set; }

		[JsonProperty("result")]
		public ResultStatus result { get; set; }

		[JsonProperty("status_msg")]
		public StatusMessage status_msg { get; set; }

		[JsonProperty("protocol")]
		public long protocol { get; set; }

		[JsonProperty("type")]
		public long type { get; set; }
	}

	public class ResultStatus
	{
		[JsonProperty("status")]
		public long status { get; set; }

		[JsonProperty("description")]
		public string description { get; set; }
	}
}
