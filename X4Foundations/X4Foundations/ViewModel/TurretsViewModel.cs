using System.Collections.Generic;
using System.Windows.Input;
using X4Foundations.DataAccess;
using X4Foundations.Model.WeaponSystem;

namespace X4Foundations.ViewModel
{
	public class TurretsViewModel
	{
		public IList<IWeaponSystemModel> Turrets { get; set; }
		public ICommand UpdateCommand { get; set; } = new Updater();

		public TurretsViewModel()
		{
			const string weaponSystemBaseFolder = @"C:\Program Files (x86)\Steam\steamapps\common\X4 Foundations\unpacked\assets\props\WeaponSystems";
			Turrets = new WeaponSystemGetter(weaponSystemBaseFolder).PopulateWeaponSystems(WeaponSystemClass.turret);
		}
	}
}
