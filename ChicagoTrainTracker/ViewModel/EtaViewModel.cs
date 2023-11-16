using ChicagoTrainTracker.Model;
using System;

namespace ChicagoTrainTracker.ViewModel
{
	public class EtaViewModel : ViewModelBase
	{
		private readonly Eta _etaData;

		public string Route => _etaData.Route;
		public int RouteNumber => _etaData.RouteNumber;
		public string StopDescription => _etaData.StopDescription;
		public string DestinationName => _etaData.DestinationName;
		public DateTime ArrivalTime => _etaData.ArrivalTime;
		public int IsApproaching => _etaData.IsApproaching;
		public int IsDelayed => _etaData.IsDelayed;

		public EtaViewModel(Eta etaData)
		{
			_etaData = etaData;
		}
	}
}
