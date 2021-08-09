﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Meraki.Api.Data
{
	/// <summary>
	/// Alternate management interface
	/// </summary>
	[DataContract]
	public class AlternateManagementInterface
	{
		/// <summary>
		/// Alternate management VLAN, must be between 1 and 4094
		/// </summary>
		[DataMember(Name = "vlan")]
		public int Vlan { get; set; }

		/// <summary>
		/// Boolean value to enable or disable AMI configuration. If enabled, VLAN and protocols must be set
		/// </summary>
		[DataMember(Name = "enabled")]
		public bool Enabled { get; set; }

		/// <summary>
		/// Can be one or more of the following values: 'radius', 'snmp' or 'syslog'
		/// </summary>
		[DataMember(Name = "protocols")]
		public List<string> Protocols { get; set; } = new();

		/// <summary>
		/// Array of switch serial number and IP assignment. If parameter is present, it cannot have empty body. Note: switches parameter is not applicable for template networks, in other words, do not put 'switches' in the body when updating template networks. Also, an empty 'switches' array will remove all previous assignments
		/// </summary>
		[DataMember(Name = "switches")]
		public List<Switches> Switches { get; set; } = new();
	}
}
