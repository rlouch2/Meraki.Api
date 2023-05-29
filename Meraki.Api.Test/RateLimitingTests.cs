﻿using PanoramicData.SheetMagic;
using System.Diagnostics;
using System.Net;

namespace Meraki.Api.Test;

public class RateLimitingTests : MerakiClientTest
{
	public RateLimitingTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
	{
	}

	[Fact]
	public async Task GetAll_Succeeds()
	{
		var stopwatch = new Stopwatch();
		var timerList = new List<QueryResult>();
		foreach (var __ in Enumerable.Range(0, 10))
		{
			var queryResult = new QueryResult();
#pragma warning disable CA1031 // Do not catch general exception types
			try
			{
				stopwatch.Restart();
				var result = await TestMerakiClient
				.Organizations
				.GetOrganizationAsync(Configuration.TestOrganizationId)
				.ConfigureAwait(false);
				_ = result.Should().BeOfType<Organization>();
			}
			catch (ApiException apiException)
			{
				queryResult.StatusCode = apiException.StatusCode;
				queryResult.ExceptionMessage = apiException.Message;
			}
			catch (Exception exception)
			{
				queryResult.ExceptionMessage = exception.Message;
			}
			finally
			{
				queryResult.DurationMs = stopwatch.ElapsedMilliseconds;
				timerList.Add(queryResult);
			}
#pragma warning restore CA1031 // Do not catch general exception types
		}

		var fileInfo = new FileInfo(Path.GetTempFileName() + ".xlsx");
		using var magicSpreadsheet = new MagicSpreadsheet(fileInfo);
		magicSpreadsheet.AddSheet(timerList);
		magicSpreadsheet.Save();
	}
}

public class QueryResult
{
	public long DurationMs { get; set; }

	public HttpStatusCode? StatusCode { get; set; }

	public string? ExceptionMessage { get; set; }
}
