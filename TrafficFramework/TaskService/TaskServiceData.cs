using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.TaskService
{
	public class TaskServiceData : IDisposable
	{
		public TaskServiceData(ControllerItem stream, DateTime time)
		{
			Context = stream;
			DateTime = time;
		}

		public ControllerItem Context { get; }

		public DateTime DateTime { get; }

		public void Dispose()
		{
			
		}
	}
}
