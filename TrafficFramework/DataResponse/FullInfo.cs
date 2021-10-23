using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrafficFramework.DataResponse
{
	public class FullInfo
    {
		[JsonProperty("time")]
		public long Time { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("phases")]
		public Phase[] Phases { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("is_enabled")]
		public bool is_enabled { get; set; }

		[JsonProperty("is_alarmed")]
		public bool is_alarmed { get; set; }

		[JsonProperty("type")]
		public string type { get; set; }

		[JsonProperty("program_id")]
		public long program_id { get; set; }

		[JsonProperty("keep_phase_id")]
		public long keep_phase_id { get; set; }

		[JsonProperty("rc_created_at")]
		public DateTime rc_created_at { get; set; }

		[JsonProperty("rc_updated_at")]
		public DateTime rc_updated_at { get; set; }

		[JsonProperty("num_tl")]
		public long num_tl { get; set; }

		[JsonProperty("mode")]
		public string mode { get; set; }

		[JsonProperty("changed_time_at")]
		public DateTime changed_time_at { get; set; }

		[JsonProperty("real_mode")]
		public string real_mode { get; set; }

		[JsonProperty("real_program_id")]
		public long real_program_id { get; set; }

		[JsonProperty("real_keep_phase_id")]
		public long real_keep_phase_id { get; set; }

		[JsonProperty("program_created_at")]
		public DateTime program_created_at { get; set; }

		[JsonProperty("program_updated_at")]
		public DateTime program_updated_at { get; set; }

		[JsonProperty("t_cycle")]
		public long t_cycle { get; set; }

		[JsonProperty("program_type")]
		public string program_type { get; set; }
	}
}
