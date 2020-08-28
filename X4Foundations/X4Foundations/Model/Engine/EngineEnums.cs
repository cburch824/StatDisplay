using System.ComponentModel;

namespace X4Foundations.Model.Engine
{
	public enum EngineSize
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

	public enum EngineType
	{
		allround,
		travel,
		combat,
		police,
		pv,
		buildingdrone,
		escapepod,
		repairdrone,
		spacesuit,
		Static,
		transporter
	}

	public enum EngineGrade
	{
		[Description("Mark 1")]
		mk1,
		[Description("Mark 2")]
		mk2,
		[Description("Mark 3")]
		mk3
	}
}
