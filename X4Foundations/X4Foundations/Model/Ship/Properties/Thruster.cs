using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.Ship.Properties
{
	[Serializable, XmlRoot("thruster")]
	public class Thruster
	{
		[XmlAttribute("tags")]
		public string Tags { get; set; }
	}
}
