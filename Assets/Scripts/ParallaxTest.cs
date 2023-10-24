using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParallaxTest : MonoBehaviour
{
    public Transform[] objects;
    Transform cameraTransform;
    float latestTransformPositionX;
    float latestTransformPositionY;
    float differenceTransformPositionX;
    float differenceTransformPositionY;
    //int counter = 0;
    float lastTime;
    float frameTime;
    void Start()
    {
        cameraTransform = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        frameTime = Time.realtimeSinceStartup - lastTime;


        if(latestTransformPositionX != cameraTransform.position.x || latestTransformPositionY != cameraTransform.position.y)
        {
            differenceTransformPositionX = cameraTransform.position.x - latestTransformPositionX;
            differenceTransformPositionY = cameraTransform.position.y - latestTransformPositionY;


            

            latestTransformPositionX = cameraTransform.position.x;   
            latestTransformPositionY= cameraTransform.position.y;
        }

        else 
        {
            differenceTransformPositionX = 0 ;
            differenceTransformPositionY = 0; 
        }

        

        lastTime = Time.realtimeSinceStartup;
        MovingParallax(1);
        //StartCoroutine(InterpolatingParallaxMovement(5));
        //  if (cameraTransform.position.x - objects[0].position.x  > 0 && counter == 0)
        // {
        //   ReproductionOfParallax();
        // counter++;
        //}
    }

    private void FixedUpdate()
    {
        //StartCoroutine(InterpolatingParallaxMovement(10));

    }

    void LateUpdate()
    {
       

    }

    void MovingParallax(int divider)
    {
        objects[0].position = new Vector2(objects[0].position.x + ((differenceTransformPositionX / 2f)/divider),
        objects[0].position.y + ((differenceTransformPositionY / 2f) / divider));
       
        objects[1].position = new Vector2(objects[1].position.x + ((differenceTransformPositionX * 9.5f / 10)/divider),
        objects[1].position.y + ((differenceTransformPositionY * 9.5f / 10) / divider));
       
        objects[2].position = new Vector2(objects[2].position.x + ((differenceTransformPositionX)/(float)divider),
        objects[2].position.y + ((differenceTransformPositionY) / (float)divider));
    }

    void ReproductionOfParallax()
    {

        GameObject testing = Instantiate(objects[0].gameObject);
        testing.transform.position = new Vector2(15, 1);
        objects[0] = testing.transform;

    }


    IEnumerator InterpolatingParallaxMovement(int divider)
    {

        
        for (int i = 0; i< divider; i++)
        {
            MovingParallax(divider);
            yield return new WaitForSeconds(frameTime / (float)divider);
        }
        

    }

}
