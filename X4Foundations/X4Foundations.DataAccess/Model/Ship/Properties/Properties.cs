using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Ship.Properties
{
	[Serializable, XmlRoot("properties")]
	public class Properties
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
		[XmlElement("ship")]
		public Ship Ship { get; set; } = new Ship();
		[XmlElement("thruster")]
		public Thruster Thruster { get; set; } = new Thruster();
	}
}
