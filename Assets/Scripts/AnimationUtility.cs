using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationUtility
{
    /// <summary>
    /// Updates the progress of the forward and backward animation of a movable object 
    /// </summary>
    /// <param name="animator">The animator which contains the forward and backward animations</param>
    /// <param name="layer">The layer in which the set of animations lie</param>
    /// <param name="forwardAnim">Name of the forward animation / state </param>
    /// <param name="backwardAnim">Name of the backward animation / state </param>
    /// <param name="forwardAnimTime">Variable to store the progress of the forward animation</param>
    /// <param name="backwardAnimTime">Variable to store the progress of the backward animation</param>
    public static void UpdateAnimationProgress(Animator animator, int layer, string forwardAnim, string backwardAnim, ref float forwardAnimTime, ref float backwardAnimTime)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layer);

        //If the current animation is the forward animation, store its progress inside forwardAnimTime,
        //and update backwardAnimTime time by inverting it
        if (stateInfo.IsName(forwardAnim) && stateInfo.normalizedTime < 1)
        {
            forwardAnimTime = stateInfo.normalizedTime;
            backwardAnimTime = 1 - stateInfo.normalizedTime;
        }

        //If the current animation is the backward animation, store its progress inside backwardAnimTime,
        //and update forwardAnimTime time by inverting it
        if (stateInfo.IsName(backwardAnim) && stateInfo.normalizedTime < 1)
        {
            backwardAnimTime = stateInfo.normalizedTime;
            forwardAnimTime = 1 - stateInfo.normalizedTime;
        }

    }
    /// <summary>
    /// Changes the animator state if newState is different to the current state
    /// </summary>
    /// <param name="animator">Animator to use</param>
    /// <param name="newState">Name of the new state</param>
    /// <param name="layer">Layer in which the state lies</param>
    /// <param name="time">The time in which to start the animation. Ranges 0 to 1</param>
    public static void ChangeAnimatorState(Animator animator, string newState, int layer, float time)
    {

        animator.speed = 1;

        if (animator.GetCurrentAnimatorStateInfo(layer).IsName(newState))
        {
            return;
        }
        else
        {

            animator.Play(newState, layer, time);
            Debug.Log("Changin to state: " + newState + "Time: " + time);

        }
    }
}
