using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using X4Foundations.Model.Bullet;

namespace X4Foundations.DataAccess
{
	public class BulletGetter
	{
		private string _bulletFolder;
		private List<string> BulletFilePaths => Directory.EnumerateFiles(_bulletFolder).ToList();

		public List<BulletModel> Bullets { get; set; }
		public int NumberOfBulletFiles => BulletFilePaths.Count;

		public BulletGetter(string bulletFolder)
		{
			_bulletFolder = bulletFolder;
		}

		public List<BulletModel> PopulateBullets()
		{
			List<BulletModel> bullets = new List<BulletModel>();

			foreach (string bulletFile in BulletFilePaths)
			{
				if(Path.GetFileName(bulletFile).StartsWith("bullet"))
						bullets.Add(PopulateBullet(bulletFile));
			}

			return bullets;
		}

		/// <summary>
		/// Populates an bullet object for a given bullet file path
		/// </summary>
		/// <param name="bulletFilePath"></param>
		/// <returns></returns>
		public BulletModel PopulateBullet(string bulletFilePath)
		{
			string bulletFileName = Path.GetFileName(bulletFilePath);
			List<string> bulletFileNameSubParts = bulletFileName.Split('_').ToList();
			bulletFileNameSubParts.Remove("bullet");
			bulletFileNameSubParts.Remove("macro.xml");

			BulletModel bullet = new BulletModel();
			bullet.WeaponType = DetermineBulletWeaponType(bulletFileNameSubParts);
			if (bullet.WeaponType == BulletWeaponType.turret)
				bulletFileNameSubParts.Remove("turret");
			bulletFileNameSubParts = RemoveMultitermBulletFileNameParameters(bulletFileNameSubParts);
			
			bulletFileNameSubParts.ForEach(x => bullet = ParseBulletSubstring(bullet, x));

			XmlDocument bulletXml = new XmlDocument();
			bulletXml.Load(bulletFilePath);
			bullet.Properties = ParseBulletPropertiesXml(bulletXml);

			bullet.Faction ??= FactionType.GEN;

			bullet.Name = GenerateBulletName(bullet).Trim();

			return bullet;
		}

		private BulletWeaponType DetermineBulletWeaponType(List<string> bulletFileNameSubParts)
		{
			BulletWeaponType weaponType = bulletFileNameSubParts.Contains("turret") ? BulletWeaponType.turret : BulletWeaponType.primary;

			return weaponType;
		}

		/// <summary>
		/// Replaces multi-term parameters in bullet file names e.g. replaces "limpet_mine"'s "limpet" and "mine" strings with a single "LimpetMine" string
		/// </summary>
		/// <param name="bulletFileNameSubParts">original bulletFileNameSubParts</param>
		/// <returns>bulletFileNameSubParts with only single term parameters</returns>
		private List<string> RemoveMultitermBulletFileNameParameters(List<string> bulletFileNameSubParts)
		{
			if (bulletFileNameSubParts.Contains("spacesuit") && bulletFileNameSubParts.Contains("laser"))
			{
				bulletFileNameSubParts = bulletFileNameSubParts.Select(x => x == "spacesuit" ? "spacesuitlaser" : x).ToList();
				if (!bulletFileNameSubParts.Remove("laser")) { throw new Exception("Failed to remove subpart \"laser\" even though spacesuit was found in the list"); }
			}

			if (bulletFileNameSubParts.Contains("spacesuit") && bulletFileNameSubParts.Contains("repairlaser"))
			{
				bulletFileNameSubParts = bulletFileNameSubParts.Select(x => x == "spacesuit" ? "spacesuitrepairlaser" : x).ToList();
				if (!bulletFileNameSubParts.Remove("repairlaser")) { throw new Exception("Failed to remove subpart \"laser\" even though spacesuit was found in the list"); }
			}

			return bulletFileNameSubParts;
		}

		/// <summary>
		/// Returns a name for an bullet given its properties. Format will follow "XL ARG Combat Bullet Mk2"
		/// </summary>
		/// <param name="bullet">populated bullet object used to derive the name</param>
		/// <returns>readable name for the bullet object</returns>
		private string GenerateBulletName(BulletModel bullet)
		{
			string bulletName = $"{bullet.Size.ToString().ToUpper()} {bullet.Faction} {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(bullet.Type.ToString())} Bullet {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(bullet.Grade.ToString())}";

			if (bullet.Version > 1) { bulletName += $" {bullet.Version.Value:00}"; }

			return bulletName;
		}

		/// <summary>
		/// Parses a substring from an bullet file name, determines which property that substring represents, and assigns the corresponding enum
		/// </summary>
		/// <param name="bulletObject">original bullet object</param>
		/// <param name="bulletSubstring">substring taken from an bullet's filename e.g. arg, xl, or mk2</param>
		/// <returns>object with the new property added</returns>
		private BulletModel ParseBulletSubstring(BulletModel bulletObject, string bulletSubstring)
		{
			if (bulletObject.Version == null && int.TryParse(bulletSubstring, out int bulletVersion))
			{
				bulletObject.Version = bulletVersion;
				return bulletObject;
			}

			if (bulletObject.Faction == null && Enum.TryParse(bulletSubstring, true, out FactionType bulletFaction))
			{
				bulletObject.Faction = bulletFaction;
				return bulletObject;
			}

			if (bulletObject.Size == null && Enum.TryParse(bulletSubstring, true, out BulletSize bulletSize))
			{
				bulletObject.Size = bulletSize;
				return bulletObject;
			}

			if (bulletObject.Type == null && Enum.TryParse(bulletSubstring, true, out BulletType bulletType))
			{
				bulletObject.Type = bulletType;
				return bulletObject;
			}

			if (bulletObject.Grade == null && Enum.TryParse(bulletSubstring, true, out BulletGrade bulletGrade))
			{
				bulletObject.Grade = bulletGrade;
				return bulletObject;
			}

			throw new Exception($"Failed to parse bullet substring \"{bulletSubstring}\"");
		}

		/// <summary>
		/// Populates an bullet properties object from a given xml document
		/// </summary>
		/// <param name="xmlDocument">an bullet macro xml document</param>
		/// <returns>populated bullet properties object</returns>
		private Properties ParseBulletPropertiesXml(XmlDocument xmlDocument)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Properties));
			using XmlReader reader = new XmlNodeReader(xmlDocument.SelectNodes("macros//properties")[0]);

			Properties bulletProperties = (Properties)xmlSerializer.Deserialize(reader);

			return bulletProperties;
		}
	}
}
