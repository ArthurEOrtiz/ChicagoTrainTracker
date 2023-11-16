using ChicagoTrainTracker.Commands;
using ChicagoTrainTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

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

		private readonly ObservableCollection<EtaViewModel> _eTAData;
		public IEnumerable<EtaViewModel> ETAData => _eTAData;

		public RelayCommand ChangeStationNameCommand { get; private set; }

		public StationViewViewModel()
		{
			ChangeStationNameCommand = new RelayCommand(ChangeStationName);
			_eTAData = new ObservableCollection<EtaViewModel>();
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
				string apiUrl = $"http://lapi.transitchicago.com/api/1.0/ttarrivals.aspx?key={ctaApiKey}&mapid={Station.MapId}";
				var response = await httpClient.GetStringAsync(apiUrl);

				ParserApiResponse(response);

			}
		}

		private void ParserApiResponse(string xmlResponse)
		{
			var xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xmlResponse);

			bool isResponseGood = CheckErrorCode(xmlDoc);

			if (isResponseGood)
			{
				SetEtaData(xmlDoc);
			}
		}

		private void SetEtaData(XmlDocument xmlDoc)
		{
			_eTAData.Clear();
			var etaNodes = xmlDoc.SelectNodes("//eta");

			foreach (XmlNode etaNode in etaNodes)
			{
				var etaData = new Eta
				{
					Route = etaNode.SelectSingleNode("rt")?.InnerText,
					RouteNumber = int.TryParse(etaNode.SelectSingleNode("rn")?.InnerText, out int parsedRouteNumber) ? parsedRouteNumber : 0,
					StopDescription = etaNode.SelectSingleNode("stpDe")?.InnerText,
					DestinationName = etaNode.SelectSingleNode("destNm")?.InnerText,
					ArrivalTime = DateTime.TryParseExact(etaNode.SelectSingleNode("arrT")?.InnerText, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var arrivalTime) ? arrivalTime
								: default(DateTime),
					IsApproaching = int.TryParse(etaNode.SelectSingleNode("isApp")?.InnerText, out int parsedIsApproaching) ? parsedIsApproaching : 0,
					IsDelayed = int.TryParse(etaNode.SelectSingleNode("isDly")?.InnerText, out int parsedIsDelayed) ? parsedIsDelayed : 0
				};

				_eTAData.Add(new EtaViewModel(etaData));
			}
		}

		private bool CheckErrorCode(XmlDocument xmlDoc)
		{
			int errorCode = int.TryParse(xmlDoc.SelectSingleNode("//errCd")?.InnerText, out int parseErrorCode) ? parseErrorCode : 0;
			string errorMessage = xmlDoc.SelectSingleNode("//errNm")?.InnerText;

			if (errorCode != 0)
			{
				//throw new ApiErrorException($"API Error (Code: {errorCode}): {errorMessage}");
			}

			return errorCode == 0;
		}
	}
}
