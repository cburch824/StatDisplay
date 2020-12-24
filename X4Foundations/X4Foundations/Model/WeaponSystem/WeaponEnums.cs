using System.ComponentModel;

namespace X4Foundations.Model.WeaponSystem
{
	public enum WeaponSystemSize
	{
		[Description("Extra Small")]
		xs,
		[Description("Small")]
		s,
		[Description("Medium")]
		m,
		[Description("Large")]
		l,
		[Description("Extra Large")]
		xl
	}

	public enum WeaponSystemType
	{
		laser,
		ion,
		beam,
		mining,
		plasma,
		flak,
		gatling,
		shotgun,
		cannon,
		burst,
		railgun,
		spacesuitlaser,
		spacesuitrepairlaser,
		charge,
		destroyer,
		dumbfire,
		guided,
		mine,
		torpedo,
		lasertower
	}

	public enum WeaponSystemClass
	{
		turret,
		missle,
		weapon,
		misslelauncher
	}

	public enum WeaponSystemGrade
	{
		[Description("Mark 1")]
		mk1,
		[Description("Mark 2")]
		mk2,
		[Description("Mark 3")]
		mk3
	}
}
