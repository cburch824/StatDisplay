using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.WeaponSystem
{
	[Serializable, XmlRoot("bullet")]
	public class Bullet
	{
		[XmlAttribute("class")]
		public string Class { get; set; }

		//public BulletModel BulletModel { get; set; } = new BulletModel();
	}
}
