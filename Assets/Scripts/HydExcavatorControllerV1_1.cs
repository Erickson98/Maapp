using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HydExcavatorControllerV1_1 : MonoBehaviour
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

    AnimationHandler animHandler_Arm1;
    AnimationHandler animHandler_Arm3;

    public delegate void ArmMovement();

    public event ArmMovement OnArm1Forward;
    public event ArmMovement OnArm1Backward;
    public event ArmMovement OnArm1NoMove;

    public event ArmMovement OnArm3Forward;
    public event ArmMovement OnArm3Backward;
    public event ArmMovement OnArm3NoMove;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        animator.speed = 1;

        animHandler_Arm1 = new AnimationHandler(animator, ANIMS_ARM1_FORWARD, ANIMS_ARM1_BACKWARD, 0);
        OnArm1Forward += animHandler_Arm1.MoveForward;
        OnArm1Backward += animHandler_Arm1.MoveBackward;
        OnArm1NoMove += animHandler_Arm1.NoMove;

        animHandler_Arm3 = new AnimationHandler(animator, ANIMS_ARM3_FORWARD, ANIMS_ARM3_BACKWARD, 1);
        OnArm3Forward += animHandler_Arm3.MoveForward;
        OnArm3Backward += animHandler_Arm3.MoveBackward;
        OnArm3NoMove += animHandler_Arm3.NoMove;
    }

    // Update is called once per frame
    void Update()
    {
        animHandler_Arm1.UpdateHandler();
        animHandler_Arm3.UpdateHandler();

        if (Input.GetKey(KeyCode.W))
        {
            OnArm1Forward();
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            OnArm1Backward();
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            OnArm3Forward();
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            OnArm3Backward();
        }


        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            OnArm1NoMove();
            OnArm3NoMove();
        }
    }



}