using System.Collections.Generic;
using System.Linq;
using X4Foundations.DataAccess.Text;
using X4Foundations.Model.Text;

namespace X4Foundations.DataAccess.Repository.Text
{
	public class ShipNameRepository : IShipNameRepository
	{

		private readonly IEnumerable<TextReference> _shipNameReferences;
		private readonly FileLocationsDictionary _fileLocationsDictionary = new FileLocationsDictionary();

		public ShipNameRepository()
		{
			_shipNameReferences = PopulateShipNames();
		}

		public List<TextReference> GeTextReferences()
		{
			return _shipNameReferences.ToList();
		}

		public string GetShipNameByReferenceId(string referenceId)
		{
			return _shipNameReferences.First(x => x.Id == referenceId).Value;
		}

		private IEnumerable<TextReference> PopulateShipNames()
		{
			TextGetter textGetter = new TextGetter(_fileLocationsDictionary.FileLocationsByName[FileLocationName.TextReferences]);
			return textGetter.GetShipTextReferences();
		}
	}
}
