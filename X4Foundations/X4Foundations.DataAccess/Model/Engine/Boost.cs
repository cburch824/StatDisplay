using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Engine
{
	[Serializable, XmlRoot("boost")]
	public class Boost
	{
		[XmlAttribute("duration")]
		public double Duration { get; set; }
		[XmlAttribute("thrust")]
		public double Thrust { get; set; }
		[XmlAttribute("attack")]
		public double Attack { get; set; }
		[XmlAttribute("release")]
		public double Release { get; set; }
	}
}
