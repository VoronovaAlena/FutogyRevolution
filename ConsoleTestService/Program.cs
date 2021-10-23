using System;
using System.IO;
using TrafficFramework.TaskService;

using TrafficFramework.InputData;
using System.Text.Json;
using TrafficFramework.DataResponse;

namespace ConsoleTestService
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start service");

			var controller = new TaskController(ClassHelper.TimeInterval, ClassHelper.InputIDs);
			controller.TaskElipse += Reader;
			controller.Start();

			Console.ReadKey();
		}

		private static void Reader(TaskServiceData data)
		{
			var context = data.Context;

			var docPlan   = JsonParse.Deserialize<FullInfo>(context.FullInfo);
			var docStatus = JsonParse.Deserialize<Status>(context.Status);
			
			data.Dispose();
		}
	}
}
