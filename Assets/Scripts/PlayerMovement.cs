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


    Vector2 moveInput;
    Rigidbody2D myRb;
    [SerializeField]float walkingSpeed;
    void Start()
    {
        playerAnimator= GetComponent<Animator>();
        lastTimeIdle= Time.time;
        myRb= GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        if (Time.time - lastTimeIdle >= 4f)
        {
            lastTimeIdle = Time.time;
            isIdling = true;
            StartCoroutine(IdlingTimeGap());

        }

        SpriteChangesInAction();
    }

    void FixedUpdate()
    {
        Walk();
    }
    void LateUpdate()
    {
        AnimationHandling();
    }


    void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }


    void Walk()
    {
        myRb.velocity = new Vector2(moveInput.x * walkingSpeed, myRb.velocity.y);

        if(Mathf.Abs(myRb.velocity.x)>  0) isWalking = true;      
        else isWalking = false;
        
    }

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

    void AnimationHandling()
    {
        if (isWalking)
        {
            ChangeAnimationState(walkingAnim);
        }
        else if (isIdling)
        {
            ChangeAnimationState(idleAnim);       
        }
        else
        {
            ChangeAnimationState(ordinaryStance);
        }
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        currentAnimation = newAnimation;

        playerAnimator.Play(currentAnimation);
        
    }

    IEnumerator IdlingTimeGap()
    {

        yield return new WaitForSeconds(2f);
        isIdling= false;
    }



}
