﻿using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Ship.Properties
{
	[Serializable, XmlRoot("rotationacceleration")]
	public class RotationAcceleration
	{
		[XmlAttribute("max")]
		public double Max { get; set; }
	}
}
