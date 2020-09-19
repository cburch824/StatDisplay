namespace X4Foundations.Model.WeaponSystem
{
	public interface IWeaponSystemModel
	{
		string Name { get; set; }
		FactionType? Faction { get; set; }
		WeaponSystemSize? Size { get; set; }
		WeaponSystemType? Type { get; set; }
		WeaponSystemGrade? Grade { get; set; }
		int? Version { get; set; }
		Properties Properties { get; set; }
	}
}
