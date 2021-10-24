using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficFramework.Binary;
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

		/// <summary>Сохраняет локально текущую конфигурацию всех ДК.</summary>
		public void Caching()
		{
			CaсhingBinary.DeleteAll();
			foreach(var item in PlanPhases)
			{
				var preBinary = new BinaryData(item);
				var data = preBinary.Serilization();
				var fileName = CaсhingBinary.SaveInfo(data);
			}
		}

		/// <summary>Загрузить локальную конфигурацию ДК.</summary>
		/// <remarks>Не влияет на сами ДК.</remarks>
		public void Open()
		{
			var datas = CaсhingBinary.ReadInfo();
			if(datas != null)
			{
				PlanPhases.Clear();
				foreach(var item in datas)
				{
					var data = JsonParse.Deserialize<BinaryData>(item);
					PlanPhases.Add(new PlanPhase(data.Id, data.Full, data.Status)
					{
						Id_Plan = data.IdPlan,
						Phases = data.Phases.ToList()
					});
				}
			}
			else
			{
				Console.WriteLine("File not found.");
			}
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
					Console.Write($"Id:{mode.Id} [{(int)valid}] aprax:[{mode.ApraxDelta}] ");
				}
				Console.WriteLine("]");
			}
			TaskServiceDatas.Clear();
		}
	}
}
