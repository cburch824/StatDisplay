﻿using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.WeaponSystem
{
	[Serializable, XmlRoot("rotationspeed")]
	public class RotationSpeed
	{
		[XmlAttribute("max")]
		public double Max { get; set; }
	}
}
