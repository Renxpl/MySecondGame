using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator playerAnimator;

    CompositeCollider2D groundCollider;
    BoxCollider2D playerBoxCollider;

    float lastTimeIdle;

    string currentAnimation = "";
    string idleAnim = "Idle";
    string ordinaryStance = "OrdinaryStance";
    string walkingAnim = "WalkingTest";
    string runningAnim = "Running";
    string lightAttackAnim = "PlayerLightAttack";
    string heavyAttackAnim = "HeavyAttackAnimation";
    string jumpingUpAnim = "JumpingUP";
    string jumpingDownAnim = "JumpingDown";

    bool isIdling = false;
    bool isWalking = false;
    bool isRunning = false;
    bool isLightAttacking = false;
    bool isHeavyAttacking = false;
    bool isJumpingUp = false;
    bool isJumpingDown = false;

    Vector2 moveInput;
    Rigidbody2D myRb;

    [Header("Animation and Movement variables")]
    [SerializeField]float walkingSpeed;
    [SerializeField] float runningSpeed;
    [SerializeField] float walkingAndRunningTransitionLimit = 0.725f;
    [SerializeField] float leftStickThreshold = 0.2f;
    public float lightAttackDuration = 0.3f;
    public float heavyAttackDuration = 0.3f;
    [SerializeField] float jumpSpeed = 10f;

    Coroutine idleAnimCoroutine;

    //Assigning to variables
    void Start()
    {
        playerAnimator= GetComponent<Animator>();
        lastTimeIdle= Time.time;
        myRb= GetComponent<Rigidbody2D>();
        groundCollider = FindAnyObjectByType<CompositeCollider2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {    
        SpriteChangesInAction();
    }

    void FixedUpdate()
    {
        WalkingAndRunningHandle();
    }
    void LateUpdate()
    {
        AnimationHandle();

    }

    
    //OnMove is Input System's function to use input
    void OnMove(InputValue input) 
    {
        moveInput = input.Get<Vector2>();
        Debug.Log("MoveInput Debug Display " + moveInput);
    }

    void OnFire(InputValue input)
    {
        if (!isJumpingDown && !isJumpingUp)
        {
            isLightAttacking = true;
            StartCoroutine(LightAttacking());
        }
    }

    void OnHeavyAttack()
    {
        if (!isJumpingDown && !isJumpingUp)
        {
            isHeavyAttacking = true;
            StartCoroutine(HeavyAttacking());
        }
    }

    void OnJump()
    {
        Jump();

    }

    void Jump()
    {

        if (playerBoxCollider.IsTouching(groundCollider))
        {
            myRb.velocity = new Vector2(myRb.velocity.x, jumpSpeed);


        }

    }

    //In this method i do two things, first walk or run character based on moveInput,
    //second show the proper animation based on current movement(walking or running)
    void WalkingAndRunningHandle()
    {

        //Standing
        if (Mathf.Abs(moveInput.x) <= leftStickThreshold)
        {
            isRunning = false;
            isWalking = false;
        }

        //Walking
        else if (Mathf.Abs(moveInput.x) < walkingAndRunningTransitionLimit)
        {
            
            myRb.velocity = new Vector2(Mathf.Sign(moveInput.x) * walkingSpeed, myRb.velocity.y);

            isWalking = true;
            isRunning= false;
 
        }

        //Running
        else
        {
            myRb.velocity = new Vector2(Mathf.Sign(moveInput.x) * runningSpeed, myRb.velocity.y);

            isWalking = false;
            isRunning = true;

        }
    
    }

    //Simply for managing sprite direction based on velocity
    void SpriteChangesInAction()
    {
        if(myRb.velocity.x > 0.0001f)
        {
            transform.localScale = new Vector2(0.6f , 0.6f);
        }
        else if (myRb.velocity.x < -0.0001f)
        {
            transform.localScale = new Vector2(-0.6f, 0.6f);
        }
        if(myRb.velocity.y > 0.0001f)
        {
            isJumpingUp = true;
            isJumpingDown= false;
        }
        else if(myRb.velocity.y < -0.0001f)
        {
            isJumpingUp = false;
            isJumpingDown= true;
        }
        else { isJumpingUp = false;  isJumpingDown = false; }

    }

    //With this method and one below, i do control animation transitions by script itself,
    //because it is a bit excessive to use unity built-in system for what my game requires.
    void AnimationHandle()
    {
        if (isJumpingUp)
        {
            ChangeAnimationState(jumpingUpAnim);
            IdlingCounter(false);
        }
        else if (isJumpingDown)
        {
            ChangeAnimationState(jumpingDownAnim);
            IdlingCounter(false);
        }
        else if (isHeavyAttacking)
        {
            ChangeAnimationState(heavyAttackAnim);
            IdlingCounter(false);
        }
        else if (isLightAttacking)
        {
            ChangeAnimationState(lightAttackAnim);
            IdlingCounter(false);
        }
        else if (isRunning)
        {
            ChangeAnimationState(runningAnim);
            IdlingCounter(false);
        }
        else if (isWalking)
        {
            ChangeAnimationState(walkingAnim);
            IdlingCounter(false);
        }
        else if (isIdling)
        {
            ChangeAnimationState(idleAnim);
            
        }
        else
        {
            ChangeAnimationState(ordinaryStance);
            IdlingCounter(true);
        }
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        currentAnimation = newAnimation;

        playerAnimator.Play(currentAnimation);
        
    }

    //With this method and one below, i do count the time passed after standing still and 
    //animate character for idle animation if a certain time passed 
    void IdlingCounter(bool isComingFromOrdinaryStanceAnim)
    {
        if (!isComingFromOrdinaryStanceAnim)
        {
            lastTimeIdle = Time.time;
            if (isIdling) { StopCoroutine(idleAnimCoroutine); isIdling = false;}//to prevent possible bug can occur due to animation transition
        }

        else if (Time.time - lastTimeIdle >= 5f)
        {
            lastTimeIdle = Time.time;
            idleAnimCoroutine = StartCoroutine(IdlingTimePeriod());

        }

    }
    IEnumerator IdlingTimePeriod()
    {
        isIdling = true;
        yield return new WaitForSeconds(1.2f);
        isIdling = false;
    }


    IEnumerator LightAttacking()
    {
        yield return new WaitForSeconds(lightAttackDuration);
        isLightAttacking= false;
    }
    IEnumerator HeavyAttacking()
    {
        yield return new WaitForSeconds(heavyAttackDuration);
        isHeavyAttacking = false;
    }


}
