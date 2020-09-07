using System.Xml.Serialization;

namespace X4Foundations.Model.Bullet
{
	public class Properties
	{
		[XmlElement("bullet")]
		public Bullet Bullet { get; set; }
		[XmlElement("damage")]
		public Damage Damage { get; set; }
		[XmlElement("heat")]
		public Heat Heat { get; set; }
		[XmlElement("reload")]
		public Reload Reload { get; set; }
	}
}
