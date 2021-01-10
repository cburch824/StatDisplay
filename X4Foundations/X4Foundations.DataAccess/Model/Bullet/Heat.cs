using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Bullet
{
	[Serializable, XmlRoot("heat")]
	public class Heat
	{
		[XmlAttribute("value")]
		public double Value { get; set; }
	}
}
