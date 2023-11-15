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

		public StationViewViewModel() { }

	}
}
