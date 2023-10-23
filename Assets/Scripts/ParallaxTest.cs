using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class ParallaxTest : MonoBehaviour
{
    public Transform[] objects;
    Transform cameraTransform;
    float latestTransformPositionX;
    float latestTransformPositionY;
    float differenceTransformPositionX;
    float differenceTransformPositionY;
    int counter = 0;

    void Start()
    {
        cameraTransform = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {

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

        MovingParallax();


        if (cameraTransform.position.x - objects[0].position.x  > 0 && counter == 0)
        {
            ReproductionOfParallax();
            counter++;
        }
    }

    private void FixedUpdate()
    {
       
       
    }

    void LateUpdate()
    {
        


    }

    void MovingParallax()
    {
        objects[0].position = new Vector2(objects[0].position.x + (differenceTransformPositionX / 2f),
        objects[0].position.y + (differenceTransformPositionY / 2f));
       
        objects[1].position = new Vector2(objects[1].position.x + (differenceTransformPositionX * 9.5f / 10),
        objects[1].position.y + (differenceTransformPositionY * 9.5f / 10));
       
        objects[2].position = new Vector2(objects[2].position.x + (differenceTransformPositionX),
        objects[2].position.y + (differenceTransformPositionY));
    }

    void ReproductionOfParallax()
    {

        GameObject testing = Instantiate(objects[0].gameObject);
        testing.transform.position = new Vector2(15, 1);
        objects[0] = testing.transform;

    }




}
