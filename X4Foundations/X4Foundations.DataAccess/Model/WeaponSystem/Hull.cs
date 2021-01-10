using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.WeaponSystem
{
	[Serializable, XmlRoot("hull")]
	public class Hull
	{
		[XmlAttribute("max")]
		public double Max { get; set; }
		[XmlAttribute("threshold")]
		public double Threshold { get; set; }
		[XmlAttribute("integrated")]
		public double Integrated { get; set; }
		[XmlAttribute("hittable")]
		public double Hittable { get; set; }
	}
}
