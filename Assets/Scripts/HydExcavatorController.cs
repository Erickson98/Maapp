using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HydExcavatorController : MonoBehaviour
{
    private const string ANIMS_ARM1_FORWARD = "HydExcavator_Arm1+2_Forward";
    private const string ANIMS_ARM1_BACKWARD = "HydExcavator_Arm1+2_Backward";
    private const string ANIMS_ARM3_FORWARD = "HydExcavator_Arm3_Forward";
    private const string ANIMS_ARM3_BACKWARD = "HydExcavator_Arm3_Backward";
    private const string ANIMS_ARM3_IDLE = "HydExcavator_Arm3_Idle"; 
    private const string ANIMS_ARM1_IDLE = "HydExcavator_Arm1+2_Idle";

    private const string LAYER_SPEED_MULT = "LayerSpeedMult";

    public float Arm1_AnimProgress_Fwd;
    public float Arm1_AnimProgress_Back;

    public float Arm3_AnimProgress_Fwd;
    public float Arm3_AnimProgress_Back;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.speed = 1;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(animator.speed);
        //AnimationHandler anim = new AnimationHandler();

        //anim.UpdateHandler();

        AnimationUtility.UpdateAnimationProgress(
            animator, 0, ANIMS_ARM1_FORWARD, ANIMS_ARM1_BACKWARD, ref Arm1_AnimProgress_Fwd, ref Arm1_AnimProgress_Back
            );

        AnimationUtility.UpdateAnimationProgress(
            animator, 1, ANIMS_ARM3_FORWARD, ANIMS_ARM3_BACKWARD, ref Arm3_AnimProgress_Fwd, ref Arm3_AnimProgress_Back
            );

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("SpeedMult0", 1);
            AnimationUtility.ChangeAnimatorState(animator, ANIMS_ARM1_FORWARD ,0, Arm1_AnimProgress_Fwd);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("SpeedMult0", 1);
            AnimationUtility.ChangeAnimatorState(animator, ANIMS_ARM1_BACKWARD, 0, Arm1_AnimProgress_Back);

        }

        if (Input.GetKey(KeyCode.Q))
        {
            animator.SetFloat("SpeedMult1", 1);
            AnimationUtility.ChangeAnimatorState(animator, ANIMS_ARM3_FORWARD, 1, Arm3_AnimProgress_Fwd);
        }

        if (Input.GetKey(KeyCode.E))
        {
            animator.SetFloat("SpeedMult1", 1);
            AnimationUtility.ChangeAnimatorState(animator, ANIMS_ARM3_BACKWARD, 1, Arm3_AnimProgress_Back);

        }




        //Freeze the animation when a key is released
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            animator.SetFloat("SpeedMult0", 0);
            animator.SetFloat("SpeedMult1", 0);

        }

    }

}


public struct AnimationParams
{
    public string fwdAnim;
    public string backAnim;

    public float fwdAnimtime;
    public float backAnimTime;
}
