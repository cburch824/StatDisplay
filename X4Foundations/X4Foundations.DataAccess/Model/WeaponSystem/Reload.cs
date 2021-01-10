using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.WeaponSystem
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
