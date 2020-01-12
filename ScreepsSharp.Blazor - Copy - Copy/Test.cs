//using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;

namespace Screeps.Blazor.PoC
{
    public static class Test
    {
        //call this via 'Module.mono_bind_static_method('[Screeps.Blazor.PoC] Screeps.Blazor.PoC.Test:Hello')("a")'
        public static string Hello(string obj)
        {
            ScreepsJSRuntime.Current.InvokeVoid("console.log", "Hello " + obj);
            return "Hello " + obj;
        }
    }
}
