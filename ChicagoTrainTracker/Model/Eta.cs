using System;
using System.Xml.Serialization;

namespace ChicagoTrainTracker.Model
{
	public class Eta
	{
		[XmlElement("staId")]
		public int StationId { get; set; }

		[XmlElement("stpId")]
		public int StopId { get; set; }

		[XmlElement("staNm")]
		public string StationName { get; set; }

		[XmlElement("stpDe")]
		public string StopDescription { get; set; }

		[XmlElement("rn")]
		public int RouteNumber { get; set; }

		[XmlElement("rt")]
		public string Route { get; set; }

		[XmlElement("destSt")]
		public int DestinationStationId { get; set; }

		[XmlElement("destNm")]
		public string DestinationName { get; set; }

		[XmlElement("trDr")]
		public int TrainDirection { get; set; }

		[XmlElement("prdt")]
		public DateTime PredictionTime { get; set; }

		[XmlElement("arrT")]
		public DateTime ArrivalTime { get; set; }

		[XmlElement("isApp")]
		public int IsApproaching { get; set; }

		[XmlElement("isSch")]
		public int IsScheduled { get; set; }

		[XmlElement("isDly")]
		public int IsDelayed { get; set; }

		[XmlElement("isFlt")]
		public int IsFault { get; set; }

		[XmlElement("flags")]
		public string Flags { get; set; }

		[XmlElement("lat")]
		public double Latitude { get; set; }

		[XmlElement("lon")]
		public double Longitude { get; set; }

		[XmlElement("heading")]
		public int Heading { get; set; }
	}
}
