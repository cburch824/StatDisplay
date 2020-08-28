using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.Bullet
{
	[Serializable, XmlRoot("heat")]
	public class Heat
	{
		[XmlAttribute("value")]
		public double Value { get; set; }
	}
}
