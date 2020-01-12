using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core
{
    public interface IJsInterop
    {
        void InvokeVoid(string identifier, params object[] args);
        T Invoke<T>(string identifier, params object[] args);
        T JsonConvertInvoke<T>(string identifier, params object[] args);
        //   void InvokeVoid(string identifier, object[] args);
    }
}
