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
        /// <summary>
        /// Generates an assembly for every cached mod and runs a function of your choice on a static class of your choice 
        /// (Base by default) on every mod. Generally, this will be how you load, initialize, and unload mods.
        /// </summary>
        public static void RunFunctionOnAll(string Function, string Class = "Base")
        {
            string[] directories = Directory.GetDirectories(Application.persistentDataPath + "/Cached");

            foreach (var directory in directories)
            {
                var assembly = Compiler.Compile(File.ReadAllText(directory + "/Script.txt"));

                var method = assembly.GetType(Class).GetMethod(Function);
                var del = (Action)Delegate.CreateDelegate(typeof(Action), method);
                del.Invoke();
            }
        }
    }
}
