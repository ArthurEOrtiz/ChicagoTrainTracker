using ChicagoTrainTracker.Model;
using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Media;
using System.Xml;
using BingLocation = Microsoft.Maps.MapControl.WPF.Location;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Location = ChicagoTrainTracker.Model.Location;

namespace ChicagoTrainTracker.ViewModel
{
	public class MapViewModel : ViewModelBase
	{
		private ObservableCollection<Pushpin> _pushpins;

		public ObservableCollection<Pushpin> Pushpins
		{
			get => _pushpins;
			set
			{
				_pushpins = value;
				OnPropertyChanged(nameof(Pushpins));
			}
		}

		public ApplicationIdCredentialsProvider BingMapsApiKey { get; }

		private readonly ObservableCollection<StopViewModel> _stops;
		public IEnumerable<StopViewModel> Stops => _stops;

		private readonly ObservableCollection<StationViewModel> _stations;
		public IEnumerable<StationViewModel> Stations => _stations;

		public MapViewModel()
		{
			BingMapsApiKey = new ApplicationIdCredentialsProvider(ConfigurationManager.AppSettings["BingMapsApiKey"]);

			Pushpins = new ObservableCollection<Pushpin>();
			_stops = new ObservableCollection<StopViewModel>();
			_stations = new ObservableCollection<StationViewModel>();
			LoadStopData();

		}

		private async void LoadStopData()
		{
			using (var httpClient = new HttpClient())
			{
				string apiUrl = "https://data.cityofchicago.org/resource/8pix-ypme.xml";
				var response = await httpClient.GetStringAsync(apiUrl);
				ParseApiResponse(response);
			}
		}

		private void ParseApiResponse(string response)
		{
			var xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(response);

			XmlNodeList stopNodes = xmlDoc.SelectNodes("//row");

			foreach (XmlNode stopNode in stopNodes)
			{
				Stop stop = new Stop
				{
					StopId = int.TryParse(stopNode.SelectSingleNode("stop_id")?.InnerText, out int parsedStopId) ? parsedStopId : 0,
					StationName = stopNode.SelectSingleNode("station_name")?.InnerText,
					MapId = int.TryParse(stopNode.SelectSingleNode("map_id")?.InnerText, out int parsedMapId) ? parsedMapId : 0,
					Location = ParseLocation(stopNode.SelectSingleNode("location")),
					Red = bool.TryParse(stopNode.SelectSingleNode("red")?.InnerText, out bool parsedRed) ? parsedRed : false,
					Blue = bool.TryParse(stopNode.SelectSingleNode("blue")?.InnerText, out bool parsedBlue) ? parsedBlue : false,
					Green = bool.TryParse(stopNode.SelectSingleNode("g")?.InnerText, out bool parsedGreen) ? parsedGreen : false,
					Brown = bool.TryParse(stopNode.SelectSingleNode("brn")?.InnerText, out bool parsedBrown) ? parsedBrown : false,
					Purple = bool.TryParse(stopNode.SelectSingleNode("p")?.InnerText, out bool parsedPurple) ? parsedPurple : false,
					PurpleExpress = bool.TryParse(stopNode.SelectSingleNode("pexp")?.InnerText, out bool parsedPurpleExpress) ? parsedPurpleExpress : false,
					Yellow = bool.TryParse(stopNode.SelectSingleNode("y")?.InnerText, out bool parsedYellow) ? parsedYellow : false,
					Pink = bool.TryParse(stopNode.SelectSingleNode("pnk")?.InnerText, out bool parsedPink) ? parsedPink : false,
					Orange = bool.TryParse(stopNode.SelectSingleNode("o")?.InnerText, out bool parsedOrange) ? parsedOrange : false
				};

				if (stop.StopId != 0)
				{
					_stops.Add(new StopViewModel(stop));
				};
			}

			var groupedStations = _stops.GroupBy(s => s.MapId);

			foreach (var station in groupedStations)
			{
				Station newStation = new Station
				{

					MapId = station.Key,
					StationName = station.First().StationName,
					Location = station.First().Location,
					Stops = station.ToList(),
					Colors = GetStationColors(station.ToList())
				};

				_stations.Add(new StationViewModel(newStation));
			}

			foreach (var station in _stations)
			{
				double lat = station.Location.Latitude;
				double lng = station.Location.Longitude;

				List<Color> colors = station.StationColors.ToList();

				var location = new BingLocation(lat, lng);

				AddPushPin(location, station.StationName, colors);
			}
		}

		private List<Color> GetStationColors(List<StopViewModel> stations)
		{
			List<Color> colors = new List<Color>();

			foreach (var station in stations)
			{
				colors.AddRange(station.StopColors);
			}

			return colors;
		}

		private Location ParseLocation(XmlNode xmlNode)
		{
			Location location = new Location
			{
				Latitude = double.TryParse(xmlNode?.Attributes["latitude"]?.Value, out double parsedLatitude) ? parsedLatitude : 0.0,
				Longitude = double.TryParse(xmlNode?.Attributes["longitude"]?.Value, out double parsedLongitude) ? parsedLongitude : 0.0
			};

			return location;
		}

		private void AddPushPin(BingLocation location, string stationName, List<Color> colors)
		{
			Pushpin pushpin = new Pushpin();
			pushpin.Location = location;
			pushpin.ToolTip = stationName;
			
			
			if(colors.Count > 0 && colors.All(c => c == colors[0]))
			{
				pushpin.Background = new SolidColorBrush(colors[0]);	
			}
			else
			{
				pushpin.Background = new SolidColorBrush(Colors.White);
			}

			Pushpins.Add(pushpin);
		}
	}
}
