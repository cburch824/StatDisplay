using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using X4Foundations.DataAccess;
using X4Foundations.Model.Engine;
using Xunit;

namespace X4Foundations.Test.DataAccess
{
	public class EngineGetterTests
	{
		#region Public Methods
		#region PopulateEngine
		[Fact]
		public void PopulateEngine_AllFieldsAndPropertiesPopulated()
		{
			string engineFilePath = $@"{Environment.CurrentDirectory}\DataAccess\TestData\engine_arg_m_allround_01_mk1_macro.xml";

			EngineGetter engineGetter = new EngineGetter("some folder");
			EngineModel engine = engineGetter.PopulateEngine(engineFilePath);

			Assert.Equal(FactionType.ARG, engine.Faction);
			Assert.Equal(EngineSize.m, engine.Size);
			Assert.Equal(EngineType.allround, engine.Type);
			Assert.Equal(1, engine.Version);
			Assert.Equal(EngineGrade.mk1, engine.Grade);

			Assert.Equal(7, engine.Properties.Boost.Duration);
			Assert.Equal(8, engine.Properties.Boost.Thrust);
			Assert.Equal(0.25, engine.Properties.Boost.Attack);
			Assert.Equal(1, engine.Properties.Boost.Release);

			Assert.Equal(1, engine.Properties.Travel.Charge);
			Assert.Equal(9, engine.Properties.Travel.Thrust);
			Assert.Equal(30, engine.Properties.Travel.Attack);
			Assert.Equal(20, engine.Properties.Travel.Release);

			Assert.Equal(1002, engine.Properties.Thrust.Forward);
			Assert.Equal(952, engine.Properties.Thrust.Reverse);

			Assert.Equal(1, engine.Properties.Hull.Integrated);

			Assert.Equal("M ARG Allround Engine Mk1", engine.Name);
		}
		#endregion PopulateEngine
		#endregion Public Methods

		#region Private Methods
		#region RemoveMultitermEngineFileNameParameters
		[Fact]
		public void RemoveMultitermEngineFileNameParameters_HasNoMultitermParameters()
		{
			const string engineFileName = "engine_arg_m_travel_01_mk3_macro.xml";
			List<string> engineFileNameSubParts = engineFileName.Split('_').ToList();
			engineFileNameSubParts.Remove("engine");
			engineFileNameSubParts.Remove("macro.xml");
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("RemoveMultitermEngineFileNameParameters", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engineFileNameSubParts };

			// Method under test
			List<string> engineFileNameSubPartsAfterMethodCall = new List<string>();
			engineFileNameSubPartsAfterMethodCall = (List<string>) methodInfo.Invoke(engineGetter, parameters);

			Assert.Equal(engineFileNameSubParts.Count, engineFileNameSubPartsAfterMethodCall.Count);
			for (int i = 0; i < engineFileNameSubParts.Count; i++)
			{
				Assert.Equal(engineFileNameSubParts[i], engineFileNameSubPartsAfterMethodCall[i]);
			}
		}

		[Fact]
		public void RemoveMultitermEngineFileNameParameters_HasMultitermParameters_LimpetMine()
		{
			const string engineFileName = "engine_limpet_mine_01_mk1_macro.xml";
			List<string> engineFileNameSubParts = engineFileName.Split('_').ToList();
			engineFileNameSubParts.Remove("engine");
			engineFileNameSubParts.Remove("macro.xml");
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("RemoveMultitermEngineFileNameParameters", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engineFileNameSubParts };

			// Method under test
			List<string> engineFileNameSubPartsAfterMethodCall = new List<string>();
			engineFileNameSubPartsAfterMethodCall = (List<string>)methodInfo.Invoke(engineGetter, parameters);

			Assert.Equal(engineFileNameSubParts.Count, engineFileNameSubPartsAfterMethodCall.Count + 1);
			Assert.Equal("LimpetMine", engineFileNameSubPartsAfterMethodCall[0]);
			Assert.Equal("01", engineFileNameSubPartsAfterMethodCall[1]);
			Assert.Equal("mk1", engineFileNameSubPartsAfterMethodCall[2]);
		}

		[Fact]
		public void RemoveMultitermEngineFileNameParameters_HasMultitermParameters_MissileDumbfire()
		{
			const string engineFileName = "engine_missile_dumbfire_mk1_macro.xml";
			List<string> engineFileNameSubParts = engineFileName.Split('_').ToList();
			engineFileNameSubParts.Remove("engine");
			engineFileNameSubParts.Remove("macro.xml");
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("RemoveMultitermEngineFileNameParameters", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engineFileNameSubParts };

			// Method under test
			List<string> engineFileNameSubPartsAfterMethodCall = new List<string>();
			engineFileNameSubPartsAfterMethodCall = (List<string>)methodInfo.Invoke(engineGetter, parameters);

			Assert.Equal(engineFileNameSubParts.Count, engineFileNameSubPartsAfterMethodCall.Count + 1);
			Assert.Equal("MissileDumbfire", engineFileNameSubPartsAfterMethodCall[0]);
			Assert.Equal("mk1", engineFileNameSubPartsAfterMethodCall[1]);
		}
		#endregion RemoveMultitermEngineFileNameParameters

		#region GenerateEngineName
		[Fact]
		public void GenerateEngineName_EngineHasNoVersion()
		{
			EngineModel engine = new EngineModel { Faction = FactionType.BUC, Grade = EngineGrade.mk3, Name = "Some Engine Name", Size = EngineSize.xl, Type = EngineType.combat };
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("GenerateEngineName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine };

			// Method under test
			string engineName = (string)methodInfo.Invoke(engineGetter, parameters);

			Assert.Equal("XL BUC Combat Engine Mk3", engineName);
		}

		[Fact]
		public void GenerateEngineName_EngineHasVersion01()
		{
			EngineModel engine = new EngineModel { Faction = FactionType.BUC, Grade = EngineGrade.mk3, Name = "Some Engine Name", Size = EngineSize.xl, Type = EngineType.combat, Version = 1};
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("GenerateEngineName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine };

			// Method under test
			string engineName = (string)methodInfo.Invoke(engineGetter, parameters);

			Assert.Equal("XL BUC Combat Engine Mk3", engineName);
		}

		[Fact]
		public void GenerateEngineName_EngineHasVersion02()
		{
			EngineModel engine = new EngineModel { Faction = FactionType.BUC, Grade = EngineGrade.mk3, Name = "Some Engine Name", Size = EngineSize.xl, Type = EngineType.combat, Version = 2};
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("GenerateEngineName", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine };

			// Method under test
			string engineName = (string)methodInfo.Invoke(engineGetter, parameters);

			Assert.Equal("XL BUC Combat Engine Mk3 02", engineName);
		}
		#endregion GenerateEngineName

		#region ParseEngineSubstring
		[Fact]
		public void ParseEngineSubstring_AllParsingFails()
		{
			const string engineSubstring = "invalid string to parse";
			EngineModel engine = new EngineModel();
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("ParseEngineSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine, engineSubstring };
			

			// Method under test
			void Action() => engine = (EngineModel) methodInfo.Invoke(engineGetter, parameters);

			Exception exception = Assert.Throws<TargetInvocationException>(Action);
			Assert.Equal($"Failed to parse engine substring \"{engineSubstring}\"", exception.InnerException.Message);

			Assert.Null(engine.Faction);
			Assert.Null(engine.Size);
			Assert.Null(engine.Type);
			Assert.Null(engine.Grade);
			Assert.Null(engine.Version);
		}

		[Fact]
		public void ParseEngineSubstring_FactionFound()
		{
			const string engineSubstring = "arg";
			EngineModel engine = new EngineModel();
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("ParseEngineSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = {engine, engineSubstring};

			// Method under test
			engine = (EngineModel)methodInfo.Invoke(engineGetter, parameters);

			Assert.Equal(FactionType.ARG, engine.Faction);
			Assert.Null(engine.Size);
			Assert.Null(engine.Type);
			Assert.Null(engine.Grade);
			Assert.Null(engine.Version);
		}

		[Fact]
		public void ParseEngineSubstring_SizeFound()
		{
			const string engineSubstring = "s";
			EngineModel engine = new EngineModel();
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("ParseEngineSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine, engineSubstring };

			// Method under test
			engine = (EngineModel)methodInfo.Invoke(engineGetter, parameters);

			Assert.Null(engine.Faction);
			Assert.Equal(EngineSize.s, engine.Size);
			Assert.Null(engine.Type);
			Assert.Null(engine.Grade);
			Assert.Null(engine.Version);
		}

		[Fact]
		public void ParseEngineSubstring_TypeFound()
		{
			const string engineSubstring = "combat";
			EngineModel engine = new EngineModel();
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("ParseEngineSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine, engineSubstring };

			// Method under test
			engine = (EngineModel)methodInfo.Invoke(engineGetter, parameters);

			Assert.Null(engine.Faction);
			Assert.Null(engine.Size);
			Assert.Equal(EngineType.combat, engine.Type);
			Assert.Null(engine.Grade);
			Assert.Null(engine.Version);
		}

		[Fact]
		public void ParseEngineSubstring_GradeFound()
		{
			const string engineSubstring = "mk2";
			EngineModel engine = new EngineModel();
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("ParseEngineSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine, engineSubstring };

			// Method under test
			engine = (EngineModel)methodInfo.Invoke(engineGetter, parameters);

			Assert.Null(engine.Faction);
			Assert.Null(engine.Size);
			Assert.Null(engine.Type);
			Assert.Equal(EngineGrade.mk2, engine.Grade);
			Assert.Null(engine.Version);
		}

		[Fact]
		public void ParseEngineSubstring_VersionFound()
		{
			const string engineSubstring = "02";
			EngineModel engine = new EngineModel();
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("ParseEngineSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine, engineSubstring };

			// Method under test
			engine = (EngineModel)methodInfo.Invoke(engineGetter, parameters);

			Assert.Null(engine.Faction);
			Assert.Null(engine.Size);
			Assert.Null(engine.Type);
			Assert.Null(engine.Grade);
			Assert.Equal(2, engine.Version);
		}

		[Fact]
		public void ParseEngineSubstring_VersionFound_AllOthersPreviouslyPopulated()
		{
			const string engineSubstring = "01";
			EngineModel engine = new EngineModel {Faction = FactionType.BUC, Grade = EngineGrade.mk3, Name = "Some Engine Name", Size = EngineSize.xl, Type = EngineType.combat};
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("ParseEngineSubstring", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { engine, engineSubstring };

			// Method under test
			engine = (EngineModel) methodInfo.Invoke(engineGetter, parameters);

			Assert.Equal(FactionType.BUC, engine.Faction);
			Assert.Equal(EngineSize.xl, engine.Size);
			Assert.Equal(EngineType.combat, engine.Type);
			Assert.Equal(EngineGrade.mk3, engine.Grade);
			Assert.Equal(1, engine.Version);
		}
		#endregion ParseEngineSubstring

		#region ParseEngineXml
		[Fact]
		public void ParseEngineXml_PopulateAllXmlRelatedFields()
		{
			XmlDocument document = new XmlDocument();
			document.Load(@"DataAccess\TestData\ValidEngineXml.xml");
			EngineGetter engineGetter = new EngineGetter("some folder");
			MethodInfo methodInfo = typeof(EngineGetter).GetMethod("ParseEnginePropertiesXml", BindingFlags.NonPublic | BindingFlags.Instance);
			object[] parameters = { document };

			// Method under test
			Properties engineProperties = new Properties();
			engineProperties = (Properties) methodInfo.Invoke(engineGetter, parameters);

			engineProperties.Boost.Duration = 29;
			engineProperties.Boost.Thrust = 2;
			engineProperties.Boost.Attack = 10;
			engineProperties.Boost.Release = 1;
			engineProperties.Travel.Charge = 20;
			engineProperties.Travel.Thrust = 31;
			engineProperties.Travel.Attack = 75;
			engineProperties.Travel.Release = 22.5;
			engineProperties.Thrust.Forward = 4206;
			engineProperties.Thrust.Reverse = 4627;
			engineProperties.Hull.Max = 4033;
			engineProperties.Hull.Threshold = 0.3;
		}
		#endregion ParseEngineXml
		#endregion Private Methods
	}
}
