# NLua-Examples: Integrating Lua Scripting with C#

Install NLua using NuGet

Install-Package NLua -Version 1.5.1

## Overview

NLua allows programs to execute basic lua scripts. This is useful when you want to change how the program behaves without having to recompile a program. 

This example demonstrates the power of integrating Lua scripting within a C# application using the `NLua` library. This project serves as a basic introduction to interacting between C# and Lua, showcasing the potential of leveraging scripting capabilities in your C# applications.

## Key Features

- **Method Registration**: Seamlessly register C# methods which can be invoked directly from Lua.
- **Script Execution**: Execute Lua scripts from within your C# application.
- **Variable Retrieval**: Easily retrieve variables set within your Lua scripts back into your C# application.

## Code Description

1. **Lua Initialization**: 
   - The `Lua` object, `state`, is instantiated to provide a new Lua state.
   
2. **Method Registration**: 
   - Two functions (`LuaPrint` and `CalculateMagnitude`) from the `Program` class are registered to be available within Lua. 
   - They are accessible from Lua scripts as `print` and `magnitude` respectively.
   
3. **Lua Script Execution**: 
   - A simple Lua script is defined and executed. 
   - This script demonstrates how to call the registered C# functions from Lua.
   
4. **Variable Access**: 
   - Variables set in the Lua script can be easily accessed and used within the C# environment.

### Public Methods:

- `LuaPrint(params object[] others)`: A replacement for the standard Lua `print` function, allowing Lua to directly print to the C# console.
- `CalculateMagnitude(params float[] others)`: Calculates the magnitude given two float values. This function can be called from Lua and returns the magnitude to Lua.

## Known Issues

Due to the complexity of interfacing between C# and Lua, there might be certain caveats or edge cases that developers should be aware of. This example highlights a specific issue related to calling functions across C# and Lua, which might require careful handling and understanding of both languages.

## Dependencies

This project requires the `NLua` library. Ensure you have it properly set up in your project to successfully integrate and run Lua scripts.

## Conclusion

`DynamicCSharp` offers a practical demonstration of how to augment your C# applications with Lua scripting capabilities. By understanding and building upon this foundation, developers can further explore the potential of such integrations in their applications.
