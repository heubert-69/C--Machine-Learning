# C--Machine-Learning
A Collection of Code Files with Machine Learning From C# (Exercises from The Book called "C# Machine Learning")

Hands-on ML in C# (based on [C# Machine Learning Projects: 9 real world projects]). Supports .NET and Mono/CSC.

🚀 Quick Start
Option 1: .NET SDK (Recommended)
Install .NET 6+ SDK.

Run:

```bash
dotnet run --project ./Chapter3/DecisionTrees
```


Option 2: Mono/CSC (No .NET SDK)
```bash
Install Mono (Linux/macOS) or .NET Framework (Windows):
```

Linux/macOS:

```bash
sudo apt install mono-devel  # Debian/Ubuntu
brew install mono           # macOS
```

Windows: Ensure csc.exe is in PATH (usually comes with Visual Studio).

Compile + Run:

```bash
csc Chapter1/HelloML.cs -out:HelloML.exe  
mono HelloML.exe              # Linux/macOS  
./HelloML.exe                 # Windows (PowerShell)
```


📦 Key Libraries
Library	.NET (dotnet)	Mono (csc)
ML.NET	✅ Yes	❌ No
Deedle	✅ Yes	❌ No
Math.NET	✅ Yes	⚠️ Partial
🔥 For Mono users: Stick to System.* and basic math. Avoid ML.NET.

💡 Mono-Friendly Examples
```csharp
// Chapter1/HelloML.cs (Works with `csc`!)  
using System;

class HelloML {  
  static void Main() {  
    Console.WriteLine("Hello from C# ML!");  
  }  
}
```
Compile with:

```bash
csc HelloML.cs && mono HelloML.exe
```

❓ FAQ
Q: Why Mono?
A: For users without .NET SDK (e.g., older systems, lightweight setups).

Q: ML.NET on Mono?
A: ❌ No—use .NET SDK for ML.NET. Mono is for basic C# only.

This keeps it backward-compatible while guiding users to the right tool. 🛠️
