using System;
using System.Collections.Generic;
using System.Text;

namespace X4Foundations.Model
{
	class Turret : IWeapon
	{
		public string Name { get; set; }
		public WeaponSize Size { get; set; }
		public WeaponType Type { get; } = WeaponType.Turret;
	}
}
