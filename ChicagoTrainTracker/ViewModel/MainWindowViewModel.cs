using System;

namespace ChicagoTrainTracker.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{
		public StationViewViewModel StationViewViewModel { get; }
		public MapViewModel MapViewModel { get; }

		public MainWindowViewModel(StationViewViewModel stationViewModel, MapViewModel mapViewModel)
		{
			StationViewViewModel = stationViewModel ?? throw new ArgumentNullException(nameof(stationViewModel));
			MapViewModel = mapViewModel ?? throw new ArgumentNullException(nameof(mapViewModel));
		}
	}
}
