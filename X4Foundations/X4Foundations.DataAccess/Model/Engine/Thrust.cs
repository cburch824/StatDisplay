using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Engine
{
	[Serializable, XmlRoot("thrust")]
	public class Thrust
	{
		[XmlAttribute("forward")]
		public double Forward { get; set; }
		[XmlAttribute("reverse")]
		public double Reverse { get; set; }
	}
}
