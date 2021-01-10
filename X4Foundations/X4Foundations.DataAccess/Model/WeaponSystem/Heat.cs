using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.WeaponSystem
{
	[Serializable, XmlRoot("heat")]
	public class Heat
	{
		[XmlAttribute("value")]
		public double Value { get; set; }
		[XmlAttribute("overheat")]
		public double Overheat { get; set; }
		[XmlAttribute("cooldelay")]
		public double CoolDelay { get; set; }
		[XmlAttribute("coolrate")]
		public double CoolRate { get; set; }
		[XmlAttribute("reenable")]
		public double Reenable { get; set; }

	}
}
