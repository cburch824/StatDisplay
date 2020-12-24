using System.Collections.Generic;
using X4Foundations.Model.Text;

namespace X4Foundations.DataAccess.Repository.Text
{
	public interface IShipNameRepository
	{
		List<TextReference> GeTextReferences();
		string GetShipNameByReferenceId(string referenceId);
	}
}
