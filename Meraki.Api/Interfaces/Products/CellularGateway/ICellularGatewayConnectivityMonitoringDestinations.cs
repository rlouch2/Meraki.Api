﻿namespace Meraki.Api.Interfaces.Products.CellularGateway;

public interface ICellularGatewayConnectivityMonitoringDestinations
{
	/// <summary>
	/// Return the connectivity testing destinations for an MG network
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="networkId">The network id</param>
	[Get("/networks/{networkId}/cellularGateway/connectivityMonitoringDestinations")]
	Task<NetworkCellularGatewaySettingsConnectivityMonitoringDestinationsUpdateRequest> GetNetworkCellularGatewaySettingsConnectivityMonitoringDestinationsAsync(
		[AliasAs("networkId")] string networkId,
		CancellationToken cancellationToken = default
		);

	/// <summary>
	/// Update the connectivity testing destinations for an MG network
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="networkId">The network id</param>
	/// <param name="updateNetworkCellularGatewaySettingsConnectivityMonitoringDestinations">Body for updating the connectivity testing destinations</param>
	[Put("/networks/{networkId}/cellularGateway/connectivityMonitoringDestinations")]
	Task<NetworkCellularGatewaySettingsConnectivityMonitoringDestinationsUpdateRequest> UpdateNetworkCellularGatewaySettingsConnectivityMonitoringDestinationsAsync(
		[AliasAs("networkId")] string networkId,
		[Body] NetworkCellularGatewaySettingsConnectivityMonitoringDestinationsUpdateRequest updateNetworkCellularGatewaySettingsConnectivityMonitoringDestinations,
		CancellationToken cancellationToken = default
		);
}