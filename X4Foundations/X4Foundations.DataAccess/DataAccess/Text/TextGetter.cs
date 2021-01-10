using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using X4Foundations.DataAccess.Model.Text;

namespace X4Foundations.DataAccess.DataAccess.Text
{
	public class TextGetter
	{
		private readonly string _textXmlFile;

		public TextGetter(string textXmlFile)
		{
			_textXmlFile = textXmlFile;
		}

		public IEnumerable<TextReference> GetShipTextReferences()
		{
			List<TextReference> shipTextReferences = new List<TextReference>();
			using XmlReader reader = new XmlTextReader(_textXmlFile);


			// Find the correct page
			reader.MoveToContent();
			reader.ReadToDescendant("page");
			XmlSerializer pageXmlSerializer = new XmlSerializer(typeof(TextReferencePage));

			do
			{
				XmlDocument doc = new XmlDocument();
				var xmlString = reader.ReadOuterXml();
				doc.LoadXml(xmlString);
				XmlNode xmlNode = doc.DocumentElement;
				TextReferencePage textRefPage = (TextReferencePage)pageXmlSerializer.Deserialize(new XmlNodeReader(xmlNode));

				if (textRefPage.Title == "Ships")
				{
					shipTextReferences = GetShipTextReferencesFromDocument(doc.FirstChild.ChildNodes);
					break;
				}
			}
			while (reader.ReadToNextSibling("page"));

			return shipTextReferences;
		}

		private List<TextReference> GetShipTextReferencesFromDocument(XmlNodeList shipNodeList)
		{
			List<TextReference> shipTextReferences = new List<TextReference>();
			XmlSerializer tXmlSerializer = new XmlSerializer(typeof(TextReference));

			foreach (XmlNode shipNode in shipNodeList)
			{
				TextReference textRef = (TextReference)tXmlSerializer.Deserialize(new XmlNodeReader(shipNode));
				if(IsShipNameTextReference(textRef))
					shipTextReferences.Add(textRef);
			}

			return shipTextReferences;
		}

		private bool IsShipNameTextReference(TextReference textRef)
		{
			//todo - write this method to determine if the listed name is a ship name or not
			return true;
		}

		private string TrimShipName(string rawShipName)
		{
			//todo - write this method to trim off the parens, id references
			return rawShipName;
		}
	}
}
