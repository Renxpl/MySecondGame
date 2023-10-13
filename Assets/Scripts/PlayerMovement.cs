using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator playerAnimator;

    float lastTimeIdle;

    string currentAnimation = "";
    string idleAnim = "Idle";
    string ordinaryStance = "OrdinaryStance";
    string walkingAnim = "WalkingTest";

    bool isIdling = false;
    bool isWalking = false;
    bool isRunning = false;

    
    Vector2 moveInput;
    Rigidbody2D myRb;

    [Header("Animation and Movement variables")]
    [SerializeField]float walkingSpeed;
    [SerializeField] float runningSpeed;
    [SerializeField] float walkingAndRunningTransitionLimit = 0.725f;
    [SerializeField] float leftStickSensitivity = 0.2f;

    //Assigning to variables
    void Start()
    {
        playerAnimator= GetComponent<Animator>();
        lastTimeIdle= Time.time;
        myRb= GetComponent<Rigidbody2D>();
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

    
    //OnMove is Input System's function to be able to use input
    void OnMove(InputValue input) 
    {
        moveInput = input.Get<Vector2>();
        Debug.Log(moveInput);
    }

    //In this method i do two things, first walk or run character based on moveInput,
    //second show the appropriate animation based on current movement(walking or running)
    void WalkingAndRunningHandle()
    {

        //Standing
        if (Mathf.Abs(moveInput.x) <= leftStickSensitivity)
        {
            isRunning = false;
            isWalking = false;
        }

        //Walking
        else if (Mathf.Abs(moveInput.x) < walkingAndRunningTransitionLimit)
        {
            
            myRb.velocity = new Vector2(Mathf.Sign(moveInput.x) * 0.3f * walkingSpeed, myRb.velocity.y);

            isWalking = true;
            isRunning= false;
 
        }

        //Running
        else
        {
            myRb.velocity = new Vector2(Mathf.Sign(moveInput.x) * 0.8f * walkingSpeed, myRb.velocity.y);

            isWalking = false;
            isRunning = true;

        }
    
    }

    //Simply for managing sprite direction based on velocity
    void SpriteChangesInAction()
    {
        if(myRb.velocity.x > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(0.6f , 0.6f);
        }
        if (myRb.velocity.x < -Mathf.Epsilon)
        {
            transform.localScale = new Vector2(-0.6f, 0.6f);
        }

    }

    //With this method and one below, i do control animation transitions by script itself,
    //because it is a bit excessive to use unity built-in system in 2D game development.
    void AnimationHandle()
    {
        if (isRunning)
        {
            //will be implemented later
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
            IdlingCounter(false);
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
    //animate character for idle if a certain time passed 
    void IdlingCounter(bool isComingFromOrdinaryStanceAnim)
    {
        if (!isComingFromOrdinaryStanceAnim)
        {
            lastTimeIdle = Time.time;
        }

        else if (Time.time - lastTimeIdle >= 4f)
        {
            lastTimeIdle = Time.time;
            StartCoroutine(IdlingTimePeriod());

        }

    }
    IEnumerator IdlingTimePeriod()
    {
        isIdling = true;
        yield return new WaitForSeconds(2f);
        isIdling = false;
    }

}