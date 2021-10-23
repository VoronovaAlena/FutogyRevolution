using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.TaskService
{
	public class ControllerItem
	{
		public ControllerItem(string info, string status)
		{
			FullInfo = info;
			Status = status;
		}

		public string FullInfo { get; }

		public string Status { get; }
	}
}
