using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using X4Foundations.Model.Ship;
using X4Foundations.Model.Ship.Properties;

namespace X4Foundations.DataAccess
{
	public class ShipGetter
	{

		private readonly string _shipBaseFolder;
		private List<string> ShipFolders => GetShipMacroFolders(_shipBaseFolder);
		private List<string> ShipFilePaths => GetShipFilePaths(ShipFolders);

		public List<ShipModel> Ships { get; set; }
		public int NumberOfShipFiles => ShipFilePaths.Count;

		public ShipGetter(string shipBaseFolder)
		{
			_shipBaseFolder = shipBaseFolder;
		}

		/// <summary>
		/// Populates a list of ships for a given ship class
		/// </summary>
		/// <returns></returns>
		public List<ShipModel> PopulateShips()
		{
			List<ShipModel> ships = new List<ShipModel>();

			foreach (string shipFile in ShipFilePaths)
			{
				ships.Add(PopulateShip(shipFile));
			}

			return ships;
		}

		/// <summary>
		/// Populates an ship object for a given ship file path
		/// </summary>
		/// <param name="shipFilePath"></param>
		/// <returns></returns>
		private ShipModel PopulateShip(string shipFilePath)
		{
			string shipFileName = Path.GetFileName(shipFilePath);
			List<string> shipFileNameSubParts = shipFileName.Split('_').ToList();
			shipFileNameSubParts.Remove("ship");
			shipFileNameSubParts.Remove("macro.xml");

			ShipModel ship = new ShipModel();
			shipFileNameSubParts.ForEach(x => ship = ParseShipSubstring(ship, x));

			XmlDocument shipXml = new XmlDocument();
			shipXml.Load(shipFilePath);
			ship.Properties = ParseShipPropertiesXml(shipXml);

			ship.Faction ??= FactionType.GEN;

			//ship.Name = GenerateShipName(ship).Trim();

			return ship;
		}

		/// <summary>
		/// Parses a substring from an ship file name, determines which property that substring represents, and assigns the corresponding enum
		/// </summary>
		/// <param name="shipObject">original ship object</param>
		/// <param name="shipSubstring">substring taken from an ship's filename e.g. arg, xl, or mk2</param>
		/// <returns>object with the new property added</returns>
		private ShipModel ParseShipSubstring(ShipModel shipObject, string shipSubstring)
		{
			if (shipObject.Version == null && int.TryParse(shipSubstring, out int shipVersion))
			{
				shipObject.Version = shipVersion;
				return shipObject;
			}

			if (shipObject.Faction == null && Enum.TryParse(shipSubstring, true, out FactionType shipFaction))
			{
				shipObject.Faction = shipFaction;
				return shipObject;
			}

			if (shipObject.Size == null && Enum.TryParse(shipSubstring, true, out ShipSize shipSize))
			{
				shipObject.Size = shipSize;
				return shipObject;
			}

			if (shipObject.Type == null && Enum.TryParse(shipSubstring, true, out ShipType shipType))
			{
				shipObject.Type = shipType;
				return shipObject;
			}

			if (shipObject.VersionLetter == null && char.TryParse(shipSubstring, out char weaponVersionLetter))
			{
				shipObject.VersionLetter = weaponVersionLetter;
				return shipObject;
			}

			throw new Exception($"Failed to parse ship substring \"{shipSubstring}\"");
		}

		///// <summary>
		///// Uses the shipTypeSubstring to return an initialized instance of a ShipModel
		///// </summary>
		///// <returns>initialized instance of the appropriate ShipModel</returns>
		//private ShipModel DetermineShipType(string shipFilePath, List<string> shipFileNameSubParts)
		//{
		//	switch (shipFileNameSubParts[0])
		//	{
		//		case "weapon":
		//			return new WeaponGetter().PopulateWeaponModel(shipFilePath, shipFileNameSubParts);
		//		case "turret":
		//			return new TurretGetter().PopulateTurretModel(shipFilePath, shipFileNameSubParts);
		//		default:
		//			throw new Exception($"Unknown Ship Model Type: {shipFileNameSubParts[0]}");
		//	}
		//}

		/// <summary>
		/// Gets a list of the folders 
		/// </summary>
		/// <param name="shipBaseFolder"></param>
		/// <returns></returns>
		private List<string> GetShipMacroFolders(string shipBaseFolder)
		{
			List<string> shipMacroFolders = new List<string>();

			List<string> shipFolders = Directory.EnumerateDirectories(shipBaseFolder).ToList();

			foreach (string shipFolder in shipFolders)
			{
				if (Directory.Exists($@"{shipFolder}\macros"))
				{
					shipMacroFolders.Add($@"{shipFolder}\macros");
				}
			}

			return shipMacroFolders;
		}

		/// <summary>
		/// Gets all ship file paths for a list of ship folders
		/// </summary>
		/// <param name="shipFolders"></param>
		/// <returns></returns>
		private List<string> GetShipFilePaths(List<string> shipFolders)
		{
			List<string> shipFilePaths = new List<string>();

			foreach (string shipFolder in shipFolders)
			{
				Directory.EnumerateFiles(shipFolder).Where(x => Path.GetFileName(x).StartsWith("ship")).ToList().ForEach(x => shipFilePaths.Add(x));
			}

			return shipFilePaths;
		}

		/// <summary>
		/// Populates an ship properties object from a given xml document
		/// </summary>
		/// <param name="xmlDocument">an ship macro xml document</param>
		/// <returns>populated ship properties object</returns>
		private Properties ParseShipPropertiesXml(XmlDocument xmlDocument)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Properties));
			using XmlReader reader = new XmlNodeReader(xmlDocument.SelectNodes("macros//properties")[0]);

			Properties shipProperties = (Properties)xmlSerializer.Deserialize(reader);

			return shipProperties;
		}
	}
}
