using System.Collections.Generic;
using System.Windows.Input;
using X4Foundations.DataAccess;
using X4Foundations.DataAccess.WeaponSystemGetters;
using X4Foundations.Model.WeaponSystem;

namespace X4Foundations.ViewModel
{
	public class WeaponsViewModel
	{
		public IList<IWeaponSystemModel> Weapons { get; set; }
		public ICommand UpdateCommand { get; set; } = new Updater();

		public WeaponsViewModel()
		{
			const string weaponSystemBaseFolder = @"C:\Program Files (x86)\Steam\steamapps\common\X4 Foundations\unpacked\assets\props\WeaponSystems";
			Weapons = new WeaponSystemGetter(weaponSystemBaseFolder).PopulateWeaponSystems(WeaponSystemClass.weapon);
		}
	}
}
