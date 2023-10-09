using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator playerAnimator;

    float lastTimeIdle;

    string currentAnimation = "";
    string idleAnim = "Idle";
    string ordinaryStance = "OrdinaryStance";

    bool isIdling = false;
    void Start()
    {
        playerAnimator= GetComponent<Animator>();
        lastTimeIdle= Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTimeIdle >= 4f)
        {
            lastTimeIdle = Time.time;
            isIdling = true;
            StartCoroutine(IdlingTimeGap());

        }
    }

    void LateUpdate()
    {
        AnimationHandling();
    }

    void AnimationHandling()
    {
        if (isIdling)
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
