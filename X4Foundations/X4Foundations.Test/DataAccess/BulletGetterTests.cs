using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using X4Foundations.DataAccess;
using X4Foundations.Model.Bullet;
using Xunit;

namespace X4Foundations.Test.DataAccess
{
	public class BulletGetterTests
	{
		#region Private Methods
		#region DetermineBulletWeaponType
		[Fact]
		public void DetermineBulletWeaponType_IsTurret()
		{
			const string bulletFileName = "bullet_arg_turret_l_beam_01_mk1_macro.xml";
			List<string> bulletFileNameSubParts = bulletFileName.Split('_').ToList();
			bulletFileNameSubParts.Remove("bullet");
			bulletFileNameSubParts.Remove("macro.xml");
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("DetermineBulletWeaponType", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bulletFileNameSubParts };

			// Method under test
			BulletWeaponType weaponTypeResult = (BulletWeaponType) methodInfo.Invoke(bulletGetter, parameters);

			Assert.Equal(BulletWeaponType.turret, weaponTypeResult);
		}

		[Fact]
		public void DetermineBulletWeaponType_IsPrimary()
		{
			const string bulletFileName = "bullet_arg_m_ion_01_mk1_macro.xml";
			List<string> bulletFileNameSubParts = bulletFileName.Split('_').ToList();
			bulletFileNameSubParts.Remove("bullet");
			bulletFileNameSubParts.Remove("macro.xml");
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("DetermineBulletWeaponType", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bulletFileNameSubParts };

			// Method under test
			BulletWeaponType weaponTypeResult = (BulletWeaponType)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Equal(BulletWeaponType.primary, weaponTypeResult);
		}
		#endregion DetermineBulletWeaponType
		#endregion Private Methods
	}
}
