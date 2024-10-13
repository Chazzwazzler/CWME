using System;
using UnityEngine;
using System.IO;
using CSharpCompiler;
using System.Reflection;

namespace CWME
{
    public class ModAPI
    {
        public static void RunMethodOnCached(string type = "Base", string method = "Main")
        {
            Assembly[] assemblies = CompileCache();
            foreach (var assembly in assemblies)
            {
                assembly.RunMethod(type, method);
            }
        }

        public static Assembly[] CompileCache()
        {
            string[] directories = Directory.GetDirectories(Application.persistentDataPath + "/Cached");
            Assembly[] assemblies = new Assembly[directories.Length];
            for (int i = 0; i < assemblies.Length; i++)
            {
                assemblies[i] = Compiler.CompileFile(directories[i] + "/Script.txt");
            }
            return assemblies;
        }
    }
}
