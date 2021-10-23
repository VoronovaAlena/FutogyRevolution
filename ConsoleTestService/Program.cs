using System;

using TrafficFramework.TaskService;
using TrafficFramework.InputData;
using TrafficFramework.DataResponse;
using TrafficFramework.Data;
using System.Threading.Tasks;

namespace ConsoleTestService
{
	class Program
	{
		static PlanAnalitic PlanAnalitic { get; } = new PlanAnalitic();

		static void Main(string[] args)
		{
			Console.WriteLine("Start service");

			var controller = new TaskController(ClassHelper.TimeInterval, ClassHelper.InputIDs);
			controller.TaskElipse += Reader;
			controller.TaskComplited += Update;
			controller.Start();

			Console.ReadKey();
		}

		private static void Reader(TaskServiceData data)
		{
			var context = data.Context;

			PlanAnalitic.Add(data);

			var docPlan   = JsonParse.Deserialize<FullInfo>(context.FullInfo);
			var docStatus = JsonParse.Deserialize<Status>(context.Status);

			Console.WriteLine("Id-Phase:" + docStatus.current_phase_id + " id-Dk:" + docStatus.rc_response.status_msg.rc_id + " cycle:" + docPlan.t_cycle + " time:" + DateTime.Now);
		}

		/// <summary>Вызывается при выполнении всех ДК.</summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private static void Update(object sender, EventArgs args)
		{
			PlanAnalitic.Update();
		}
	}
}
