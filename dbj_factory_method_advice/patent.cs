// Patent interface
public interface IPatent
{
    string Pto { get; }
    string Jurisdiction { get; }
}

// Concrete Patent implementation
/*

When to Use Each

Class: When you need identity, inheritance, or complex mutable objects
Record: When you need immutable data transfer objects with value semantics
Struct: When you need small, simple value types (typically <16 bytes)

Records are particularly useful in functional programming patterns and 
for representing immutable data, while structs are excellent for 
performance-critical code dealing with small values.

*/
sealed record Patent : IPatent
{
    // Properties with init accessors and custom setters
    // make default ctors redundant
    // shorthand init variant
    public string Pto { get; init; } = string.Empty;
    // a bit more elaborate init setter variant
    public string Jurisdiction 
    { 
        get => Jurisdiction; 
        // init setter value can be assigned only from some ctor
        // but we avoid ctors delibarately
        init => Jurisdiction = value ?? string.Empty;
    }

    // Private default constructor prevents direct instantiation
    // that is the reason of having it empty
    // factory method assures controlled instantiation
    // The parameterless struct constructor must be 'public'
    private Patent()
    {
        // not required any code in a ctor
        // Pto = string.Empty;
        // Jurisdiction = string.Empty;
    }

    // Async factory method
    // factory method assures controlled instantiation
    // this is a class method so it does not complicate the type
    public static async Task<IPatent> CreateAsync(string pto, string jurisdiction)
    {
        // Simulate async work (e.g., validation, database lookup, API call)
        await Task.Delay(100);

        // Create and set properties
        var patent = new Patent
        {
            Pto = pto,
            Jurisdiction = jurisdiction
        };

        return patent;
    }
}