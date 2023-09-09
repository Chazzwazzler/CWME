using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace CWMod
{
    public class ObjectAPI
    {
        
        public static GameObject SpriteAsNewObject(Sprite sprite, Vector3 position){
            GameObject obj = new GameObject();
            obj.AddComponent<SpriteRenderer>().sprite = sprite;
            obj.transform.position = position;
            return obj;
        }
    }
}
