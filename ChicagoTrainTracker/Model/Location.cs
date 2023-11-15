using System.Xml.Serialization;

namespace ChicagoTrainTracker.Model
{
	public class Location
	{
		[XmlAttribute("latitude")]
		public double Latitude { get; set; }

		[XmlAttribute("longitude")]
		public double Longitude { get; set; }
	}
}
