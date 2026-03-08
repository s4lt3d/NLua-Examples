# NLua Examples

> Demonstrations of integrating Lua scripting into C# applications using NLua for dynamic behavior without recompilation.

---

## Installation

Install NLua via NuGet:
```
Install-Package NLua -Version 1.5.1
```

---

## Overview

NLua enables C# applications to execute and interact with Lua scripts dynamically, allowing behavior changes without recompiling. This example demonstrates:

- Registering C# methods for Lua to call
- Executing Lua scripts from C#
- Retrieving variables from Lua back to C#

---

## Key Features

- **Method Registration** — Register C# functions as Lua callables
- **Script Execution** — Run Lua scripts within C# context
- **Variable Retrieval** — Access Lua variables from C#
- **Dynamic Behavior** — Modify logic via scripts without recompiling

---

## Example Code

### Lua Initialization

Create a new Lua state:
```csharp
var state = new Lua();
```

### Register C# Methods for Lua

```csharp
state["print"] = (Action<string>)LuaPrint;
state["magnitude"] = (Func<float, float, float>)CalculateMagnitude;
```

### Execute Lua Script

Define and run Lua code:
```lua
function calculate()
    local result = magnitude(3.0, 4.0)
    print("Magnitude: " .. result)
end
calculate()
```

### Access Lua Variables

Retrieve values from Lua:
```csharp
var value = state["myVariable"];
```

---

## Project Structure

```
├── README.md
├── NLuaExamples.sln
└── src/
    ├── LuaInterop.cs         — Main Lua integration class
    ├── Examples.cs           — Example code demonstrating features
    └── LuaScripts/
        └── script.lua        — Sample Lua scripts
```

---

## Architecture

### Lua State Management
- **Single Lua instance** per application context
- **Method registration** enables C# ↔ Lua communication
- **Variable sharing** through indexing (state["name"])

### Type Conversion
NLua automatically converts between:
- C# methods → Lua functions
- Lua tables → C# dictionaries
- Lua numbers → C# float/double
- Lua strings → C# strings

---

## Common Patterns

### Safe Script Execution
```csharp
try
{
    state.DoString("-- Lua code here");
}
catch (Exception ex)
{
    Console.WriteLine("Lua error: " + ex.Message);
}
```

### Callback Registration
```csharp
state["onEvent"] = (Action<string>)HandleEvent;
// Call from Lua: onEvent("data")
```

### Complex Data Exchange
```csharp
// Set table from C#
state.DoString("data = {}");
state["data"] = new LuaTable(state);
state.DoString("table.insert(data, 'value')");

// Retrieve from Lua
var result = state["data"];
```

---

## Important Notes

- Wrap Lua execution in try-catch for error handling
- Ensure C# method signatures match Lua function expectations
- NLua handles type conversions between C# and Lua
- Keep Lua scripts simple for better performance
- Use LuaTable for structured data exchange
