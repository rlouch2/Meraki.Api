﻿namespace Meraki.Api.Test.Networks.Clients;

public class Tests : MerakiClientTest
{
	public Tests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
	{
	}

	[Fact]
	public async Task GetClientsAsync_Succeeds()
	{
		var network = await GetFirstNetworkAsync()
			.ConfigureAwait(false);

		var result = await TestMerakiClient
			.Networks
			.Clients
			.GetNetworkClientsAsync(network.Id)
			.ConfigureAwait(false);
		result.Should().BeOfType<List<Client>>();
		result.Should().NotBeNull();
	}
}