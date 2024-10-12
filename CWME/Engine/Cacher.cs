using System;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace CWMod
{
    public class Cacher
    {
        /// <summary>
        /// Creates a folder for each mod in persistentDataPath/Cached/, and concatenates 
        /// all of the .cs files in each mod as one .txt in the mod's respective folder.
        /// The cache folder will be cleared or created if necessary before caching any mods.
        /// </summary>
        public static void CacheMods()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Cached"))
            {
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


            if (!Directory.Exists(Application.dataPath + "/mods"))
            {
                return;
            }

            string[] directories = Directory.GetDirectories(Application.dataPath + "/mods");

            foreach (var directory in directories)
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name);
                FileInfo[] info = new DirectoryInfo(directory).GetFiles("*.cs*");

                List<string> code = new List<string>();
                string Base = "";

                foreach (FileInfo f in info)
                {
                    if (!f.Name.Contains(".meta") && !f.Name.Contains(".txt"))
                    {
                        File.Copy(f.FullName, Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/" + f.Name + ".txt");
                        if (f.Name == "Base.cs")
                        {
                            Base = File.ReadAllText(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/" + f.Name + ".txt");
                        }
                        else
                        {
                            code.Add(File.ReadAllText(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/" + f.Name + ".txt"));
                        }
                        File.Delete(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/" + f.Name + ".txt");
                    }
                }
                code.Insert(0, Base);
                File.WriteAllLines(Application.persistentDataPath + "/Cached/" + new DirectoryInfo(directory).Name + "/Script.txt", code);
            }
        }
    }

}
