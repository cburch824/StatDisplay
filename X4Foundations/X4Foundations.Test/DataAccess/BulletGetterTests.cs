using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using X4Foundations.DataAccess;
using X4Foundations.Model.Bullet;
using X4Foundations.Model.Bullet;
using Xunit;
using Properties = X4Foundations.Model.Bullet.Properties;

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

		#region RemoveMultitermBulletFileNameParameters
		[Fact]
		public void RemoveMultitermBulletFileNameParameters_HasNoMultitermParameters()
		{
			const string bulletFileName = "bullet_arg_turret_l_beam_01_mk1_macro.xml";
			List<string> bulletFileNameSubParts = bulletFileName.Split('_').ToList();
			bulletFileNameSubParts.Remove("bullet");
			bulletFileNameSubParts.Remove("macro.xml");
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("RemoveMultitermBulletFileNameParameters", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bulletFileNameSubParts };

			// Method under test
			List<string> bulletFileNameSubPartsAfterMethodCall = new List<string>();
			bulletFileNameSubPartsAfterMethodCall = (List<string>)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Equal(bulletFileNameSubParts.Count, bulletFileNameSubPartsAfterMethodCall.Count);
			for (int i = 0; i < bulletFileNameSubParts.Count; i++)
			{
				Assert.Equal(bulletFileNameSubParts[i], bulletFileNameSubPartsAfterMethodCall[i]);
			}
		}

		//[Fact]
		//public void RemoveMultitermBulletFileNameParameters_HasMultitermParameters_LimpetMine()
		//{
		//	const string bulletFileName = "bullet_limpet_mine_01_mk1_macro.xml";
		//	List<string> bulletFileNameSubParts = bulletFileName.Split('_').ToList();
		//	bulletFileNameSubParts.Remove("bullet");
		//	bulletFileNameSubParts.Remove("macro.xml");
		//	BulletGetter bulletGetter = new BulletGetter("some folder");
		//	MethodInfo methodInfo = typeof(BulletGetter).GetMethod("RemoveMultitermBulletFileNameParameters", BindingFlags.NonPublic | BindingFlags.Instance);
		//	object[] parameters = { bulletFileNameSubParts };

		//	// Method under test
		//	List<string> bulletFileNameSubPartsAfterMethodCall = new List<string>();
		//	bulletFileNameSubPartsAfterMethodCall = (List<string>)methodInfo.Invoke(bulletGetter, parameters);

		//	Assert.Equal(bulletFileNameSubParts.Count, bulletFileNameSubPartsAfterMethodCall.Count + 1);
		//	Assert.Equal("LimpetMine", bulletFileNameSubPartsAfterMethodCall[0]);
		//	Assert.Equal("01", bulletFileNameSubPartsAfterMethodCall[1]);
		//	Assert.Equal("mk1", bulletFileNameSubPartsAfterMethodCall[2]);
		//}

		//[Fact]
		//public void RemoveMultitermBulletFileNameParameters_HasMultitermParameters_MissileDumbfire()
		//{
		//	const string bulletFileName = "bullet_missile_dumbfire_mk1_macro.xml";
		//	List<string> bulletFileNameSubParts = bulletFileName.Split('_').ToList();
		//	bulletFileNameSubParts.Remove("bullet");
		//	bulletFileNameSubParts.Remove("macro.xml");
		//	BulletGetter bulletGetter = new BulletGetter("some folder");
		//	MethodInfo methodInfo = typeof(BulletGetter).GetMethod("RemoveMultitermBulletFileNameParameters", BindingFlags.NonPublic | BindingFlags.Instance);
		//	object[] parameters = { bulletFileNameSubParts };

		//	// Method under test
		//	List<string> bulletFileNameSubPartsAfterMethodCall = new List<string>();
		//	bulletFileNameSubPartsAfterMethodCall = (List<string>)methodInfo.Invoke(bulletGetter, parameters);

		//	Assert.Equal(bulletFileNameSubParts.Count, bulletFileNameSubPartsAfterMethodCall.Count + 1);
		//	Assert.Equal("MissileDumbfire", bulletFileNameSubPartsAfterMethodCall[0]);
		//	Assert.Equal("mk1", bulletFileNameSubPartsAfterMethodCall[1]);
		//}
		#endregion RemoveMultitermBulletFileNameParameters

		#region GenerateBulletName
		[Fact]
		public void GenerateBulletName_BulletHasNoVersion()
		{
			BulletModel bullet = new BulletModel { Faction = FactionType.BUC, Grade = BulletGrade.mk1, Name = "Some Bullet Name", Size = BulletSize.s, Type = BulletType.laser };
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("GenerateBulletName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet };

			// Method under test
			string bulletName = (string)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Equal("S BUC Laser Bullet Mk1", bulletName);
		}

		[Fact]
		public void GenerateBulletName_BulletHasVersion01()
		{
			BulletModel bullet = new BulletModel { Faction = FactionType.BUC, Grade = BulletGrade.mk1, Name = "Some Bullet Name", Size = BulletSize.s, Type = BulletType.laser, Version = 1 };
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("GenerateBulletName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet };

			// Method under test
			string bulletName = (string)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Equal("S BUC Laser Bullet Mk1", bulletName);
		}

		[Fact]
		public void GenerateBulletName_BulletHasVersion02()
		{
			BulletModel bullet = new BulletModel { Faction = FactionType.BUC, Grade = BulletGrade.mk1, Name = "Some Bullet Name", Size = BulletSize.s, Type = BulletType.laser, Version = 2 };
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("GenerateBulletName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet };

			// Method under test
			string bulletName = (string)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Equal("S BUC Laser Bullet Mk1 02", bulletName);
		}
		#endregion GenerateBulletName

		#region ParseBulletSubstring
		[Fact]
		public void ParseBulletSubstring_AllParsingFails()
		{
			const string bulletSubstring = "invalid string to parse";
			BulletModel bullet = new BulletModel();
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("ParseBulletSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet, bulletSubstring };


			// Method under test
			void Action() => bullet = (BulletModel)methodInfo.Invoke(bulletGetter, parameters);

			Exception exception = Assert.Throws<TargetInvocationException>(Action);
			Assert.Equal($"Failed to parse bullet substring \"{bulletSubstring}\"", exception.InnerException.Message);

			Assert.Null(bullet.Faction);
			Assert.Null(bullet.Size);
			Assert.Null(bullet.Type);
			Assert.Null(bullet.Grade);
			Assert.Null(bullet.Version);
		}

		[Fact]
		public void ParseBulletSubstring_FactionFound()
		{
			const string bulletSubstring = "arg";
			BulletModel bullet = new BulletModel();
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("ParseBulletSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet, bulletSubstring };

			// Method under test
			bullet = (BulletModel)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Equal(FactionType.ARG, bullet.Faction);
			Assert.Null(bullet.Size);
			Assert.Null(bullet.Type);
			Assert.Null(bullet.Grade);
			Assert.Null(bullet.Version);
		}

		[Fact]
		public void ParseBulletSubstring_SizeFound()
		{
			const string bulletSubstring = "s";
			BulletModel bullet = new BulletModel();
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("ParseBulletSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet, bulletSubstring };

			// Method under test
			bullet = (BulletModel)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Null(bullet.Faction);
			Assert.Equal(BulletSize.s, bullet.Size);
			Assert.Null(bullet.Type);
			Assert.Null(bullet.Grade);
			Assert.Null(bullet.Version);
		}

		[Fact]
		public void ParseBulletSubstring_TypeFound()
		{
			const string bulletSubstring = "laser";
			BulletModel bullet = new BulletModel();
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("ParseBulletSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet, bulletSubstring };

			// Method under test
			bullet = (BulletModel)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Null(bullet.Faction);
			Assert.Null(bullet.Size);
			Assert.Equal(BulletType.laser, bullet.Type);
			Assert.Null(bullet.Grade);
			Assert.Null(bullet.Version);
		}

		[Fact]
		public void ParseBulletSubstring_GradeFound()
		{
			const string bulletSubstring = "mk2";
			BulletModel bullet = new BulletModel();
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("ParseBulletSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet, bulletSubstring };

			// Method under test
			bullet = (BulletModel)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Null(bullet.Faction);
			Assert.Null(bullet.Size);
			Assert.Null(bullet.Type);
			Assert.Equal(BulletGrade.mk2, bullet.Grade);
			Assert.Null(bullet.Version);
		}

		[Fact]
		public void ParseBulletSubstring_VersionFound()
		{
			const string bulletSubstring = "02";
			BulletModel bullet = new BulletModel();
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("ParseBulletSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet, bulletSubstring };

			// Method under test
			bullet = (BulletModel)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Null(bullet.Faction);
			Assert.Null(bullet.Size);
			Assert.Null(bullet.Type);
			Assert.Null(bullet.Grade);
			Assert.Equal(2, bullet.Version);
		}

		[Fact]
		public void ParseBulletSubstring_VersionFound_AllOthersPreviouslyPopulated()
		{
			const string bulletSubstring = "01";
			BulletModel bullet = new BulletModel { Faction = FactionType.BUC, Grade = BulletGrade.mk3, Name = "Some Bullet Name", Size = BulletSize.xl, Type = BulletType.laser };
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("ParseBulletSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { bullet, bulletSubstring };

			// Method under test
			bullet = (BulletModel)methodInfo.Invoke(bulletGetter, parameters);

			Assert.Equal(FactionType.BUC, bullet.Faction);
			Assert.Equal(BulletSize.xl, bullet.Size);
			Assert.Equal(BulletType.laser, bullet.Type);
			Assert.Equal(BulletGrade.mk3, bullet.Grade);
			Assert.Equal(1, bullet.Version);
		}
		#endregion ParseBulletSubstring

		#region ParseBulletXml
		[Fact]
		public void ParseBulletXml_PopulateAllXmlRelatedFields()
		{
			XmlDocument document = new XmlDocument();
			document.Load(@"DataAccess\TestData\ValidBulletXml.xml");
			BulletGetter bulletGetter = new BulletGetter("some folder");
			MethodInfo methodInfo = typeof(BulletGetter).GetMethod("ParseBulletPropertiesXml", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { document };

			// Method under test
			Properties bulletProperties = new Properties();
			bulletProperties = (Properties)methodInfo.Invoke(bulletGetter, parameters);

			bulletProperties.Bullet.Amount.Duration = 29;
			bulletProperties.Boost.Thrust = 2;
			bulletProperties.Boost.Attack = 10;
			bulletProperties.Boost.Release = 1;
			bulletProperties.Travel.Charge = 20;
			bulletProperties.Travel.Thrust = 31;
			bulletProperties.Travel.Attack = 75;
			bulletProperties.Travel.Release = 22.5;
			bulletProperties.Thrust.Forward = 4206;
			bulletProperties.Thrust.Reverse = 4627;
			bulletProperties.Hull.Max = 4033;
			bulletProperties.Hull.Threshold = 0.3;
		}
		#endregion ParseBulletXml
		#endregion Private Methods
	}
}
