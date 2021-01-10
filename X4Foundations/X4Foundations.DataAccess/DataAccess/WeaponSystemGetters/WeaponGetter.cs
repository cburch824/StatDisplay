using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using X4Foundations.DataAccess.Model.WeaponSystem;

namespace X4Foundations.DataAccess.DataAccess.WeaponSystemGetters
{
	public class WeaponGetter
	{
		public WeaponModel PopulateWeaponModel(string weaponFilePath, List<string> weaponFileNameSubParts)
		{
			WeaponModel weapon = new WeaponModel();
			weaponFileNameSubParts.ForEach(x => weapon = ParseWeaponSubstring(weapon, x));

			XmlDocument weaponXml = new XmlDocument();
			weaponXml.Load(weaponFilePath);
			weapon.Properties = ParseWeaponPropertiesXml(weaponXml);

			weapon.Faction ??= FactionType.GEN;

			weapon.Name = GenerateWeaponName(weapon).Trim();

			return weapon;
		}

		/// <summary>
		/// Returns a name for an weapon given its properties. Format will follow "XL ARG Combat Weapon Mk2"
		/// </summary>
		/// <param name="weapon">populated weapon object used to derive the name</param>
		/// <returns>readable name for the weapon object</returns>
		private string GenerateWeaponName(WeaponModel weapon)
		{
			string weaponName = $"{weapon.Size.ToString().ToUpper()} {weapon.Faction} {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(weapon.Type.ToString())} Weapon {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(weapon.Grade.ToString())}";

			if (weapon.Version > 1) { weaponName += $" {weapon.Version.Value:00}"; }
			if (weapon.VersionLetter != null) { weaponName += $" {weapon.VersionLetter.ToString().ToUpper()}"; }


			return weaponName;
		}

		/// <summary>
		/// Parses a substring from an weapon file name, determines which property that substring represents, and assigns the corresponding enum
		/// </summary>
		/// <param name="weaponObject">original weapon object</param>
		/// <param name="weaponSubstring">substring taken from an weapon's filename e.g. arg, xl, or mk2</param>
		/// <returns>object with the new property added</returns>
		private WeaponModel ParseWeaponSubstring(WeaponModel weaponObject, string weaponSubstring)
		{
			if (weaponObject.Version == null && int.TryParse(weaponSubstring, out int weaponVersion))
			{
				weaponObject.Version = weaponVersion;
				return weaponObject;
			}

			if (weaponObject.Class == null && Enum.TryParse(weaponSubstring, true, out WeaponSystemClass weaponsClass))
			{
				weaponObject.Class = weaponsClass;
				return weaponObject;
			}

			if (weaponObject.Faction == null && Enum.TryParse(weaponSubstring, true, out FactionType weaponFaction))
			{
				weaponObject.Faction = weaponFaction;
				return weaponObject;
			}

			if (weaponObject.Size == null && Enum.TryParse(weaponSubstring, true, out WeaponSystemSize weaponSize))
			{
				weaponObject.Size = weaponSize;
				return weaponObject;
			}

			if (weaponObject.Type == null && Enum.TryParse(weaponSubstring, true, out WeaponSystemType weaponType))
			{
				weaponObject.Type = weaponType;

				return weaponObject;
			}

			if (weaponObject.Grade == null && Enum.TryParse(weaponSubstring, true, out WeaponSystemGrade weaponGrade))
			{
				weaponObject.Grade = weaponGrade;
				return weaponObject;
			}

			if (weaponObject.VersionLetter == null && char.TryParse(weaponSubstring, out char weaponVersionLetter))
			{
				weaponObject.VersionLetter = weaponVersionLetter;
				return weaponObject;
			}

			throw new Exception($"Failed to parse weapon substring \"{weaponSubstring}\"");
		}

		/// <summary>
		/// Populates an weapon properties object from a given xml document
		/// </summary>
		/// <param name="xmlDocument">an weapon macro xml document</param>
		/// <returns>populated weapon properties object</returns>
		private Properties ParseWeaponPropertiesXml(XmlDocument xmlDocument)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Properties));
			using XmlReader reader = new XmlNodeReader(xmlDocument.SelectNodes("macros//properties")[0]);

			Properties weaponProperties = (Properties)xmlSerializer.Deserialize(reader);

			return weaponProperties;
		}
	}
}
