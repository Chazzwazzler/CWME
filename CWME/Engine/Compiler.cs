using System;
using System.CodeDom.Compiler;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace CWMod{
    public class Compiler
    {
        public static void CacheMods(){
            if(!Directory.Exists(Application.persistentDataPath + "/Cached")){
                Directory.CreateDirectory(Application.persistentDataPath + "/Cached");
            }

            DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/Cached");

            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete(); 
            }
            foreach (DirectoryInfo _dir in dir.GetDirectories())
            {
                _dir.Delete(true); 
            }
            

            if(!Directory.Exists(Application.dataPath + "/mods")){
                return; 
            }
            
            string[] directories = Directory.GetDirectories(Application.dataPath + "/mods");

            foreach (var directory in directories)
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name);
                FileInfo[] info = new DirectoryInfo(directory).GetFiles("*.cs*");

                List<string> code = new List<string>();
                string Base = "";

                foreach (FileInfo f in info){
                    if(!f.Name.Contains(".meta") && !f.Name.Contains(".txt")){
                        File.Copy(f.FullName, Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/"+f.Name+".txt");
                        if(f.Name == "Base.cs"){
                            Base = File.ReadAllText(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/"+f.Name+".txt");
                        }
                        else{
                            code.Add(File.ReadAllText(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/"+f.Name+".txt"));   
                        }
                        File.Delete(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/"+f.Name+".txt");
                    }
                }
                code.Insert(0, Base);
                File.WriteAllLines(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/Script.txt", code);
            }
        }

        public static Assembly Compile (string source) {
            var options = new CompilerParameters ();
            options.GenerateExecutable = false;
            options.GenerateInMemory = true;

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies ()) {
                if (!assembly.IsDynamic) {
                    options.ReferencedAssemblies.Add (assembly.Location);
                }
            }

            var compiler = new CSharpCompiler.CodeCompiler ();
            var result = compiler.CompileAssemblyFromSource (options, source);

            foreach (var err in result.Errors) {
                Debug.Log (err);
            }

            return result.CompiledAssembly;
        }
    }

}
