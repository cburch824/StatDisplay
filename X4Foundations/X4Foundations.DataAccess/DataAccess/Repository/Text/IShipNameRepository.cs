using System.Collections.Generic;
using X4Foundations.DataAccess.Model.Text;

namespace X4Foundations.DataAccess.DataAccess.Repository.Text
{
	public interface IShipNameRepository
	{
		List<TextReference> GeTextReferences();
		string GetShipNameByReferenceId(string referenceId);
	}
}
