using ChicagoTrainTracker.Commands;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

		private async void ChangeStationName(object parameter)
		{
			if (parameter is StationViewModel newStation)
			{
				Station = newStation;
				await LoadStationEtasAsync(Station.MapId);
			}
		}

		private async Task LoadStationEtasAsync(int mapId)
		{
			string ctaApiKey = System.Configuration.ConfigurationManager.AppSettings["CtaApiKey"];

			using (var httpClient = new HttpClient())
			{
				string apiUrl = $"http://lapi.transitchicago.com/api/1.0/ttarrivals.aspx?key{ctaApiKey}&mapid={Station.MapId}";
				var response = await httpClient.GetAsync(apiUrl);

			}
		}
	}
}
