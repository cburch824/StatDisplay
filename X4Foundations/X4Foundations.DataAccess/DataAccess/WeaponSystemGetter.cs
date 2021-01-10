using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X4Foundations.DataAccess.DataAccess.WeaponSystemGetters;
using X4Foundations.DataAccess.Model.WeaponSystem;

namespace X4Foundations.DataAccess.DataAccess
{
	public class WeaponSystemGetter
	{
		private readonly string _weaponSystemBaseFolder;
		private List<string> WeaponSystemFolders => GetWeaponSystemMacroFolders(_weaponSystemBaseFolder);
		private List<string> WeaponSystemFilePaths => GetWeaponSystemFilePaths(WeaponSystemFolders);

		public List<IWeaponSystemModel> WeaponSystems { get; set; }
		public int NumberOfWeaponSystemFiles => WeaponSystemFilePaths.Count;

		public WeaponSystemGetter(string weaponSystemBaseFolder)
		{
			_weaponSystemBaseFolder = weaponSystemBaseFolder;
		}

		/// <summary>
		/// Populates a list of weapon systems for a given weapon system class
		/// </summary>
		/// <param name="weaponSystemClass"></param>
		/// <returns></returns>
		public List<IWeaponSystemModel> PopulateWeaponSystems(WeaponSystemClass weaponSystemClass)
		{
			List<IWeaponSystemModel> weaponSystems = new List<IWeaponSystemModel>();

			foreach (string weaponSystemFile in WeaponSystemFilePaths)
			{
				if (Path.GetFileName(weaponSystemFile).StartsWith(weaponSystemClass.ToString()))
					weaponSystems.Add(PopulateWeaponSystem(weaponSystemFile));
			}

			return weaponSystems;
		}

		/// <summary>
		/// Populates an weaponSystem object for a given weaponSystem file path
		/// </summary>
		/// <param name="weaponSystemFilePath"></param>
		/// <returns></returns>
		private IWeaponSystemModel PopulateWeaponSystem(string weaponSystemFilePath)
		{
			string weaponSystemFileName = Path.GetFileName(weaponSystemFilePath);
			List<string> weaponSystemFileNameSubParts = weaponSystemFileName.Split('_').ToList();
			weaponSystemFileNameSubParts.Remove("macro.xml");

			IWeaponSystemModel weaponSystem = DetermineWeaponSystemType(weaponSystemFilePath, weaponSystemFileNameSubParts);

			return weaponSystem;
		}

		/// <summary>
		/// Uses the weaponSystemTypeSubstring to return an initialized instance of a WeaponSystemModel
		/// </summary>
		/// <returns>initialized instance of the appropriate WeaponSystemModel</returns>
		private IWeaponSystemModel DetermineWeaponSystemType(string weaponSystemFilePath, List<string> weaponSystemFileNameSubParts)
		{
			switch(weaponSystemFileNameSubParts[0])
			{
				case "weapon":
					return new WeaponGetter().PopulateWeaponModel(weaponSystemFilePath, weaponSystemFileNameSubParts);
				case "turret":
					return new TurretGetter().PopulateTurretModel(weaponSystemFilePath, weaponSystemFileNameSubParts);
				default:
					throw new Exception($"Unknown WeaponSystem Model Type: {weaponSystemFileNameSubParts[0]}");
			}
		}

		/// <summary>
		/// Gets a list of the folders 
		/// </summary>
		/// <param name="weaponSystemBaseFolder"></param>
		/// <returns></returns>
		private List<string> GetWeaponSystemMacroFolders(string weaponSystemBaseFolder)
		{
			List<string> weaponSystemMacroFolders = new List<string>();

			List<string> weaponSystemFolders = Directory.EnumerateDirectories(weaponSystemBaseFolder).ToList();

			foreach (string weaponSystemFolder in weaponSystemFolders)
			{
				if (Directory.Exists($@"{weaponSystemFolder}\macros"))
				{
					weaponSystemMacroFolders.Add($@"{weaponSystemFolder}\macros");
				}
			}

			return weaponSystemMacroFolders;
		}

		/// <summary>
		/// Gets all weapon system file paths for a list of weapon system folders
		/// </summary>
		/// <param name="weaponSystemFolders"></param>
		/// <returns></returns>
		private List<string> GetWeaponSystemFilePaths(List<string> weaponSystemFolders)
		{
			List<string> weaponSystemFilePaths = new List<string>();

			foreach (string weaponSystemFolder in weaponSystemFolders)
			{
				Directory.EnumerateFiles(weaponSystemFolder).ToList().ForEach(x => weaponSystemFilePaths.Add(x));
			}

			return weaponSystemFilePaths;
		}
	}
}
