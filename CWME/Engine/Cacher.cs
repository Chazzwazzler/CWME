using System;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UnityEngine.UI;
using System.Linq;

namespace CWME
{
    public class Cacher
    {
        public static string cacheDirectory = Application.persistentDataPath + "/Cached";
        public static string cachedScriptName = "Script.cs";

        public static void SetDirectory(string directory)
        {
            if (directory == cacheDirectory)
            {
                ClearCache();
                return;
            }

            DeleteCache();
            cacheDirectory = directory;
            CreateCache();
        }

        /// <summary>
        /// Creates a folder for each mod in persistentDataPath/Cached/, and concatenates 
        /// all of the .cs files in each mod as one .txt in the mod's respective folder.
        /// The cache folder will be cleared or created if necessary before caching any mods.
        /// </summary>
        public static void CacheMods()
        {
            CreateCache();

            if (!Directory.Exists(ModAPI.modsDirectory))
            {
                return;
            }

            string[] directories = Directory.GetDirectories(ModAPI.modsDirectory);

            foreach (var directory in directories)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directory);

                string cachedModDirectory = Path.Join(cacheDirectory, dirInfo.Name);
                Directory.CreateDirectory(cachedModDirectory);
                FileInfo[] info = dirInfo.GetFiles("*.cs", SearchOption.AllDirectories);

                List<string> code = new List<string>();

                foreach (FileInfo f in info)
                {
                    string scriptText = File.ReadAllText(f.FullName);
                    code.Add(scriptText);
                }

                string scripts = JoinScripts(code.ToArray());
                File.WriteAllText(Path.Join(cachedModDirectory, cachedScriptName), scripts);
            }
        }

        public static string JoinScripts(string[] scripts)
        {
            List<string> usingDirectives = new List<string>();
            for (int i = 0; i < scripts.Length; i++)
            {
                SyntaxTree tree = CSharpSyntaxTree.ParseText(scripts[i]);
                CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
                foreach (var directive in root.Usings)
                {
                    usingDirectives.Add(directive.ToString());
                    scripts[i].Replace(directive.ToString(), "");
                }
            }
            string[] reordered = usingDirectives.Distinct().ToArray().Concat(scripts).ToArray();
            return String.Join(" ", reordered);
        }

        public static void ClearCache()
        {
            if (!Directory.Exists(cacheDirectory))
            {
                return;
            }

            DirectoryInfo cacheDir = new DirectoryInfo(cacheDirectory);

            foreach (FileInfo file in cacheDir.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in cacheDir.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static void DeleteCache()
        {
            if (!Directory.Exists(cacheDirectory))
            {
                return;
            }

            DirectoryInfo cacheDir = new DirectoryInfo(cacheDirectory);
            cacheDir.Delete(true);
        }

        public static void CreateCache()
        {
            if (Directory.Exists(cacheDirectory))
            {
                ClearCache();
                return;
            }

            Directory.CreateDirectory(cacheDirectory);
        }
    }

}
