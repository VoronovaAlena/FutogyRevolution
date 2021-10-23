using System;
using System.Threading.Tasks;

namespace TrafficFramework.GUI
{
	public interface IAppBootstrapper : IDisposable
	{
		/// <summary>Асинхронно запускает приложение.</summary>
		/// <remarks>Задача, представляющая асинхронную операцию запуска приложения.</remarks>
		Task RunAsync();
	}
}
