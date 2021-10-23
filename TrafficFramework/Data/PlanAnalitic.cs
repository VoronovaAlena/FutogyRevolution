using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficFramework.DataResponse;
using TrafficFramework.TaskService;

namespace TrafficFramework.Data
{
	public class PlanAnalitic
	{
		public List<TaskServiceData> TaskServiceDatas { get; }

		public List<PlanPhase> PlanPhases { get; }

		public PlanAnalitic()
		{
			TaskServiceDatas = new List<TaskServiceData>();
			PlanPhases = new List<PlanPhase>();
		}

		public void Add(TaskServiceData task)
		{
			TaskServiceDatas.Add(task);
		}

		/// <summary>Обновляет и компанует данные.</summary>
		public void Update()
		{
			foreach(var item in TaskServiceDatas)
			{
				var docPlan = JsonParse.Deserialize<FullInfo>(item.Context.FullInfo);
				var docStatus = JsonParse.Deserialize<Status>(item.Context.Status);

				var plan = PlanPhases.FirstOrDefault(x => x.Id == docPlan.Id);
				if(plan == null)
				{
					plan = new PlanPhase(docPlan.Id, docPlan, docStatus);
					PlanPhases.Add(plan);
				}
				plan.Add(docStatus);

				Console.Write($"Id-Dk:{plan.Id} - Phases[");
				foreach(var mode in plan.Phases)
				{
					var valid = mode.TimeInterval.TotalSeconds;
					valid = valid < 0 ? 0 : valid;
					Console.Write($"Id:{mode.Id}, [{valid}] ");
				}
				Console.WriteLine("]");
			}
			TaskServiceDatas.Clear();
		}
	}
}
