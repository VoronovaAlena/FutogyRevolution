using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.DataResponse
{
	public class StatusMessage
	{	
		[JsonProperty("uuid")]
		public string GUID { get; set; }

		[JsonProperty("rc_id")]
		public long rc_id { get; set; }

		[JsonProperty("prevStatus")]
		public long prevStatus { get; set; }

		[JsonProperty("nextStatus")]
		public long nextStatus { get; set; }

		[JsonProperty("source")]
		public long source { get; set; }

		[JsonProperty("mode")]
		public long mode { get; set; }

		[JsonProperty("prevPhaseID")]
		public long prevPhaseID { get; set; }

		[JsonProperty("nextPhaseID")]
		public long nextPhaseID { get; set; }
	}
}
