using System.Collections.Generic;
using System.Windows.Input;
using X4Foundations.DataAccess.DataAccess;
using X4Foundations.DataAccess.Model.Bullet;

namespace X4Foundations.FrontEnd.Wpf.ViewModel
{
	class BulletsViewModel
	{
		public IList<BulletModel> Bullets { get; set; }
		public ICommand UpdateCommand { get; set; } = new Updater();

		public BulletsViewModel()
		{
			const string engineFolderPath = @"C:\Program Files (x86)\Steam\steamapps\common\X4 Foundations\unpacked\assets\fx\weaponFx\macros";
			Bullets = new BulletGetter(engineFolderPath).PopulateBullets();
		}
	}
}
