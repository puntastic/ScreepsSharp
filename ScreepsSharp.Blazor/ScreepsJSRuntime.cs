using Mono.WebAssembly.Interop;
using ScreepsSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
    public class ScreepsJSRuntime : MonoWebAssemblyJSRuntime, IJsInterop
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

        public void InvokeVoid(string identifier, params object[] args) { _ = Invoke<object>(identifier, args);  }
        //public T JsonConvertInvoke<T>(string identifier, params object[] args)
        //{
        //    string result = Invoke<string>(identifier, args);
        //    if(result == null) { return default; }

        //    return JsonConvert.DeserializeObject<T>(result);
        //}
        
        protected ScreepsJSRuntime() { }

    }


}
