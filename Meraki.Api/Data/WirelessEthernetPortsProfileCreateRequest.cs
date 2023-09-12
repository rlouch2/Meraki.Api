﻿namespace Meraki.Api.Data;

/// <summary>
/// Wireless Ethernet Ports Profile
/// </summary>
[DataContract]
public class WirelessEthernetPortsProfileCreateRequest
{
	/// <summary>
	/// Name
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	[DataMember(Name = "name")]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Is Default
	/// </summary>
	[ApiAccess(ApiAccess.ReadUpdate)]
	[DataMember(Name = "isDefault")]
	public bool? IsDefault { get; set; }

	/// <summary>
	/// Ports
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	[DataMember(Name = "ports")]
	public List<WirelessEthernetPortsProfilePort>? Ports { get; set; }

	/// <summary>
	/// USB Ports
	/// </summary>
	[ApiAccess(ApiAccess.ReadWrite)]
	[DataMember(Name = "usbPorts")]
	public List<WirelessEthernetPortsProfileUsbPort>? UsbPorts { get; set; }
}
