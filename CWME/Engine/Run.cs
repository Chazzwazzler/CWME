using UnityEngine;
using System.Reflection;

namespace CWME
{
    public static class Run
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        static void OnBeforeSplashScreen()
        {
            Cacher.CacheMods();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void OnAfterSceneLoad()
        {
            ModAPI.RunMethodOnCached();
        }
    }
}
