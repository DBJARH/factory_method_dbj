# Application Architecture 

For me the clean alternative: static factory method

```cs
class Service {
    private Service(Database db) { ... }  // private, trivial, cannot fail

    public static Result<Service> Create(Database db) {
        if (db == null) return Result.Fail("no db");
        return Result.Ok(new Service(db));
    }
}
```

Constructor just does no work. All fallible logic lives in a method that can return an error. This is what C++ `std::expected` and Rust `Result` enforce structurally.
C# primary constructors make this worse — they nudge you toward putting logic in the constructor implicitly, with no guard rails.

### Do not use non-default constructors. Use factory methods.

>[!TIP]
>Also see the [previous work](https://dbj.org/c-be-carefull-to-use-default-constructors-only/) on this very subject.
>Same philosphy but it is C++ repo.

---
## .NET C#
## Appendix: Dev Environment Setup, Build & Debug

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [VS Code](https://code.visualstudio.com/) with the **C# Dev Kit** extension

### Build

```sh
dotnet build dbj_factory_method/dbj_factory_method.csproj -c Debug
```

Or in VS Code: `Ctrl+Shift+B` (runs the preconfigured build task).

### Run

```sh
dotnet run --project dbj_factory_method/dbj_factory_method.csproj
```

### Debug

In VS Code press `F5` to launch the **"Debug dbj_factory_method"** configuration. This builds automatically before launching. Breakpoints, watch, and the integrated terminal are all available.

---

&copy; dbj@dbj.org -- no license, copy and use at will. All the risks are yours.
