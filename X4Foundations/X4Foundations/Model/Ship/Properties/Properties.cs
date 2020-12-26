using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.Ship.Properties
{
	[Serializable, XmlRoot("properties")]
	class Properties
	{
		[XmlElement("hull")]
		public Hull Hull { get; set; } = new Hull();
		[XmlElement("people")]
		public People People { get; set; } = new People();
		[XmlElement("purpose")]
		public Purpose Purpose { get; set; } = new Purpose();
		[XmlElement("rotationacceleration")]
		public RotationAcceleration RotationAcceleration { get; set; } = new RotationAcceleration();
		[XmlElement("rotationspeed")]
		public RotationSpeed RotationSpeed { get; set; } = new RotationSpeed();
		[XmlElement("thruster")]
		public Thruster Thruster { get; set; } = new Thruster();
	}
}
