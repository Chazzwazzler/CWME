using System;
using System.CodeDom.Compiler;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace CWMod
{
    public class ModAPI
    {
        public const string BASE_SCRIPT_NAME = "Base";

        public static void RunFunctionOnAll(string Function){
            string[] directories = Directory.GetDirectories(Application.persistentDataPath + "/Cached");

            foreach (var directory in directories)
            {
                var assembly = Compiler.Compile(File.ReadAllText(directory + "/Script.txt"));

                var method = assembly.GetType (BASE_SCRIPT_NAME).GetMethod (Function);
                var del = (Action) Delegate.CreateDelegate (typeof (Action), method);
                del.Invoke();
            }
        }
    }
}
