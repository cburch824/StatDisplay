using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Ship.Properties
{
	[Serializable, XmlRoot("purpose")]
	public class Purpose
	{
		[XmlAttribute("primary")]
		public string Primary { get; set; }
	}
}
