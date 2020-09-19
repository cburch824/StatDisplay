using System;
using System.Xml.Serialization;
using X4Foundations.Model.Bullet;

namespace X4Foundations.Model.WeaponSystem
{
	[Serializable, XmlRoot("bullet")]
	public class Bullet
	{
		[XmlAttribute("class")]
		public string Class { get; set; }

		//public BulletModel BulletModel { get; set; } = new BulletModel();
	}
}
