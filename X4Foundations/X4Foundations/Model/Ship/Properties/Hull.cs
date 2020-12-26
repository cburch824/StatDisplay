using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace X4Foundations.Model.Ship.Properties
{
	[Serializable, XmlRoot("hull")]
	public class Hull
	{
		[XmlAttribute("max")]
		public double Max { get; set; }
	}
}
