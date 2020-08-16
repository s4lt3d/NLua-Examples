using System;
using System.Reflection;
using NLua;

namespace DynamicCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Lua state = new Lua();

            MethodInfo printOutputFunction = typeof(Program).GetMethod("LuaPrint");
            state.RegisterFunction("print", printOutputFunction);

            string lua_code = @"
                x = 15
                y = 18
                z = x + y
                print('z = ' .. z)
            ";
            Console.WriteLine("Running Lua Script");
            state.DoString(lua_code);
            Console.WriteLine("Getting variable x from state: " + state["x"]);
            Console.ReadKey();
        }

        static public void LuaPrint(params object[] others) {
            foreach(object o in others)
                Console.WriteLine(o.ToString());
        }
    }
}
