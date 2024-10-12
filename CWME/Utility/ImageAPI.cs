using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace CWME
{
    public class ImageAPI
    {
        public static List<Assembly> mods = new List<Assembly>();

        public const int DEFAULT_PPU = 32;
        public static Vector2 DEFAULT_PIVOT = new Vector2(0.5f, 0.5f);

        /// <summary>
        /// Load a path to an image as a sprite.
        /// </summary>
        public static Sprite CustomSprite(string imagePath, int pixelsPerUnit = DEFAULT_PPU)
        {
            return CustomSprite(imagePath, DEFAULT_PIVOT, pixelsPerUnit);
        }
        /// <summary>
        /// Load a path to an image as a sprite.
        /// </summary>
        public static Sprite CustomSprite(string imagePath, Vector2 pivotPoint, int pixelsPerUnit = DEFAULT_PPU)
        {
            string path = Application.dataPath + "/mods/" + imagePath;

            Sprite customSprite;

            byte[] fileBytes = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileBytes);
            tex.filterMode = FilterMode.Point;
            customSprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), pivotPoint, pixelsPerUnit);

            return customSprite;
        }

        /// <summary>
        /// Replace all references to a sprite in the scene with a sprite of your choice.
        /// </summary>
        public static void ReplaceSpriteInScene(string spriteName, Sprite sprite)
        {
            SpriteRenderer[] renderers = GameObject.FindObjectsOfType<SpriteRenderer>();

            foreach (var renderer in renderers)
            {
                if (renderer.sprite.name == spriteName)
                {
                    renderer.sprite = sprite;
                }
            }
        }
    }
}
