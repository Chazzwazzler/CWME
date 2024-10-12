using UnityEngine;

namespace CWME
{
    public class ObjectAPI
    {
        /// <summary>
        /// Generate an empty GameObject with a sprite of your choosing.
        /// </summary>
        public static GameObject SpriteAsNewObject(Sprite sprite, Vector3 position)
        {
            GameObject obj = new GameObject();
            obj.AddComponent<SpriteRenderer>().sprite = sprite;
            obj.transform.position = position;
            return obj;
        }
    }
}
