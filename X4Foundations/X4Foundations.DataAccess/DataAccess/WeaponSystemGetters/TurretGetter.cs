using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using X4Foundations.DataAccess.Model.WeaponSystem;

namespace X4Foundations.DataAccess.DataAccess.WeaponSystemGetters
{
	public class TurretGetter
	{
		public TurretModel PopulateTurretModel(string turretFilePath, List<string> turretFileNameSubParts)
		{
			TurretModel turret = new TurretModel();
			turretFileNameSubParts.ForEach(x => turret = ParseTurretSubstring(turret, x));

			XmlDocument turretXml = new XmlDocument();
			turretXml.Load(turretFilePath);
			turret.Properties = ParseTurretPropertiesXml(turretXml);

			turret.Faction ??= FactionType.GEN;

			turret.Name = GenerateTurretName(turret).Trim();

			return turret;
		}

		/// <summary>
		/// Returns a name for an turret given its properties. Format will follow "XL ARG Combat Turret Mk2"
		/// </summary>
		/// <param name="turret">populated turret object used to derive the name</param>
		/// <returns>readable name for the turret object</returns>
		private string GenerateTurretName(TurretModel turret)
		{
			string turretName = $"{turret.Size.ToString().ToUpper()} {turret.Faction} Turret {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(turret.Type.ToString())} {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(turret.Grade.ToString())}";

			if (turret.Version > 1) { turretName += $" {turret.Version.Value:00}"; }

			return turretName;
		}

		/// <summary>
		/// Parses a substring from an turret file name, determines which property that substring represents, and assigns the corresponding enum
		/// </summary>
		/// <param name="turretObject">original turret object</param>
		/// <param name="turretSubstring">substring taken from an turret's filename e.g. arg, xl, or mk2</param>
		/// <returns>object with the new property added</returns>
		private TurretModel ParseTurretSubstring(TurretModel turretObject, string turretSubstring)
		{
			if (turretObject.Version == null && int.TryParse(turretSubstring, out int turretVersion))
			{
				turretObject.Version = turretVersion;
				return turretObject;
			}

			if (turretObject.Faction == null && Enum.TryParse(turretSubstring, true, out FactionType turretFaction))
			{
				turretObject.Faction = turretFaction;
				return turretObject;
			}

			if (turretObject.Size == null && Enum.TryParse(turretSubstring, true, out WeaponSystemSize turretSize))
			{
				turretObject.Size = turretSize;
				return turretObject;
			}

			if (turretObject.Type == null && Enum.TryParse(turretSubstring, true, out WeaponSystemType turretType))
			{
				turretObject.Type = turretType;

				return turretObject;
			}

			if (turretObject.Grade == null && Enum.TryParse(turretSubstring, true, out WeaponSystemGrade turretGrade))
			{
				turretObject.Grade = turretGrade;
				return turretObject;
			}

			if (turretObject.Class == null && Enum.TryParse(turretSubstring, true, out WeaponSystemClass turretClass))
			{
				turretObject.Class = turretClass;
				return turretObject;
			}

			throw new Exception($"Failed to parse turret substring \"{turretSubstring}\"");
		}

		/// <summary>
		/// Populates an turret properties object from a given xml document
		/// </summary>
		/// <param name="xmlDocument">an turret macro xml document</param>
		/// <returns>populated turret properties object</returns>
		private Properties ParseTurretPropertiesXml(XmlDocument xmlDocument)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Properties));
			using XmlReader reader = new XmlNodeReader(xmlDocument.SelectNodes("macros//properties")[0]);

			Properties turretProperties = (Properties)xmlSerializer.Deserialize(reader);

			return turretProperties;
		}
	}
}
