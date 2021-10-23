using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficFramework.DataResponse;

namespace TrafficFramework.Data
{

	public class BinaryData
	{
		[JsonProperty("full")]
		public FullInfo Full { get; set; }

		[JsonProperty("status")]
		public Status Status { get; set; }

		[JsonProperty("phases")]
		public PhasePart[] Phases {get;set;}

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("idPlan")]
		public long IdPlan { get; set; }

		public BinaryData(PlanPhase planPhase)
		{
			Full = planPhase?.DocPlan;
			Status = planPhase?.DocStatus;
			Phases = planPhase?.Phases.ToArray();

			Id = planPhase?.Id ?? -1;
			IdPlan = planPhase?.Id_Plan ?? -1;
		}

		public string Serilization()
		{
			return JsonParse.Serialize(this);
		}
	}
}
