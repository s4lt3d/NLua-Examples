using System;
using System.Reflection;
using NLua;

namespace DynamicCSharp
{
    class Program // name of the class, used on line 14
    {
        static void Main(string[] args)
        {
            Lua state = new Lua();

            // Here we register methods with the lua script engine. The typeof function takes the name of the class.
            MethodInfo printFunction = typeof(Program).GetMethod("LuaPrint");
            state.RegisterFunction("print", printFunction);

            MethodInfo calculateMagnitudeFunction = typeof(Program).GetMethod("CalculateMagnitude");
            state.RegisterFunction("magnitude", calculateMagnitudeFunction);

            // The lua code to be executed. This can be loaded from a file, textbox, or any other string. 
            string lua_code = @"
                x = 3
                y = 4
                z = magnitude(x, y)
                print('z = ' .. z)
            ";

            Console.WriteLine("Running Lua Script");

            // Run the script
            state.DoString(lua_code);

            // Here we can get variables from the script that was run.
            Console.WriteLine("Getting variable x from state: " + state["x"]);

            Console.ReadKey();
        }

        // Print function called from lua script. The functions registered with the lua engine must be public. 
        static public void LuaPrint(params object[] others) {
            foreach(object o in others)
                Console.WriteLine(o.ToString());
        }

        // Do an operation and return a float 
        static public float CalculateMagnitude(params float[] others) {
            if (others.Length == 2) {
                float x = others[0];
                float y = others[1];
                return (float)Math.Sqrt(x * x + y * y);
            }
            return 0;
        }
    }
}
