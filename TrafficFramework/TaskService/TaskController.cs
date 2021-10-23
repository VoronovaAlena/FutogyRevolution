using ApiTraffic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

using TrafficFramework.Http;

namespace TrafficFramework.TaskService
{
	/// <summary>Сервис управления.</summary>
	public class TaskController : IDisposable
	{
		public delegate void TaskHandler(TaskServiceData data);

		/// <summary>Таймер сработал.</summary>
		public event TaskHandler TaskElipse;

		private long _tick;

		private Timer _timer;

		private HttpClient Client;

		private long[] IDList;

		private List<TaskServiceData> Container { get; }

		public bool IsDisposed { get; private set; }  = false;

		private bool Buffers { get; }

		private void AddTick()
		{
			if(_tick < IDList.Length - 1)
			{
				_tick++;
			}
			else
			{
				_tick = 0;
			}
		}

		public IEnumerable<TaskServiceData> FetchData(DateTime start, DateTime end)
		{
			return Container.Where(x => x.DateTime >= start && x.DateTime <= end);
		}

		public TaskServiceData FetchLast()
		{
			return Container.Last();
		}

		/// <summary>Класс для мониторинга состояний.</summary>
		/// <param name="time">Интервал.</param>
		/// <param name="id_list">Лист id.</param>
		/// <param name="hasBuffer">Имеет ли запись данных.</param>
		public TaskController(double time, long[] id_list, bool hasBuffer = false)
		{
			_timer = new Timer(time);
			_timer.Elapsed += DecisionAsync;
			IDList = id_list;

			Client = new HttpClient();
			Container = new List<TaskServiceData>();
			Buffers = hasBuffer;
		}

		/// <summary>Запускает сервис.</summary>
		public void Start()
		{
			_timer.Start();
			Task.Factory.StartNew(()=> TestAsync());
		}

		/// <summary>Останавливает сервис.</summary>
		public void Stop()
		{
			_timer.Stop();
		}

		private async void DecisionAsync(object sender, ElapsedEventArgs e)
		{
			await GetInformation();
		}

		public async Task<TaskServiceData> GetInformation(long id = -1)
		{
			bool isForced = id >= 0;

			var time = DateTime.Now;

			var item = IDList[!isForced ? _tick : id];
			var responceInfo = await Client.GetByID(ApiGet.GetInfo, item.ToString());
			var responceStatus = await Client.GetByID(ApiGet.GetStatus, item.ToString());

			var stringFullInfo = await responceInfo.Content.ReadAsStringAsync();
			var stringStatus = await responceStatus.Content.ReadAsStringAsync();

			var context = new TaskServiceData(
					new ControllerItem(stringFullInfo, stringStatus),
					time);

			if(Buffers)
			{
				Container.Add(context);
			}

			if(!isForced && responceInfo.StatusCode == System.Net.HttpStatusCode.OK
				&& responceInfo.StatusCode == System.Net.HttpStatusCode.OK)
			{
				AddTick();
				TaskElipse?.Invoke(context);
			}
			else if(!isForced)
			{
				System.Threading.Thread.Sleep(5000);
				return await GetInformation(id);
			}

			return context;
		}

		public void TestAsync()
		{
			GetInformation().Wait();
		}

		public void Dispose()
		{
			if(!IsDisposed)
			{
				foreach(var item in Container)
				{
					item.Dispose();
				}
				Container.Clear();

				_timer.Elapsed -= DecisionAsync;
				_timer.Stop();
				_timer?.Dispose();
				Client?.Dispose();

				IsDisposed = true;
			}
		}
	}
}
