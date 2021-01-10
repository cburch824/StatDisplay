using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Bullet
{
	[Serializable, XmlRoot("bullet")]
	public class Bullet
	{
		[XmlAttribute("speed")]
		public double Speed { get; set; }
		[XmlAttribute("lifetime")]
		public double Lifetime { get; set; }
		[XmlAttribute("amount")]
		public double Amount { get; set; }
		[XmlAttribute("barrelamount")]
		public double BarrelAmount { get; set; }
		[XmlAttribute("timediff")]
		public double TimeDiff { get; set; }
		[XmlAttribute("angle")]
		public double Angle { get; set; }
		[XmlAttribute("maxhits")]
		public double MaxHits { get; set; }
		[XmlAttribute("ricochet")]
		public double Ricochet { get; set; }
		[XmlAttribute("scale")]
		public double Scale { get; set; }
		[XmlAttribute("attach")]
		public double Attach { get; set; }
	}
}
