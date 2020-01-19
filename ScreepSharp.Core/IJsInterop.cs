using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core
{
    public interface IJsInterop
    {
        void InvokeVoid(string identifier, params object[] args);

        T Invoke<T>(string identifier, params object[] args);

        T InvokeById<T>(string id, string target);
        T InvokeById<T>(string id, string target, params object[] args);

        bool TryGet<T>(string path, string key, out T value);
        bool TrySet<T>(string path, string key, T value);

        T Get<T>(string path, string key);
       // void Set<T>(string path, T value); //there is no set, only try

        string[] GetKeys(string path);

        void WriteLine(string line);
    }
}
