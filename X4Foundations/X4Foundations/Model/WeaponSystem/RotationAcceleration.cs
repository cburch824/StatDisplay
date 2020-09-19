using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.WeaponSystem
{
	[Serializable, XmlRoot("rotationacceleration")]
	public class RotationAcceleration
	{
		[XmlAttribute("max")]
		public double Max { get; set; }
	}
}
