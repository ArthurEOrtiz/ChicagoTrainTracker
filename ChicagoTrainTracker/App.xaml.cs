using ChicagoTrainTracker.ViewModel;
using System.Windows;

namespace ChicagoTrainTracker
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			var stationViewViewModel = new StationViewViewModel();
			var mapViewModel = new MapViewModel();

			var mainWindowViewModel = new MainWindowViewModel(stationViewViewModel, mapViewModel);

			MainWindow = new MainWindow()
			{
				DataContext = mainWindowViewModel
			};

			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
