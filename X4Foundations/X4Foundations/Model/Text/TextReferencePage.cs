
using System.Xml.Serialization;

namespace X4Foundations.Model.Text
{
	[XmlRoot("page")]
	public class TextReferencePage
	{
		[XmlAttribute("id")]
		public string Id { get; set; }
		[XmlAttribute("title")]
		public string Title { get; set; }
	}
}
