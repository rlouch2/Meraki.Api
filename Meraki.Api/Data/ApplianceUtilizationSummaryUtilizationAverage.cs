﻿namespace Meraki.Api.Data;

[DataContract]
public class ApplianceUtilizationSummaryUtilizationAverage
{
	/// <summary>
	/// Percentage
	/// </summary>
	[DataMember(Name = "percentage")]
	public double Percentage { get; set; }
}
