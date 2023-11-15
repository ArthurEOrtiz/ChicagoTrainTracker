using ChicagoTrainTracker.Model;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;

namespace ChicagoTrainTracker.ViewModel
{
	public class StopViewModel : ViewModelBase
	{
		private readonly Stop _stop;

		public int StopId => _stop.StopId;
		public string StationName => _stop.StationName;
		public int MapId => _stop.MapId;
		public Location Location => _stop.Location;
		public List<Color> StopColors => GetStopColors();

		public StopViewModel(Stop stop)
		{
			_stop = stop;
		}

		private List<Color> GetStopColors()
		{
			List<Color> colors = new List<Color>();

			if (_stop.Red) colors.Add(Colors.Red);
			if (_stop.Blue) colors.Add(Colors.Blue);
			if (_stop.Green) colors.Add(Colors.Green);
			if (_stop.Brown) colors.Add(Colors.Brown);
			if (_stop.Purple) colors.Add(Colors.Purple);
			if (_stop.PurpleExpress) colors.Add(Colors.Purple); 
			if (_stop.Yellow) colors.Add(Colors.Yellow);
			if (_stop.Pink) colors.Add(Colors.Pink);
			if (_stop.Orange) colors.Add(Colors.Orange);

			return colors;
		}

	}
}
