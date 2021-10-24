using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficFramework.DataResponse;
using TrafficFramework.InputData;

namespace TrafficFramework.Data
{
	public class PlanPhase
	{
		/// <summary>Индентификатор по id Дк.</summary>
		public long Id { get; set; }

		/// <summary>Уникальное значение плана.</summary>
		/// <remarks>Присваиваеться после подтверждённой апроксимации всех фаз.</remarks>
		public long Id_Plan { get; set; } = -1;

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
				Phases.Add(new PhasePart() { Id = status.current_phase_id, TimeStart = DateTime.Now, TimeEnd = DateTime.Now });
			}
			else
			{
				if(LastId != status.current_phase_id)
				{
					cont.TimeStart = DateTime.Now;
				}
				cont.TimeEnd = DateTime.Now;
				if(DocPlan.Phases == null || DocPlan.Phases.Length == 0)
				{
					cont.UpdateInterval();
				}
				else
				{
					var cst = DocPlan.Phases.FirstOrDefault(x => x.Id == status.current_phase_id);
					cont.UpdateInterval(cst.TimeMain + cst.TimeProm);
				}
			}
			LastId = status.current_phase_id;

			var resApr = Phases.All(x => x.HasMaxAprax);
			if(resApr && Id_Plan == -1)
			{
				//TODO FIX: Создать класс токенов.
				Id_Plan = ClassHelper.GetId++;
			}
		}

		public List<PhasePart> Phases { get; set; }
	}
}
