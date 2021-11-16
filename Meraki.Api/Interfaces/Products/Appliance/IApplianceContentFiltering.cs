﻿namespace Meraki.Api.Interfaces.Products.Appliance;

public interface IApplianceContentFiltering
{
	/// <summary>
	/// Return the content filtering settings for an MX network
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="networkId">The network id</param>
	[ApiOperationId("getNetworkApplianceContentFiltering")]
	[Get("/networks/{networkId}/appliance/contentFiltering")]
	Task<ContentFilteringResult> GetNetworkApplianceContentFilteringAsync(
		[AliasAs("networkId")] string networkId,
		CancellationToken cancellationToken = default
		);

	/// <summary>
	/// Update the content filtering settings for an MX network
	/// </summary>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="networkId">The network id</param>
	/// <param name="networkContentFilteringUpdateRequest">Body for updating content filtering settings</param>
	[ApiOperationId("updateNetworkApplianceContentFiltering")]
	[Put("/networks/{networkId}/appliance/contentFiltering")]
	Task<ContentFilteringResult> UpdateNetworkApplianceContentFilteringAsync(
		[AliasAs("networkId")] string networkId,
		[Body] ContentFilteringUpdateRequest networkContentFilteringUpdateRequest,
		CancellationToken cancellationToken = default
		);
}
