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
		_ = result.Should().BeOfType<List<Client>>();
		_ = result.Should().NotBeNull();
	}

	[Fact]
	public async Task GetClientAsync_Succeeds()
	{
		var network = await GetFirstNetworkAsync()
			.ConfigureAwait(false);

		

		var result = await TestMerakiClient
			.Networks
			.Clients
			.GetNetworkClientAsync("L_784752235069311179", Configuration.TestMac)
			.ConfigureAwait(false);
		_ = result.Should().BeOfType<List<Client>>();
		_ = result.Should().NotBeNull();
	}
}
