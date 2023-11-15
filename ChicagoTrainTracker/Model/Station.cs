using ChicagoTrainTracker.ViewModel;
using System.Collections.Generic;
using System.Windows.Media;

namespace ChicagoTrainTracker.Model
{
	public class Station
	{
		public string StationName { get; set; }
		public int MapId { get; set; }
		public List<StopViewModel> Stops { get; set; }
		public Location Location { get; set; }
		public List<Color> Colors { get; set; }
	}
}
