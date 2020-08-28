using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.Bullet
{
	[Serializable, XmlRoot("damage")]
	public class Damage
	{
		[XmlAttribute("value")]
		public double Value { get; set; }
		[XmlAttribute("shield")]
		public double Shield { get; set; }
		[XmlAttribute("repair")]
		public double Repair { get; set; }
	}
}
