using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.DataResponse
{
	public class PostInfo
	{
		[JsonProperty("time_start_sync")]
		public long Time { get; set; }

		[JsonProperty("start_phase_id")]
		public long Id { get; set; }

        [JsonProperty("t_cycle")]
        public long t_cycle { get; set; }

        [JsonProperty("phases")]
		public Phase[] Phases { get; set; }
    }
}
