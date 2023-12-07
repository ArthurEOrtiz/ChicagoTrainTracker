using ChicagoTrainTracker.View;

namespace ChicagoTrainTracker.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{
		public StationViewViewModel StationViewViewModel { get; }
		public MapViewModel MapViewModel { get; }

		public MainWindowViewModel(StationViewViewModel stationViewViewModel, MapViewModel mapViewModel)
		{
			StationViewViewModel = stationViewViewModel;
			MapViewModel = mapViewModel;
		}
	}
}
