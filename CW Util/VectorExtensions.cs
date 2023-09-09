using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CWUtils{
    public static class VectorExtensions
    {
        /// <summary>
        /// Returns whether there is any colliders at a position.
        /// </summary>
        public static bool ColliderAtPos(this Vector3 pos){
            Collider2D currentCollider;
            currentCollider = Physics2D.OverlapCircle(pos, 0.0f);

            return currentCollider == null ? false:true;
        }

        /// <summary>
        /// Returns the collider at a position.
        /// </summary>
        public static Collider2D GetColliderAtPos(this Vector3 pos){
            Collider2D currentCollider;
            currentCollider = Physics2D.OverlapCircle(pos, 0.0f);

            return currentCollider;
        }

        /// <summary>
        /// Returns all colliders at a position.
        /// </summary>
        public static Collider2D[] GetCollidersAtPos(this Vector3 pos){
            Collider2D[] currentCollider;
            currentCollider = Physics2D.OverlapCircleAll(pos, 0.0f);

            return currentCollider;
        }

        /// <summary>
        /// Returns the direction of the line formed by the origin and the endpoint.
        /// </summary>
        public static Vector3 GetLineDir(this Vector3 origin, Vector3 endPoint){
            Vector3 dir = (endPoint - origin).normalized;
            return dir;
        }

        /// <summary>
        /// Rotates a Vector2.
        /// </summary>
        public static Vector2 RotateVector(this Vector2 vector, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = vector.x;
            float ty = vector.y;
            vector.x = (cos * tx) - (sin * ty);
            vector.y = (sin * tx) + (cos * ty);
            return vector;
        }
    }
}
