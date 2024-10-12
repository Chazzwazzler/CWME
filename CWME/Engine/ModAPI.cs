using System;
using UnityEngine;
using System.IO;
using CSharpCompiler;

namespace CWME
{
    public class ModAPI
    {
        /// <summary>
        /// Generates an assembly for every cached mod and runs a function of your choice on a static class of your choice 
        /// (Base by default) on every mod. Generally, this will be how you load, initialize, and unload mods.
        /// </summary>
        public static void RunFunctionOnAll(string Function = "Main", string Class = "Base")
        {
            string[] directories = Directory.GetDirectories(Application.persistentDataPath + "/Cached");

            foreach (var directory in directories)
            {
                var assembly = Compiler.CompileFile(directory + "/Script.txt");
                assembly.RunMethod(Class, Function);
            }
        }
    }
}
