using System.Collections.Generic;
using System.Windows.Input;
using X4Foundations.DataAccess.DataAccess;
using X4Foundations.DataAccess.Model.Ship;

namespace X4Foundations.FrontEnd.Wpf.ViewModel
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
