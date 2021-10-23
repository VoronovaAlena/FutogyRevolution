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
			var form = new MainWindowViewModel();

			TaskController task = new TaskController(ClassHelper.TimeInterval, ClassHelper.InputIDs);
			task.TaskElipse += form.Update;

			this.DataContext = form;

			Task = task;
		}

		private void Button_Click()
		{
			Task.Start();
		}

		private void Reader(TaskServiceData task)
		{
			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Task.Start();
		}
	}
}
