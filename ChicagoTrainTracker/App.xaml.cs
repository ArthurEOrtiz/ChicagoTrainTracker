using ChicagoTrainTracker.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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
			var services = new ServiceCollection();

			services.AddSingleton<StationViewViewModel>();
			services.AddSingleton<MapViewModel>();
			services.AddSingleton<MainWindowViewModel>(provider => new MainWindowViewModel(provider.GetRequiredService<StationViewViewModel>(), provider.GetRequiredService<MapViewModel>()));

			var serviceProvider = services.BuildServiceProvider();

			var mainWindowViewModel = serviceProvider.GetRequiredService<MainWindowViewModel>();

			MainWindow = new MainWindow()
			{
				DataContext = mainWindowViewModel
			};

			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
