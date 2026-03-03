// See https://aka.ms/new-console-template for more information

/// We do not use non default constructor
/// we use factory method instead
/// it creates the instance but crucially, unlike conctructor it can return the value
///  But, whats wrong with exception?
///  By now (2026Q1), C# comunit is aware of bad side effects of exceptions

// happy path
await test("AUS");
// non happy path: jurisdiction is not "AUS" so factory returns empty patent
// and that is reported as error
await test("USA");

static async Task test(string jurisdiction)
{
    var pt = await Patent.CreateAsync("AUPTO", jurisdiction);

    if (pt.IsEmpty())
    {
        await Console.Out.WriteLineAsync("Invalid patent: jurisdiction is not recognized. It has to be 'AUS'");
    }
    else
    {
        await Console.Out.WriteLineAsync($"PATENT PtO:'{pt.Pto}', Jurisdiction:'{pt.Jurisdiction}' ");
    }
}
