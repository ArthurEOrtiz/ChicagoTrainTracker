using System;

namespace ChicagoTrainTracker.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{
		public StationViewViewModel StationViewViewModel { get; }
		public MapViewModel MapViewModel { get; }

		public MainWindowViewModel(StationViewViewModel stationViewModel, MapViewModel mapViewModel)
		{
			StationViewViewModel = stationViewModel;
			MapViewModel = mapViewModel;
		}
	}
}
