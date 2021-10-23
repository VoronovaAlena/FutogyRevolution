using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficFramework.DataResponse;

namespace TrafficFramework.Data
{
	public class PlanPhase
	{
		/// <summary>Индентификатор по id Дк.</summary>
		public long Id { get; set; }

		public FullInfo DocPlan { get; set; }

		public Status DocStatus { get; set; }

		private long LastId { get; set; }


		public PlanPhase(long id, FullInfo plan, Status status)
		{
			Id = id;

			DocPlan = plan;
			DocStatus = status;

			Phases = new List<PhasePart>();
		}

		public void Add(Status status)
		{
			var cont = Phases.FirstOrDefault(x => x.Id == status.current_phase_id);

			if(cont == null)
			{
				Phases.Add(new PhasePart() { Id = status.current_phase_id, TimeStart = DateTime.Now, TimeEnd = DateTime.Now});
			}
			else
			{
				if(LastId != status.current_phase_id)
				{
					cont.TimeStart = DateTime.Now;
				}
				cont.TimeEnd = DateTime.Now;
				cont.UpdateInterval();
			}
			LastId = status.current_phase_id;
		}

		public List<PhasePart> Phases { get; set; }
	}
}
