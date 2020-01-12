using Mono.WebAssembly.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screeps.Blazor.PoC
{
    public class ScreepsJSRuntime : MonoWebAssemblyJSRuntime
    {
        private static ScreepsJSRuntime _instance;

        //// They removed jsruntime.current... so i'll make my own jsruntime....
        public static ScreepsJSRuntime Current
        {
            get
            {
                if(_instance == null) 
                {
                    _instance = new ScreepsJSRuntime();
                    Initialize(_instance);
                }

                return _instance;
            }
        }

        protected ScreepsJSRuntime() { }

    }
}
