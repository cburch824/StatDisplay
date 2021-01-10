using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using X4Foundations.DataAccess.DataAccess;
using X4Foundations.DataAccess.Model.Ship.Properties;
using Xunit;

namespace X4Foundations.Test.DataAccess.DataAccess
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

		[Fact]
		public void GetShipFilePaths_ReturnedSuccessfully()
		{
			ShipGetter shipGetter = new ShipGetter("some string");
			MethodInfo methodInfo = typeof(ShipGetter).GetMethod("GetShipMacroFolders", BindingFlags.NonPublic | BindingFlags.Instance);
			MethodInfo getShipFilePathsMethodInfo = typeof(ShipGetter).GetMethod("GetShipFilePaths", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { BaseFolderPath };

			// Method under test
			List<string> shipMacroFolders = (List<string>)methodInfo.Invoke(shipGetter, parameters);
			object[] shipFilePathsParameters = { shipMacroFolders };
			List<string> shipFilePaths = (List<string>)getShipFilePathsMethodInfo.Invoke(shipGetter, shipFilePathsParameters);

			Assert.Equal(5, shipFilePaths.Count);
			Assert.Equal($@"{BaseFolderPath}\size_l\macros\ship_arg_l_destroyer_01_a_macro.xml", shipFilePaths[0]);
			Assert.Equal($@"{BaseFolderPath}\size_m\macros\ship_arg_m_trans_container_01_a_macro.xml", shipFilePaths[1]);
			Assert.Equal($@"{BaseFolderPath}\size_s\macros\ship_arg_s_fighter_01_a_macro.xml", shipFilePaths[2]);
			Assert.Equal($@"{BaseFolderPath}\size_xl\macros\ship_arg_xl_builder_01_a_macro.xml", shipFilePaths[3]);
			Assert.Equal($@"{BaseFolderPath}\size_xs\macros\ship_arg_xs_cv_01_a_macro.xml", shipFilePaths[4]);
		}

		[Fact]
		public void ParseShipXml_PopulateAllXmlRelatedFields()
		{
			XmlDocument document = new XmlDocument();
			document.Load(@"DataAccess\TestData\ValidShipXml.xml");
			ShipGetter shipGetter = new ShipGetter("some folder");
			MethodInfo methodInfo = typeof(ShipGetter).GetMethod("ParseShipPropertiesXml", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { document };

			// Method under test
			Properties shipProperties = new Properties();
			shipProperties = (Properties)methodInfo.Invoke(shipGetter, parameters);

			Assert.Equal(3100, shipProperties.Hull.Max);
			Assert.Equal(1000, shipProperties.RotationAcceleration.Max);
			Assert.Equal(1000, shipProperties.RotationSpeed.Max);
			Assert.Equal(3, shipProperties.People.Capacity);
			Assert.Equal("small", shipProperties.Thruster.Tags);
			Assert.Equal("fighter", shipProperties.Ship.Type);
		}
	}
}
