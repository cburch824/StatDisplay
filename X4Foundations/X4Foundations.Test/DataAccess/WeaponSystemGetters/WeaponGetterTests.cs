using System;
using System.Reflection;
using System.Xml;
using X4Foundations.DataAccess;
using X4Foundations.DataAccess.DataAccess.WeaponSystemGetters;
using X4Foundations.DataAccess.Model.WeaponSystem;
using Xunit;

namespace X4Foundations.Test.DataAccess.DataAccess.WeaponSystemGetters
{
	public class WeaponGetterTests
	{
		#region Private Methods
		#region GenerateWeaponName
		[Fact]
		public void GenerateWeaponName_WeaponHasNoVersion()
		{
			WeaponModel weapon = new WeaponModel { Faction = FactionType.BUC, Grade = WeaponSystemGrade.mk1, Name = "Some Weapon Name", Size = WeaponSystemSize.s, Type = WeaponSystemType.laser };
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("GenerateWeaponName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon };

			// Method under test
			string weaponName = (string)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Equal("S BUC Laser Weapon Mk1", weaponName);
		}

		[Fact]
		public void GenerateWeaponName_WeaponHasVersion01()
		{
			WeaponModel weapon = new WeaponModel { Faction = FactionType.BUC, Grade = WeaponSystemGrade.mk1, Name = "Some Weapon Name", Size = WeaponSystemSize.s, Type = WeaponSystemType.laser, Version = 1 };
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("GenerateWeaponName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon };

			// Method under test
			string weaponName = (string)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Equal("S BUC Laser Weapon Mk1", weaponName);
		}

		[Fact]
		public void GenerateWeaponName_WeaponHasVersion02()
		{
			WeaponModel weapon = new WeaponModel { Faction = FactionType.BUC, Grade = WeaponSystemGrade.mk1, Name = "Some Weapon Name", Size = WeaponSystemSize.s, Type = WeaponSystemType.laser, Version = 2 };
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("GenerateWeaponName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon };

			// Method under test
			string weaponName = (string)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Equal("S BUC Laser Weapon Mk1 02", weaponName);
		}
		#endregion GenerateWeaponName

		#region ParseWeaponSubstring
		[Fact]
		public void ParseWeaponSubstring_AllParsingFails()
		{
			const string weaponSubstring = "invalid string to parse";
			WeaponModel weapon = new WeaponModel();
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("ParseWeaponSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon, weaponSubstring };


			// Method under test
			void Action() => weapon = (WeaponModel)methodInfo.Invoke(weaponGetter, parameters);

			Exception exception = Assert.Throws<TargetInvocationException>(Action);
			Assert.Equal($"Failed to parse weapon substring \"{weaponSubstring}\"", exception.InnerException.Message);

			Assert.Null(weapon.Faction);
			Assert.Null(weapon.Size);
			Assert.Null(weapon.Type);
			Assert.Null(weapon.Grade);
			Assert.Null(weapon.Version);
		}

		[Fact]
		public void ParseWeaponSubstring_FactionFound()
		{
			const string weaponSubstring = "arg";
			WeaponModel weapon = new WeaponModel();
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("ParseWeaponSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon, weaponSubstring };

			// Method under test
			weapon = (WeaponModel)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Equal(FactionType.ARG, weapon.Faction);
			Assert.Null(weapon.Size);
			Assert.Null(weapon.Type);
			Assert.Null(weapon.Grade);
			Assert.Null(weapon.Version);
		}

		[Fact]
		public void ParseWeaponSubstring_SizeFound()
		{
			const string weaponSubstring = "s";
			WeaponModel weapon = new WeaponModel();
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("ParseWeaponSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon, weaponSubstring };

			// Method under test
			weapon = (WeaponModel)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Null(weapon.Faction);
			Assert.Equal(WeaponSystemSize.s, weapon.Size);
			Assert.Null(weapon.Type);
			Assert.Null(weapon.Grade);
			Assert.Null(weapon.Version);
		}

		[Fact]
		public void ParseWeaponSubstring_TypeFound()
		{
			const string weaponSubstring = "laser";
			WeaponModel weapon = new WeaponModel();
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("ParseWeaponSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon, weaponSubstring };

			// Method under test
			weapon = (WeaponModel)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Null(weapon.Faction);
			Assert.Null(weapon.Size);
			Assert.Equal(WeaponSystemType.laser, weapon.Type);
			Assert.Null(weapon.Grade);
			Assert.Null(weapon.Version);
		}

		[Fact]
		public void ParseWeaponSubstring_GradeFound()
		{
			const string weaponSubstring = "mk2";
			WeaponModel weapon = new WeaponModel();
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("ParseWeaponSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon, weaponSubstring };

			// Method under test
			weapon = (WeaponModel)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Null(weapon.Faction);
			Assert.Null(weapon.Size);
			Assert.Null(weapon.Type);
			Assert.Equal(WeaponSystemGrade.mk2, weapon.Grade);
			Assert.Null(weapon.Version);
		}

		[Fact]
		public void ParseWeaponSubstring_VersionFound()
		{
			const string weaponSubstring = "02";
			WeaponModel weapon = new WeaponModel();
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("ParseWeaponSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon, weaponSubstring };

			// Method under test
			weapon = (WeaponModel)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Null(weapon.Faction);
			Assert.Null(weapon.Size);
			Assert.Null(weapon.Type);
			Assert.Null(weapon.Grade);
			Assert.Equal(2, weapon.Version);
		}

		[Fact]
		public void ParseWeaponSubstring_VersionFound_AllOthersPreviouslyPopulated()
		{
			const string weaponSubstring = "01";
			WeaponGetter weaponGetter = new WeaponGetter();
			WeaponModel weapon = new WeaponModel { Faction = FactionType.BUC, Grade = WeaponSystemGrade.mk3, Name = "Some Weapon Name", Size = WeaponSystemSize.xl, Type = WeaponSystemType.laser };
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("ParseWeaponSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { weapon, weaponSubstring };

			// Method under test
			weapon = (WeaponModel)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Equal(FactionType.BUC, weapon.Faction);
			Assert.Equal(WeaponSystemSize.xl, weapon.Size);
			Assert.Equal(WeaponSystemType.laser, weapon.Type);
			Assert.Equal(WeaponSystemGrade.mk3, weapon.Grade);
			Assert.Equal(1, weapon.Version);
		}
		#endregion ParseWeaponSubstring

		#region ParseWeaponXml
		[Fact]
		public void ParseWeaponXml_PopulateAllXmlRelatedFields()
		{
			XmlDocument document = new XmlDocument();
			document.Load(@"DataAccess\TestData\ValidWeaponXml.xml");
			WeaponGetter weaponGetter = new WeaponGetter();
			MethodInfo methodInfo = typeof(WeaponGetter).GetMethod("ParseWeaponPropertiesXml", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { document };

			// Method under test
			Properties weaponProperties = new Properties();
			weaponProperties = (Properties)methodInfo.Invoke(weaponGetter, parameters);

			Assert.Equal("bullet_gen_s_plasma_01_mk1_macro", weaponProperties.Bullet.Class);
			Assert.Equal(10000, weaponProperties.Heat.Overheat);
			Assert.Equal(1.13, weaponProperties.Heat.CoolDelay);
			Assert.Equal(2000, weaponProperties.Heat.CoolRate);
			Assert.Equal(2000, weaponProperties.Heat.Reenable);
			Assert.Equal(47.4, weaponProperties.RotationSpeed.Max);
			Assert.Equal(23.7, weaponProperties.RotationAcceleration.Max);
			Assert.Equal(500, weaponProperties.Hull.Max);
			Assert.Equal(0, weaponProperties.Hull.Hittable);
		}
		#endregion ParseWeaponXml
		#endregion Private Methods
	}
}
