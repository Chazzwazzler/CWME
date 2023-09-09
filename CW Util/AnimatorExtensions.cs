using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CWUtils{
    public static class AnimatorExtensions
    {
        /// <summary>
        /// Checks if a specific animation is currently playing on an animator.
        /// </summary>
        public static bool IsPlaying(this Animator animator, string animName){
            if(animator.IsPlayingAny()){
                return animator.GetCurrentAnimatorStateInfo(0).IsName(animName);
            }
            else{
                return false;
            }
        }

        /// <summary>
        /// Checks if any animation is playing on an animator.
        /// </summary>
        public static bool IsPlayingAny(this Animator animator){
            return animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }
    }
}
