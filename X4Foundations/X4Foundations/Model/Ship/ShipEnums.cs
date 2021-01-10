using System.ComponentModel;

namespace X4Foundations.Model.Ship
{
	public enum ShipSize
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

	public enum ShipType
	{
		miner,
		minerliquid,
		minersolid,
		scout,
		fighter,
		heavyfighter,
		trans,
		bomber,
		corvette,
		frigate,
		destroyer,
		fightingdrone,
		fightingdroneexplosive,
		lasertower,
		miningdrone,
		miningdroneliquid,
		miningdronesolid,
		resupplier,
		builder,
		carrier,
		cv,
		pv,
		spacesuit,
		police,
		boardingpod,
		buildingdrone,
		cargodrone,
		cargodroneempty,
		cargodroneliquid,
		cargodroneequipment,
		cargodronepickup,
		cargoodronesolid,
		distressbeacon,
		escapepod,
		repairdrone,
	}

	public enum ConnectionType
	{
		shield,
		primaryweapon,
		turret,
		engine,
		jumpdrive,
	}

	public enum ConnectionTag
	{
		weapon,
		standard,
		missle,
		mining,
		shield,
		jumpdrive,

		platformcollision,
		hittable,
		unhittable,

		extrasmall,
		small,
		medium,
		large,
		extralarge,
	}
}
