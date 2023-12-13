using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDummy : MonoBehaviour
{
    SpriteRenderer dummySprite;
    [SerializeField] Collider2D lightAttackHitbox;
    [SerializeField] Collider2D heavyAttackHitbox;
    IEnumerator turningToRed;
    Color originalColor;
    void Start()
    {
        dummySprite= GetComponent<SpriteRenderer>();
        originalColor = dummySprite.color;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider == lightAttackHitbox || collider == heavyAttackHitbox)
        {
            turningToRed = TurnTheColor();
            StartCoroutine(turningToRed);
            

        }

    }

    IEnumerator TurnTheColor()
    {
        
        dummySprite.color = Color.red;

        yield return new WaitForSeconds(1);

        dummySprite.color = originalColor;  
    }


}
