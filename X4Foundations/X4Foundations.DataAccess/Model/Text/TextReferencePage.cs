
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Text
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
