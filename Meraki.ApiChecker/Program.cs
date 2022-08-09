﻿using Meraki.ApiChecker;
using PanoramicData.SheetMagic;

Console.WriteLine($"{ThisAssembly.AssemblyName} v{ThisAssembly.AssemblyInformationalVersion}");

Console.Write("Getting implemented endpoints...");
var implementedEndpoints = InterfaceReader.GetEndPoints();
Console.WriteLine("done.");
Console.Write("Retrieving API schema...");
var apiSchema = await OpenApiReader.GetSchemaAsync().ConfigureAwait(false);
Console.WriteLine("done.");
/*
TableOutput.DisplayAndPruneTag(apiSchema, implementedEndpoints, "configure");
TableOutput.DisplayAndPruneTag(apiSchema, implementedEndpoints, "monitor");
TableOutput.DisplayAndPruneTag(apiSchema, implementedEndpoints, "liveTools");

TableOutput.DisplayRemainingTags(apiSchema);
TableOutput.DisplayRemainingInterfaces(implementedEndpoints);
*/
Console.Write("Beginning build xlsx output...");
var configureEndpointSet = SheetOutput.CreateWorksheet(apiSchema, implementedEndpoints, "configure");
var monitorEndpointSet = SheetOutput.CreateWorksheet(apiSchema, implementedEndpoints, "monitor");
var liveToolsEndpointSet = SheetOutput.CreateWorksheet(apiSchema, implementedEndpoints, "liveTools");
var fileInfo = new FileInfo($"API Check {DateTime.UtcNow:yyyyMMddTHHmmss}.xlsx");
using var workbook = new MagicSpreadsheet(fileInfo);
workbook.AddSheet(configureEndpointSet.ImplementedEndpoints, "Configure-Implemented");
workbook.AddSheet(configureEndpointSet.DuplicatedEndpoints, "Configure-Duplicated");
workbook.AddSheet(configureEndpointSet.MissingEndpoints, "Configure-Missing");
workbook.AddSheet(monitorEndpointSet.ImplementedEndpoints, "Monitor-Implemented");
workbook.AddSheet(monitorEndpointSet.DuplicatedEndpoints, "Monitor-Duplicated");
workbook.AddSheet(monitorEndpointSet.MissingEndpoints, "Monitor-Missing");
workbook.AddSheet(liveToolsEndpointSet.ImplementedEndpoints, "LiveTools-Implemented");
workbook.AddSheet(liveToolsEndpointSet.DuplicatedEndpoints, "LiveTools-Duplicated");
workbook.AddSheet(liveToolsEndpointSet.MissingEndpoints, "LiveTools-Missing");
workbook.Save();
Console.WriteLine(fileInfo.FullName);
System.Diagnostics.Process.Start(fileInfo.FullName);