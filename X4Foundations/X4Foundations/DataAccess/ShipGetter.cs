using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using X4Foundations.Model.Ship;

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

		///// <summary>
		///// Populates a list of ships for a given ship class
		///// </summary>
		///// <param name="shipClass"></param>
		///// <returns></returns>
		//public List<ShipModel> PopulateShips(ShipClass shipClass)
		//{
		//	List<ShipModel> ships = new List<ShipModel>();

		//	foreach (string shipFile in ShipFilePaths)
		//	{
		//		if (Path.GetFileName(shipFile).StartsWith(shipClass.ToString()))
		//			ships.Add(PopulateShip(shipFile));
		//	}

		//	return ships;
		//}

		///// <summary>
		///// Populates an ship object for a given ship file path
		///// </summary>
		///// <param name="shipFilePath"></param>
		///// <returns></returns>
		//private ShipModel PopulateShip(string shipFilePath)
		//{
		//	string shipFileName = Path.GetFileName(shipFilePath);
		//	List<string> shipFileNameSubParts = shipFileName.Split('_').ToList();
		//	shipFileNameSubParts.Remove("macro.xml");

		//	ShipModel ship = DetermineShipType(shipFilePath, shipFileNameSubParts);

		//	return ship;
		//}

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
				Directory.EnumerateFiles(shipFolder).ToList().ForEach(x => shipFilePaths.Add(x));
			}

			return shipFilePaths;
		}
	}
}
