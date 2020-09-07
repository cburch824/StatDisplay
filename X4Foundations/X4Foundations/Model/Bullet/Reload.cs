using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.Bullet
{
	[Serializable, XmlRoot("reload")]
	public class Reload
	{
		[XmlAttribute("rate")]
		public double Rate { get; set; }
		[XmlAttribute("time")]
		public double Time { get; set; }
	}
}
