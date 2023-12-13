using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject lightAttackObject;
    [SerializeField] GameObject heavyAttackObject;
    Animator playerAnimator;
    PlayerMovement playerMovementScript;

    IEnumerator lightAttackCoroutine;
    IEnumerator heavyAttackCoroutine;
    bool lightAttackCheck = true;
    bool heavyAttackCheck = true;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerMovementScript = GetComponent<PlayerMovement>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLightAttack") && lightAttackCheck)
        {
            lightAttackCoroutine = LightAttack();
            StartCoroutine(lightAttackCoroutine);
            
        }
       
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttackAnimation") && heavyAttackCheck)
        {
            heavyAttackCoroutine = HeavyAttack();
            StartCoroutine(heavyAttackCoroutine);
         
        }
    }


    IEnumerator LightAttack()
    {
        lightAttackCheck = false;
        lightAttackObject.SetActive(true);
        yield return new WaitForSeconds(playerMovementScript.lightAttackDuration);
        lightAttackObject.SetActive(false);
        lightAttackCheck= true;
    }

    IEnumerator HeavyAttack()
    {
        heavyAttackCheck = false;
        heavyAttackObject.SetActive(true);
        yield return new WaitForSeconds(playerMovementScript.heavyAttackDuration);
        heavyAttackObject.SetActive(false);
        heavyAttackCheck= true;
    }




}
