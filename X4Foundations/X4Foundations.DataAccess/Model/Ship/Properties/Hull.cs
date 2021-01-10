using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Ship.Properties
{
	[Serializable, XmlRoot("hull")]
	public class Hull
	{
		[XmlAttribute("max")]
		public double Max { get; set; }
	}
}
