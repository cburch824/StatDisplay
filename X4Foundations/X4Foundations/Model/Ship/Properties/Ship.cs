using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.Ship.Properties
{
	[Serializable, XmlRoot("ship")]
	public class Ship
	{
		[XmlAttribute("type")]
		public string Type { get; set; }
	}
}
