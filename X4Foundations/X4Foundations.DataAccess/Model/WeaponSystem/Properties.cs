using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.WeaponSystem
{
	[Serializable, XmlRoot("properties")]
	public class Properties
	{
		[XmlElement("bullet")]
		public Bullet Bullet { get; set; } = new Bullet();
		[XmlElement("rotationacceleration")]
		public RotationAcceleration RotationAcceleration { get; set; } = new RotationAcceleration();
		[XmlElement("rotationspeed")]
		public RotationSpeed RotationSpeed { get; set; } = new RotationSpeed();
		[XmlElement("reload")]
		public Reload Reload { get; set; } = new Reload();
		[XmlElement("hull")]
		public Hull Hull { get; set; } = new Hull();
		[XmlElement("heat")]
		public Heat Heat { get; set; } = new Heat();
	}
}
