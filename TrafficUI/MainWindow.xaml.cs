using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrafficFramework.Binary;
using TrafficFramework.DataResponse;
using TrafficFramework.InputData;
using TrafficFramework.TaskService;

namespace TrafficUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		TaskController Task;

		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new MainWindowViewModel();

			TaskController task = new TaskController(ClassHelper.TimeInterval, ClassHelper.InputIDs);
			task.TaskElipse += Reader;
			task.TaskComplited += Update;

			Task = task;
		}

		private void Button_Click()
		{
			Task.Start();
		}

		private void Reader(TaskServiceData task)
		{
			var json = JsonParse.Deserialize<FullInfo>(task.Context.FullInfo);
			var status = JsonParse.Deserialize<Status>(task.Context.Status);

			switch(json.Id)
			{
				case 81051:
					Controller1.Content = $"Id:{json.Id}";
					p1.Content = $"Id:{status.current_phase_id}";
					break;
				case 81052:
					Controller2.Content = $"Id:{json.Id}";
					p2.Content = $"Id:{status.current_phase_id}";
					break;
				case 81053:
					Controller3.Content = $"Id:{json.Id}";
					p3.Content = $"Id:{status.current_phase_id}";
					break;
				case 81054:
					Controller4.Content = $"Id:{json.Id}";
					p4.Content = $"Id:{status.current_phase_id}";
					break;
				case 81055:
					Controller5.Content = $"Id:{json.Id}";
					p5.Content = $"Id:{status.current_phase_id}";
					break;
				case 81056:
					Controller6.Content = $"Id:{json.Id}";
					p6.Content = $"Id:{status.current_phase_id}";
					break;
				case 81057:
					Controller7.Content = $"Id:{json.Id}";
					p7.Content = $"Id:{status.current_phase_id}";
					break;
				case 81058:
					Controller8.Content = $"Id:{json.Id}";
					p8.Content = $"Id:{status.current_phase_id}";
					break;
				case 81059:
					Controller9.Content = $"Id:{json.Id}";
					p9.Content = $"Id:{status.current_phase_id}";
					break;
				case 81060:
					Controller10.Content = $"Id:{json.Id}";
					p10.Content = $"Id:{status.current_phase_id}";
					break;
			}
		}

		private void Update(object sender, EventArgs args)
		{ 
			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Task.Start();
		}
	}
}
