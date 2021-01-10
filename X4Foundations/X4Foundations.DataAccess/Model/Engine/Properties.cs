using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Engine
{
	[Serializable, XmlRoot("properties")]
	public class Properties
	{
		[XmlElement("boost")]
		public Boost Boost { get; set; } = new Boost();
		[XmlElement("travel")]
		public Travel Travel { get; set; } = new Travel();
		[XmlElement("thrust")]
		public Thrust Thrust { get; set; } = new Thrust();
		[XmlElement("hull")]
		public Hull Hull { get; set; } = new Hull();
	}
}
