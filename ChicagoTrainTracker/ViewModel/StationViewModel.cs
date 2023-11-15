using ChicagoTrainTracker.Model;
using System.Collections.Generic;
using System.Windows.Media;

namespace ChicagoTrainTracker.ViewModel
{
	public class StationViewModel
	{
		private readonly Station _station;

		public string StationName => _station.StationName;
		public int MapId => _station.MapId;
		public List<StopViewModel> Stops => _station.Stops;
		public Location Location => _station.Location;
		public List<Color> StationColors => _station.Colors;

		public StationViewModel(Station station)
		{
			_station = station;
		}
	}
}
