using ChicagoTrainTracker.Commands;
using System;

namespace ChicagoTrainTracker.ViewModel
{
	public class StationViewViewModel : ViewModelBase
	{
		private StationViewModel _station;
		public StationViewModel Station
		{
			get => _station;
			set
			{
				_station = value;
				OnPropertyChanged(nameof(Station));
			}
		}

		public RelayCommand ChangeStationNameCommand { get; private set; }

		public StationViewViewModel()
		{
			ChangeStationNameCommand = new RelayCommand(ChangeStationName);
		}

		private void ChangeStationName(object parameter)
		{
			if (parameter is StationViewModel newStation)
			{
				Station = newStation;
			}
		}
	}
}
