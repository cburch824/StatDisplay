using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using X4Foundations.Model.Engine;

namespace X4Foundations.DataAccess
{
	public class EngineGetter
	{
		private string _engineFolder;
		private List<string> EngineFilePaths => Directory.EnumerateFiles(_engineFolder).ToList();

		public List<EngineModel> Engines { get; set; }
		public int NumberOfEngineFiles => EngineFilePaths.Count;

		public EngineGetter(string engineFolder)
		{
			_engineFolder = engineFolder;
		}

		public List<EngineModel> PopulateEngines()
		{
			List<EngineModel> engines = new List<EngineModel>();

			foreach (string engineFile in EngineFilePaths)
			{
				if (Path.GetFileName(engineFile).StartsWith("engine"))
					engines.Add(PopulateEngine(engineFile));
			}

			return engines;
		}

		/// <summary>
		/// Populates an engine object for a given engine file path
		/// </summary>
		/// <param name="engineFilePath"></param>
		/// <returns></returns>
		public EngineModel PopulateEngine(string engineFilePath)
		{
			string engineFileName = Path.GetFileName(engineFilePath);
			List<string> engineFileNameSubParts = engineFileName.Split('_').ToList();
			engineFileNameSubParts.Remove("engine");
			engineFileNameSubParts.Remove("macro.xml");

			EngineModel engine = new EngineModel();
			engineFileNameSubParts = RemoveMultitermEngineFileNameParameters(engineFileNameSubParts);
			engineFileNameSubParts.ForEach(x => engine = ParseEngineSubstring(engine, x));

			XmlDocument engineXml = new XmlDocument();
			engineXml.Load(engineFilePath);
			engine.Properties = ParseEnginePropertiesXml(engineXml);

			engine.Name = GenerateEngineName(engine);

			return engine;
		}

		/// <summary>
		/// Replaces multi-term parameters in engine file names e.g. replaces "limpet_mine"'s "limpet" and "mine" strings with a single "LimpetMine" string
		/// </summary>
		/// <param name="engineFileNameSubParts">original engineFileNameSubParts</param>
		/// <returns>engineFileNameSubParts with only single term parameters</returns>
		private List<string> RemoveMultitermEngineFileNameParameters(List<string> engineFileNameSubParts)
		{
			if (engineFileNameSubParts.Contains("limpet") && engineFileNameSubParts.Contains("mine"))
			{
				engineFileNameSubParts = engineFileNameSubParts.Select(x => x == "limpet" ? "LimpetMine" : x).ToList();
				if(!engineFileNameSubParts.Remove("mine")) {throw new Exception("Failed to remove subpart \"mine\" even though limpet was found in the list");}
			}
			if (engineFileNameSubParts.Contains("special") && engineFileNameSubParts.Contains("mine"))
			{
				engineFileNameSubParts = engineFileNameSubParts.Select(x => x == "special" ? "SpecialMine" : x).ToList();
				if (!engineFileNameSubParts.Remove("mine")) { throw new Exception("Failed to remove subpart \"mine\" even though limpet was found in the list"); }
			}
			else if (engineFileNameSubParts.Contains("dumbfire") && engineFileNameSubParts.Contains("missile"))
			{
				engineFileNameSubParts = engineFileNameSubParts.Select(x => x == "missile" ? "MissileDumbfire" : x).ToList();
				if(!engineFileNameSubParts.Remove("dumbfire")) { throw new Exception("Failed to remove subpart \"dumbfire\" even though dumbfire was found in the list"); }
			}
			else if (engineFileNameSubParts.Contains("swarm") && engineFileNameSubParts.Contains("missile"))
			{
				engineFileNameSubParts = engineFileNameSubParts.Select(x => x == "missile" ? "MissileSwarm" : x).ToList();
				if(!engineFileNameSubParts.Remove("swarm")) { throw new Exception("Failed to remove subpart \"swarm\" even though swarm was found in the list"); }
			}
			else if (engineFileNameSubParts.Contains("guided") && engineFileNameSubParts.Contains("missile"))
			{
				engineFileNameSubParts = engineFileNameSubParts.Select(x => x == "missile" ? "MissileGuided" : x).ToList();
				if(!engineFileNameSubParts.Remove("guided")) { throw new Exception("Failed to remove subpart \"guided\" even though guided was found in the list"); }
			}

			return engineFileNameSubParts;
		}

		/// <summary>
		/// Returns a name for an engine given its properties. Format will follow "XL ARG Combat Engine Mk2"
		/// </summary>
		/// <param name="engine">populated engine object used to derive the name</param>
		/// <returns>readable name for the engine object</returns>
		private string GenerateEngineName(EngineModel engine)
		{
			string engineName = $"{engine.Size.ToString().ToUpper()} {engine.Faction} {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(engine.Type.ToString())} Engine {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(engine.Grade.ToString())}";
			
			if (engine.Version > 1) {engineName += $" {engine.Version.Value:00}";}

			return engineName;
		}

		/// <summary>
		/// Parses a substring from an engine file name, determines which property that substring represents, and assigns the corresponding enum
		/// </summary>
		/// <param name="engineObject">original engine object</param>
		/// <param name="engineSubstring">substring taken from an engine's filename e.g. arg, xl, or mk2</param>
		/// <returns>object with the new property added</returns>
		private EngineModel ParseEngineSubstring(EngineModel engineObject, string engineSubstring)
		{
			if (engineObject.Version == null && int.TryParse(engineSubstring, out int engineVersion))
			{
				engineObject.Version = engineVersion;
				return engineObject;
			}

			if (engineObject.Faction == null && Enum.TryParse(engineSubstring, true, out FactionType engineFaction))
			{
				engineObject.Faction = engineFaction;
				return engineObject;
			}

			if (engineObject.Size == null && Enum.TryParse(engineSubstring, true, out EngineSize engineSize))
			{
				engineObject.Size = engineSize;
				return engineObject;
			}

			if (engineObject.Type == null && Enum.TryParse(engineSubstring, true, out EngineType engineType))
			{
				engineObject.Type = engineType;
				return engineObject;
			}

			if (engineObject.Grade == null && Enum.TryParse(engineSubstring, true, out EngineGrade engineGrade))
			{
				engineObject.Grade = engineGrade;
				return engineObject;
			}

			throw new Exception($"Failed to parse engine substring \"{engineSubstring}\"");
		}

		/// <summary>
		/// Populates an engine properties object from a given xml document
		/// </summary>
		/// <param name="xmlDocument">an engine macro xml document</param>
		/// <returns>populated engine properties object</returns>
		private Properties ParseEnginePropertiesXml(XmlDocument xmlDocument)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Properties));
			using XmlReader reader = new XmlNodeReader(xmlDocument.SelectNodes("macros//properties")[0]);

			Properties engineProperties = (Properties) xmlSerializer.Deserialize(reader);

			return engineProperties;
		}
	}
}
