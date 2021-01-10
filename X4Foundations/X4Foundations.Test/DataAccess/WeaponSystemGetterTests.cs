using System.Collections.Generic;
using System.Reflection;
using X4Foundations.DataAccess.DataAccess;
using Xunit;

namespace X4Foundations.Test.DataAccess.DataAccess
{
	public class WeaponSystemGetterTests
	{
		private const string BaseFolderPath = @"DataAccess\TestData\BaseWeaponSystemFolder";

		[Fact]
		public void GetWeaponSystemMacroFolders_GetsExpectedFolders()
		{
			WeaponSystemGetter weaponSystemGetter = new WeaponSystemGetter("some string");
			MethodInfo methodInfo = typeof(WeaponSystemGetter).GetMethod("GetWeaponSystemMacroFolders", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { BaseFolderPath };

			// Method under test
			List<string> weaponSystemMacroFolders = (List<string>)methodInfo.Invoke(weaponSystemGetter, parameters);

			Assert.Equal(3, weaponSystemMacroFolders.Count);
			Assert.Equal($@"{BaseFolderPath}\capital\macros", weaponSystemMacroFolders[0]);
			Assert.Equal($@"{BaseFolderPath}\dumbfire\macros", weaponSystemMacroFolders[1]);
			Assert.Equal($@"{BaseFolderPath}\standard\macros", weaponSystemMacroFolders[2]);
		}

		[Fact]
		public void GetWeaponSystemFilePaths_GetsExpectedFilePaths()
		{
			List<string> weaponSystemFolders = new List<string> {$@"{BaseFolderPath}\capital\macros", $@"{BaseFolderPath}\dumbfire\macros", $@"{BaseFolderPath}\standard\macros"};
			WeaponSystemGetter weaponSystemGetter = new WeaponSystemGetter("some string");
			MethodInfo methodInfo = typeof(WeaponSystemGetter).GetMethod("GetWeaponSystemFilePaths", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weaponSystemFolders };

			// Method under test
			List<string> weaponSystemFilePaths = (List<string>)methodInfo.Invoke(weaponSystemGetter, parameters);

			Assert.Equal(4, weaponSystemFilePaths.Count);
			Assert.Equal($@"{BaseFolderPath}\capital\macros\capitalEmpty1.xml", weaponSystemFilePaths[0]);
			Assert.Equal($@"{BaseFolderPath}\capital\macros\capitalEmpty2.xml", weaponSystemFilePaths[1]);
			Assert.Equal($@"{BaseFolderPath}\dumbfire\macros\dumbfireEmpty1.xml", weaponSystemFilePaths[2]);
			Assert.Equal($@"{BaseFolderPath}\standard\macros\standardEmpty1.xml", weaponSystemFilePaths[3]);
		}
	}
}
