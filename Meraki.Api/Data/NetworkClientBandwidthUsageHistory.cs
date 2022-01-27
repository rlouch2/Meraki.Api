﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Meraki.Api.Data;
/// <summary>
/// Bandwidth usage
/// </summary>
[DataContract]

public class NetworkClientBandwidthUsageHistory
{
	/// <summary>
	/// TS
	/// </summary>
	[DataMember(Name = "ts")]
	public string Ts { get; set; } = string.Empty;

	/// <summary>
	/// Total
	/// </summary>
	[DataMember(Name = "total")]
	public int Total { get; set; }
}
