# Application Architecture 

> [!NOTE] Primary constructors (C# 12, .NET 8) let you declare constructor parameters directly on the class/struct declaration. Parameters are in scope throughout the entire type body.

Still for me the clean alternative: static factory method

```cs
class Service {
    private Database _db;

    private Service() { }  // trivial, safe

    public static Result<Service> Create(Database db) {
        if (db == null) return Result.Fail("no db");
        var s = new Service();
        s._db = db;
        return Result.Ok(s);
    }
}
```

(primary) Constructor just does no work. Contrary to that, all fallible logic lives in a **factory method** that can return an error. This is what C++ `std::expected` and Rust `Result` enforce structurally.
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
