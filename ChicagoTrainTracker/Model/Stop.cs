using System.Xml.Serialization;

namespace ChicagoTrainTracker.Model
{
	public class Stop
	{
		[XmlElement("stop_id")]
		public int StopId { get; set; }

		[XmlElement("direction_id")]
		public string DirectionId { get; set; }

		[XmlElement("stop_name")]
		public string StopName { get; set; }

		[XmlElement("station_name")]
		public string StationName { get; set; }

		[XmlElement("station_descriptive_name")]
		public string StationDescriptiveName { get; set; }

		[XmlElement("map_id")]
		public int MapId { get; set; }

		[XmlElement("ada")]
		public bool Ada { get; set; }

		[XmlElement("red")]
		public bool Red { get; set; }

		[XmlElement("blue")]
		public bool Blue { get; set; }

		[XmlElement("g")]
		public bool Green { get; set; }

		[XmlElement("brn")]
		public bool Brown { get; set; }

		[XmlElement("p")]
		public bool Purple { get; set; }

		[XmlElement("pexp")]
		public bool PurpleExpress { get; set; }

		[XmlElement("y")]
		public bool Yellow { get; set; }

		[XmlElement("pnk")]
		public bool Pink { get; set; }

		[XmlElement("o")]
		public bool Orange { get; set; }

		[XmlElement("location")]
		public Location Location { get; set; }
	}
}
