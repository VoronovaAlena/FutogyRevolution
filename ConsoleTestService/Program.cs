using System;

using TrafficFramework.TaskService;
using TrafficFramework.InputData;
using TrafficFramework.DataResponse;
using TrafficFramework.Data;
using System.Threading.Tasks;
using TrafficFramework.Http.Api;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleTestService
{
	class Program
	{
		static PlanAnalitic PlanAnalitic { get; } = new PlanAnalitic();

		static TaskController TaskController { get; set; }

		static void Main(string[] args)
		{
			Console.WriteLine("Start service");

			var controller = new TaskController(ClassHelper.TimeInterval, ClassHelper.InputIDs);
			controller.TaskElipse += Reader;
			controller.TaskComplited += Update;
			controller.Start();
			TaskController = controller;

			var readConsole = string.Empty;
			do
			{
				if(controller.Started)
				{
					Console.ReadKey();
					TaskController.Stop();
					Console.WriteLine("App paused... Write: start or exit.");
				}
				readConsole = Console.ReadLine();
				ConsoleReadLineCommand(readConsole);
			} 
			while(readConsole != "exit");
		}

		private static void ConsoleReadLineCommand(string command)
		{
			switch(command)
			{
				case "start":
					Console.WriteLine("continue...");
					TaskController.Start();
					break;
				case "exit":
					Console.WriteLine("exiting...");
					TaskController.Stop();
					break;
				case "clear":
					Console.Clear();
					break;
				case "cache":
					PlanAnalitic.Caching();
					break;
				case "open":
					PlanAnalitic.Open();
					break;
				default:
					Console.WriteLine("not correct");
					break;
			}
		}

		private static void Reader(TaskServiceData data)
		{
			var context = data.Context;

			if(context == null) return;

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
