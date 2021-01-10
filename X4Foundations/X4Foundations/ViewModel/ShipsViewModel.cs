using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using X4Foundations.DataAccess;
using X4Foundations.Model.Ship;

namespace X4Foundations.ViewModel
{
	public class ShipsViewModel
	{
		public IList<ShipModel> Ships { get; set; }
		public ICommand UpdateCommand { get; set; } = new Updater();

		public ShipsViewModel()
		{
			const string shipsFolderPath = @"C:\Program Files (x86)\Steam\steamapps\common\X4 Foundations\unpacked\assets\units";
			Ships = new ShipGetter(shipsFolderPath).PopulateShips();
		}
	}
}
