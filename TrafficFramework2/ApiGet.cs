using System;

namespace ApiTraffic
{
	public class ApiGet
	{
		/// <summary>Получает данные о ДК.</summary>
		public const string GetInfo = "https://api.via-dolorosa.ru/rc/{0}/full_info";

		/// <summary>Получает данные о текущем состоянии ДК.</summary>
		public const string GetStatus = "https://api.via-dolorosa.ru/rc/{id}/status";
	}
}
