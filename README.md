# .NET Application Architecture

### Do not use non-default constructors. Use factory methods.

>[!TIP]
>Also see the [previous work](https://dbj.org/c-be-carefull-to-use-default-constructors-only/) on this very subject.
>Same philosphy but it is C++ repo.

---

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
