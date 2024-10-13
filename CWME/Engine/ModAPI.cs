using UnityEngine;
using System.IO;
using CSharpCompiler;
using System.Reflection;

namespace CWME
{
    public class ModAPI
    {
        public static string modsDirectory = Application.dataPath + "/mods";

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
            string[] directories = Directory.GetDirectories(Cacher.cacheDirectory);
            Assembly[] assemblies = new Assembly[directories.Length];
            for (int i = 0; i < assemblies.Length; i++)
            {
                assemblies[i] = Compiler.CompileFile(Path.Join(directories[i], Cacher.cachedScriptName));
            }
            return assemblies;
        }
    }
}
