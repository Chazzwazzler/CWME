using UnityEngine;
using System;
using System.Reflection;

namespace CWME
{
    public static class ComponentValues
    {
        /// <summary>
        /// Copy all the values from identical fields from one component to another.
        /// </summary>
        public static void CopyValues<T>(T from, T to)
        {
            var json = JsonUtility.ToJson(from);
            JsonUtility.FromJsonOverwrite(json, to);
        }

        /// <summary>
        /// Will replace all references of one thing to another. Good for replacing things 
        /// like sprites or references to a gameobject. This function may be slow, so use it cautiously.
        /// </summary>
        public static void ReplaceReferences<T>(T from, T to)
        {
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject g = (GameObject)o;
                Component[] components = g.GetComponents(typeof(Component));
                foreach (var c in components)
                {
                    Type cType = c.GetType();
                    FieldInfo[] fields = cType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                    foreach (FieldInfo field in fields)
                    {
                        if (field.GetValue(c) == (object)from)
                        {
                            field.SetValue(c, to);
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Swaps a component attached to a gameobject to a different component. Will also copy all the values from 
        /// that component to the new one. Only for swapping a component for a modified version of itself, since the 
        /// function will fail if all the fields are not present.
        /// </summary>
        public static void SwapComponent(Component from, Type to)
        {
            GameObject g = from.gameObject;
            g.AddComponent(to);

            ComponentValues.CopyValues(from, g.GetComponent(to));
            ComponentValues.ReplaceReferences(from, g.GetComponent(to));
            UnityEngine.Object.Destroy(from);
        }
    }
}