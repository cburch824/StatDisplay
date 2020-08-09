using System;
using System.Collections.Generic;
using System.Text;

namespace X4Foundations.Model
{
	public enum WeaponSize
	{
		Large,
		Medium,
		Small
	}

	public enum WeaponType
	{
		Primary,
		Turret
	}

	interface IWeapon
	{
		string Name { get; set; }
		WeaponSize Size { get; set; }
		WeaponType Type { get; }
	}
}
