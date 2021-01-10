using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Text
{
	[XmlRoot("t")]
	public class TextReference
	{
		[XmlAttribute("id")]
		public string Id { get; set; }
		[XmlText]
		public string Value { get; set; }
	}
}
