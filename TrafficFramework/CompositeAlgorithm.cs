using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficFramework.Data;
using TrafficFramework.DataResponse;
using TrafficFramework.TaskService;

namespace TrafficFramework
{
	/// <summary>Алгоритм объединяющих два сервиса.</summary>
	public class CompositeAlgorithm
	{
		private TaskController TaskController { get; }

		private PlanAnalitic PlanAnalitic { get; }

		private Dictionary<long, Tuple<string, string>> KeyValues = new Dictionary<long, Tuple<string, string>>();

		public CompositeAlgorithm(TaskController task, PlanAnalitic planAnalitic)
		{
			TaskController = task;
			PlanAnalitic = planAnalitic;
		}

		public void Test()
		{
			DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
			var timestamp = (long)(DateTime.Now.AddMinutes(1) - sTime).TotalSeconds;

			var json = new PostInfo()
			{
				Id = 1,
				Time = timestamp,
				Phases = new Phase[]
				{
					new Phase()
					{
						Id = 1,
						Direction = null,
						Hidden = false,
						TimeMain = 15,
						TimeMine = 10,
						TimeProm = 5,
					},
					new Phase()
					{
						Id = 2,
						Direction = null,
						Hidden = false,
						TimeMain = 15,
						TimeMine = 10,
						TimeProm = 5,
					},
					new Phase()
					{
						Id = 3,
						Direction = null,
						Hidden = false,
						TimeMain = 15,
						TimeMine = 10,
						TimeProm = 5,
					}
				},
				t_cycle = 60
			};
			var set = JsonParse.Serialize(json);
			var mem = new MemoryStream(Encoding.UTF8.GetBytes(set));

			NextPlan(81051, Http.Api.ApiPost.Custom_phase_program, set);
		}

		/// <summary>Ставит задачу на переключение ДК.</summary>
		public void NextPlan(long idController, string request, string stream)
		{
			TaskController.TaskElipse += Plan;
			KeyValues.Add(idController,Tuple.Create(request, stream));
		}

		private async void Plan(TaskServiceData data)
		{
			var docPlan = JsonParse.Deserialize<FullInfo>(data.Context.FullInfo);
			var docStatus = JsonParse.Deserialize<Status>(data.Context.Status);

			bool act = true;

			foreach(var item in KeyValues)
			{
				var plan = PlanAnalitic.PlanPhases.FirstOrDefault(x => x.Id == item.Key);
				if(plan != null)
				{
					var phase = plan.Phases.FirstOrDefault(x => x.Id == docStatus.current_phase_id);
					if(phase != null)
					{
						if(phase.Id == plan.Phases.Count)
						{
							act = false;
							await TaskController.Algorithm(item.Value.Item1, item.Value.Item2, item.Key.ToString());
						}
					}
				}
			}
			if(!act)
			{
				KeyValues.Clear();
				TaskController.TaskElipse -= Plan;
			}
		}
	}
}
