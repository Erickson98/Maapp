using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelLoaderControllerV1_1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Arm;
    public GameObject Bucket;

    private Animator Arm_Animator;
    private Animator Bucket_Animator;
    
    
    private Animation Arm_Anim;

    private Transform Arm_Transform;
    private Transform Bucket_Transform;

    public float Arm_AnimationTime_Up;
    public float Arm_AnimationTime_Down;
    public float Bucket_AnimationTime_Up;
    public float Bucket_AnimationTime_Down;

    const string ANIMS_ARM_UP = "Arm_MoveUp";
    const string ANIMS_ARM_DOWN = "Arm_MoveDown";
    const string ANIMS_ARM_IDLE = "Arm_Idle";

    const string ANIMS_BUCKET_UP = "Bucket_MoveUp"; 
    const string ANIMS_BUCKET_DOWN = "Bucket_MoveDown";

    const float ARM_ROT_UPLIMIT = 344f;
    const float ARM_ROT_DOWNLIMIT = 284f;

    const float BUCKET_ROT_UPLIMIT = -10f;

    public string monitor;
    void Start()
    {
        Arm_Animator = Arm.GetComponent<Animator>();
        Bucket_Animator = Bucket.GetComponent<Animator>();
        Arm_Transform = Arm.GetComponent<Transform>();
        Arm_Anim = Arm.GetComponent<Animation>();
        Bucket_Transform = Bucket.GetComponent<Transform>();

        Arm_Animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Arm_Move();
        //monitor = Arm_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private void FixedUpdate()
    {
        
    }

    void Arm_Move()
    {

        AnimationUtility.UpdateAnimationProgress(Arm_Animator, 0, ANIMS_ARM_UP, ANIMS_ARM_DOWN, ref Arm_AnimationTime_Up, ref Arm_AnimationTime_Down);
        AnimationUtility.UpdateAnimationProgress(Bucket_Animator, 0, ANIMS_BUCKET_UP, ANIMS_BUCKET_DOWN, ref Bucket_AnimationTime_Up, ref Bucket_AnimationTime_Down); 


        //Arm
        if (Input.GetKey(KeyCode.W))
        {
            ChangeAnimatorState(Arm_Animator, ANIMS_ARM_UP, Arm_AnimationTime_Up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            ChangeAnimatorState(Arm_Animator, ANIMS_ARM_DOWN, Arm_AnimationTime_Down);
            
        }

        //Bucket
        if (Input.GetKey(KeyCode.Q))
        {
            ChangeAnimatorState(Bucket_Animator, ANIMS_BUCKET_UP, Bucket_AnimationTime_Up);
        }

        if (Input.GetKey(KeyCode.E))
        {
            ChangeAnimatorState(Bucket_Animator, ANIMS_BUCKET_DOWN, Bucket_AnimationTime_Down);

        }


        //Freeze the animation when a key is released
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            
            Arm_Animator.speed = 0f;
            Bucket_Animator.speed = 0f;
        }

        
    }

    void ChangeAnimatorState(Animator animator, string newState,float time)
    {
        animator.speed = 1;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(newState))
        {
            return;
        }
        else
        {
           
            animator.Play(newState, 0, time);

            Debug.Log("Changin to state: " + newState);
            //if (inverted)
            //{
            //    animator.Play(newState, 0, Arm_AnimationTime_Down);
            //} 
            //else
            //{
            //    animator.Play(newState, 0, Arm_AnimationTime_Up);
            //}
                  
        }
    }

   

}
