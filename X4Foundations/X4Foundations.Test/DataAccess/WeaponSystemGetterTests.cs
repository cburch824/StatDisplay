using System.Collections.Generic;
using System.Reflection;
using X4Foundations.DataAccess;
using X4Foundations.Model.Bullet;
using Xunit;

namespace X4Foundations.Test.DataAccess
{
	public class WeaponSystemGetterTests
	{
		[Fact]
		public void GetWeaponSystemMacroFolders_GetsExpectedFolders()
		{
			const string baseFolderPath = @"DataAccess\TestData\BaseWeaponSystemFolder";
			WeaponSystemGetter weaponSystemGetter = new WeaponSystemGetter("some string");
			MethodInfo methodInfo = typeof(WeaponSystemGetter).GetMethod("GetWeaponSystemMacroFolders", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { baseFolderPath };

			// Method under test
			List<string> weaponSystemMacroFolders = (List<string>)methodInfo.Invoke(weaponSystemGetter, parameters);

			Assert.Equal(3, weaponSystemMacroFolders.Count);
			Assert.Equal($@"{baseFolderPath}\capital\macros", weaponSystemMacroFolders[0]);
			Assert.Equal($@"{baseFolderPath}\dumbfire\macros", weaponSystemMacroFolders[1]);
			Assert.Equal($@"{baseFolderPath}\standard\macros", weaponSystemMacroFolders[2]);
		}

		[Fact]
		public void GetWeaponSystemFilePaths_GetsExpectedFilePaths()
		{
			const string baseFolderPath = @"DataAccess\TestData\BaseWeaponSystemFolder";
			List<string> weaponSystemFolders = new List<string> {$@"{baseFolderPath}\capital\macros", $@"{baseFolderPath}\dumbfire\macros", $@"{baseFolderPath}\standard\macros"};
			WeaponSystemGetter weaponSystemGetter = new WeaponSystemGetter("some string");
			MethodInfo methodInfo = typeof(WeaponSystemGetter).GetMethod("GetWeaponSystemFilePaths", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weaponSystemFolders };

			// Method under test
			List<string> weaponSystemFilePaths = (List<string>)methodInfo.Invoke(weaponSystemGetter, parameters);

			Assert.Equal(4, weaponSystemFilePaths.Count);
			Assert.Equal($@"{baseFolderPath}\capital\macros\capitalEmpty1.xml", weaponSystemFilePaths[0]);
			Assert.Equal($@"{baseFolderPath}\capital\macros\capitalEmpty2.xml", weaponSystemFilePaths[1]);
			Assert.Equal($@"{baseFolderPath}\dumbfire\macros\dumbfireEmpty1.xml", weaponSystemFilePaths[2]);
			Assert.Equal($@"{baseFolderPath}\standard\macros\standardEmpty1.xml", weaponSystemFilePaths[3]);
		}
	}
}
