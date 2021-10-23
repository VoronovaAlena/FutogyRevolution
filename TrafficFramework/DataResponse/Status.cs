using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.DataResponse
{
	public class Status
	{
		[JsonProperty("time")]
		public long Time { get; set; }

		[JsonProperty("uuid")]
		public string GUID { get; set; }

		[JsonProperty("status")]
		public string status { get; set; }

		[JsonProperty("status_rc")]
		public string status_rc { get; set; }

		[JsonProperty("status_rc_desc")]
		public string status_rc_desc { get; set; }

		[JsonProperty("current_status")]
		public string current_status { get; set; }

		[JsonProperty("current_phase_id")]
		public long current_phase_id { get; set; }

		[JsonProperty("rc_response")]
		public StatusResponse rc_response { get; set; }
	}
}
