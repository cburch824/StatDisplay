using System.ComponentModel;

namespace X4Foundations.Model.Bullet
{
	public enum BulletSize
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

	public enum BulletType
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
	}

	public enum BulletWeaponType
	{
		primary,
		turret
	}

	public enum BulletGrade
	{
		[Description("Mark 1")]
		mk1,
		[Description("Mark 2")]
		mk2,
		[Description("Mark 3")]
		mk3
	}
}
