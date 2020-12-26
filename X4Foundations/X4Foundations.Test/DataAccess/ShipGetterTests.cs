using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using X4Foundations.DataAccess;
using Xunit;

namespace X4Foundations.Test.DataAccess
{
	public class ShipGetterTests
	{
		private const string BaseFolderPath = @"DataAccess\TestData\BaseShipFolder";

		[Fact]
		public void GetShipMacroFolders_ReturnedSuccessfully()
		{
			ShipGetter shipGetter = new ShipGetter("some string");
			MethodInfo methodInfo = typeof(ShipGetter).GetMethod("GetShipMacroFolders", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { BaseFolderPath };

			// Method under test
			List<string> shipMacroFolders = (List<string>)methodInfo.Invoke(shipGetter, parameters);

			Assert.Equal(5, shipMacroFolders.Count);
			Assert.Equal($@"{BaseFolderPath}\size_l\macros", shipMacroFolders[0]);
			Assert.Equal($@"{BaseFolderPath}\size_m\macros", shipMacroFolders[1]);
			Assert.Equal($@"{BaseFolderPath}\size_s\macros", shipMacroFolders[2]);
			Assert.Equal($@"{BaseFolderPath}\size_xl\macros", shipMacroFolders[3]);
			Assert.Equal($@"{BaseFolderPath}\size_xs\macros", shipMacroFolders[4]);
		}
	}
}
