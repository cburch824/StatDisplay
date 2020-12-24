using System;
using System.Reflection;
using System.Xml;
using X4Foundations.DataAccess.TurretSystemGetters;
using X4Foundations.Model.WeaponSystem;
using Xunit;

namespace X4Foundations.Test.DataAccess.WeaponSystemGetters
{
	public class TurretGetterTests
	{
		#region Private Methods
		#region GenerateTurretName
		[Fact]
		public void GenerateTurretName_WeaponHasNoVersion()
		{
			TurretModel turret = new TurretModel { Faction = FactionType.BUC, Grade = WeaponSystemGrade.mk1, Name = "Some Weapon Name", Size = WeaponSystemSize.s, Class = WeaponSystemClass.turret, Type = WeaponSystemType.laser };
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("GenerateTurretName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret };

			// Method under test
			string turretName = (string)methodInfo.Invoke(turretGetter, parameters);

			Assert.Equal("S BUC Turret Laser Mk1", turretName);
		}

		[Fact]
		public void GenerateTurretName_WeaponHasVersion01()
		{
			TurretModel turret = new TurretModel { Faction = FactionType.BUC, Grade = WeaponSystemGrade.mk1, Name = "Some Weapon Name", Size = WeaponSystemSize.s, Type = WeaponSystemType.laser, Class = WeaponSystemClass.turret, Version = 1 };
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("GenerateTurretName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret };

			// Method under test
			string turretName = (string)methodInfo.Invoke(turretGetter, parameters);

			Assert.Equal("S BUC Turret Laser Mk1", turretName);
		}

		[Fact]
		public void GenerateTurretName_WeaponHasVersion02()
		{
			TurretModel turret = new TurretModel { Faction = FactionType.BUC, Grade = WeaponSystemGrade.mk1, Name = "Some Weapon Name", Size = WeaponSystemSize.s, Type = WeaponSystemType.laser, Class = WeaponSystemClass.turret, Version = 2 };
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("GenerateTurretName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret };

			// Method under test
			string turretName = (string)methodInfo.Invoke(turretGetter, parameters);

			Assert.Equal("S BUC Turret Laser Mk1 02", turretName);
		}
		#endregion GenerateTurretName

		#region ParseTurretSubstring
		[Fact]
		public void ParseTurretSubstring_AllParsingFails()
		{
			const string weaponSubstring = "invalid string to parse";
			TurretModel turret = new TurretModel();
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("ParseTurretSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret, weaponSubstring };


			// Method under test
			void Action() => turret = (TurretModel)methodInfo.Invoke(turretGetter, parameters);

			Exception exception = Assert.Throws<TargetInvocationException>(Action);
			Assert.Equal($"Failed to parse turret substring \"{weaponSubstring}\"", exception.InnerException.Message);

			Assert.Null(turret.Faction);
			Assert.Null(turret.Size);
			Assert.Null(turret.Type);
			Assert.Null(turret.Grade);
			Assert.Null(turret.Version);
		}

		[Fact]
		public void ParseTurretSubstring_FactionFound()
		{
			const string weaponSubstring = "arg";
			TurretModel turret = new TurretModel();
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("ParseTurretSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret, weaponSubstring };

			// Method under test
			turret = (TurretModel)methodInfo.Invoke(turretGetter, parameters);

			Assert.Equal(FactionType.ARG, turret.Faction);
			Assert.Null(turret.Size);
			Assert.Null(turret.Type);
			Assert.Null(turret.Grade);
			Assert.Null(turret.Version);
		}

		[Fact]
		public void ParseTurretSubstring_SizeFound()
		{
			const string weaponSubstring = "s";
			TurretModel turret = new TurretModel();
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("ParseTurretSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret, weaponSubstring };

			// Method under test
			turret = (TurretModel)methodInfo.Invoke(turretGetter, parameters);

			Assert.Null(turret.Faction);
			Assert.Equal(WeaponSystemSize.s, turret.Size);
			Assert.Null(turret.Type);
			Assert.Null(turret.Grade);
			Assert.Null(turret.Version);
		}

		[Fact]
		public void ParseTurretSubstring_TypeFound()
		{
			const string weaponSubstring = "laser";
			TurretModel turret = new TurretModel();
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("ParseTurretSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret, weaponSubstring };

			// Method under test
			turret = (TurretModel)methodInfo.Invoke(turretGetter, parameters);

			Assert.Null(turret.Faction);
			Assert.Null(turret.Size);
			Assert.Equal(WeaponSystemType.laser, turret.Type);
			Assert.Null(turret.Grade);
			Assert.Null(turret.Version);
		}

		[Fact]
		public void ParseTurretSubstring_GradeFound()
		{
			const string weaponSubstring = "mk2";
			TurretModel turret = new TurretModel();
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("ParseTurretSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret, weaponSubstring };

			// Method under test
			turret = (TurretModel)methodInfo.Invoke(turretGetter, parameters);

			Assert.Null(turret.Faction);
			Assert.Null(turret.Size);
			Assert.Null(turret.Type);
			Assert.Equal(WeaponSystemGrade.mk2, turret.Grade);
			Assert.Null(turret.Version);
		}

		[Fact]
		public void ParseTurretSubstring_VersionFound()
		{
			const string weaponSubstring = "02";
			TurretModel turret = new TurretModel();
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("ParseTurretSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret, weaponSubstring };

			// Method under test
			turret = (TurretModel)methodInfo.Invoke(turretGetter, parameters);

			Assert.Null(turret.Faction);
			Assert.Null(turret.Size);
			Assert.Null(turret.Type);
			Assert.Null(turret.Grade);
			Assert.Equal(2, turret.Version);
		}

		[Fact]
		public void ParseTurretSubstring_VersionFound_AllOthersPreviouslyPopulated()
		{
			const string weaponSubstring = "01";
			TurretGetter turretGetter = new TurretGetter();
			TurretModel turret = new TurretModel { Faction = FactionType.BUC, Grade = WeaponSystemGrade.mk3, Name = "Some Weapon Name", Size = WeaponSystemSize.xl, Type = WeaponSystemType.laser };
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("ParseTurretSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { turret, weaponSubstring };

			// Method under test
			turret = (TurretModel)methodInfo.Invoke(turretGetter, parameters);

			Assert.Equal(FactionType.BUC, turret.Faction);
			Assert.Equal(WeaponSystemSize.xl, turret.Size);
			Assert.Equal(WeaponSystemType.laser, turret.Type);
			Assert.Equal(WeaponSystemGrade.mk3, turret.Grade);
			Assert.Equal(1, turret.Version);
		}
		#endregion ParseTurretSubstring

		#region ParseWeaponXml
		[Fact]
		public void ParseTurretXml_PopulateAllXmlRelatedFields()
		{
			XmlDocument document = new XmlDocument();
			document.Load(@"DataAccess\TestData\ValidTurretXml.xml");
			TurretGetter turretGetter = new TurretGetter();
			MethodInfo methodInfo = typeof(TurretGetter).GetMethod("ParseTurretPropertiesXml", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { document };

			// Method under test
			Properties weaponProperties = new Properties();
			weaponProperties = (Properties)methodInfo.Invoke(turretGetter, parameters);

			Assert.Equal("bullet_gen_turret_m_laser_01_mk1_macro", weaponProperties.Bullet.Class);
			Assert.Equal(210, weaponProperties.RotationSpeed.Max);
			Assert.Equal(1, weaponProperties.Reload.Rate);
			Assert.Equal(1, weaponProperties.Reload.Time);
			Assert.Equal(.2, weaponProperties.Hull.Threshold);
			Assert.Equal(1, weaponProperties.Hull.Integrated);
		}
		#endregion ParseWeaponXml
		#endregion Private Methods
	}
}
