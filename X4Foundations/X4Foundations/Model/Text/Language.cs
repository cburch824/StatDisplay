using System;
using System.Xml.Serialization;

namespace X4Foundations.Model.Text
{
	[Serializable, XmlRoot("language")]
	public class Language
	{
		[XmlAttribute("id")]
		public string Id { get; set; }
		[XmlAttribute("name")]
		public string Name { get; set; }
	}
}
