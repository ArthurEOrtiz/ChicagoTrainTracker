using ChicagoTrainTracker.Commands;
using System;

namespace ChicagoTrainTracker.ViewModel
{
	public class StationViewViewModel : ViewModelBase
	{
		private string _stationName = "Hello World!";

		public string StationName
		{
			get => _stationName;
			set
			{
				_stationName = value;
				OnPropertyChanged(nameof(StationName));
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
				StationName = newStation.StationName;
			}
		}
	}
}
