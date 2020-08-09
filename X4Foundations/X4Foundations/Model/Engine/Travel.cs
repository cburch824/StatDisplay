using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.Engine
{
	[Serializable, XmlRoot("travel")]
	public class Travel
	{
		[XmlAttribute("charge")]
		public double Charge { get; set; }
		[XmlAttribute("thrust")]
		public double Thrust { get; set; }
		[XmlAttribute("attack")]
		public double Attack { get; set; }
		[XmlAttribute("release")]
		public double Release { get; set; }
	}
}
