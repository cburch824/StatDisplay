﻿using System;
using System.Xml.Serialization;

namespace X4Foundations.DataAccess.Model.Ship.Properties
{
	[Serializable, XmlRoot("people")]
	public class People
	{
		[XmlAttribute("capacity")]
		public int Capacity { get; set; }
	}
}
