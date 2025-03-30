// See https://aka.ms/new-console-template for more information

var pt = await Patent.CreateAsync("AUPTO", "AUS");

await Console.Out.WriteLineAsync($"PATENT PtO:'{pt.Pto}', Jurisdiction:'{pt.Jurisdiction}' ");