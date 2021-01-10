using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Bullet
{
	[Serializable, XmlRoot("properties")]
	public class Properties
	{
		[XmlElement("bullet")]
		public Bullet Bullet { get; set; } = new Bullet();
		[XmlElement("damage")]
		public Damage Damage { get; set; } = new Damage();
		[XmlElement("heat")]
		public Heat Heat { get; set; } = new Heat();
		[XmlElement("reload")]
		public Reload Reload { get; set; } = new Reload();
	}
}
