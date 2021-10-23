using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.Http.Api
{
	public class ApiPost
	{
		/// <summary>{0} - id</summary>
		/// <remarks>Настройка пользовательской фазовой программы для выбранного дорожного контроллера по его идентификатору.</remarks>
		public const string Custom_phase_program = "https://api.via-dolorosa.ru/rc/{0}/custom_phase_program";

		/// <summary>{0} - id, {1} - id_program.</summary>
		/// <remarks>Установите программу fix на дорожный контроллер по id из команды (custom_phase_program). Вы можете использовать флаги: deadline(время в сек, когда нужно запустить новую программу) force(запустить новую программу прямо сейчас)</remarks>
		public const string Set_fix_program = "https://api.via-dolorosa.ru/rc/{0}/set_fix_program/{1}";

		/// <summary>{0} - id</summary>
		/// <remarks>Отправьте активную программу на дорожный контроллер. Активная программа - программа, которую вы отправляете раньше.С помощью этой команды вы не можете изменить существующую программу, но изменить время сдвига Вы можете использовать флаги: deadline (время в сек, когда придется запускать программу) force(запустить новую программу прямо сейчас)</remarks>
		public const string Send_program = "https://api.via-dolorosa.ru/rc/{0}/send_program";

		/// <summary>{0} - id</summary>
		/// <remarks>Настройка локальной программы для дорожного контроллера.</remarks>
		public const string Set_local = "https://api.via-dolorosa.ru/rc/{0}/set_local";

		/// <summary>{0} - id, {1} - phase id, {2} - time to continue</summary>
		/// <remarks>Продолжить текущую фазу. Если время до окончания этой фазы больше time_to_continue ничего не произойдет В противном случае время будет добавлено не к фазовой времени, а к текущей контрольной точке Также текущее состояние дорожного контроллера должно быть не локальным.В противном случае вы увидите ошибку 500 в качестве ответа</remarks>
		public const string Continue_current_phase = "https://api.via-dolorosa.ru/rc/{0}/continue_current_phase?phase_id={1}&timeout={2}";

		/// <summary>{0} - id</summary>
		/// <remarks>Вперед следующий этап, если вам нужно пройти текущий. Также текущий статус дорожного контроллера должен быть не локальным.В противном случае вы увидите ошибку 500 в качестве ответа</remarks>
		public const string Forward_next_phase = "https://api.via-dolorosa.ru/rc/{0}/forward_next_phase";

		/// <summary>{0} - id, {1} - phase id</summary>
		/// <remarks>Держите необходимую фазу. На основе этой команды также можно построить алгоритм управления.</remarks>
		public const string Keep_phase = "https://api.via-dolorosa.ru/rc/{0}/keep_phase/{1}";

		/// <summary>{0} - id. </summary>
		/// <remarks>Отмена этапа сохранения и продолжение выполнения по последнему плану</remarks>
		public const string cancel_keep_phase = "https://api.via-dolorosa.ru/rc/{0}/cancel_keep_phase";
	}
}
