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
    Vector2 cameraStartingPosition;
    Vector2 cameraTotalDisplacement;
    Vector2[] targets = new Vector2[3];
    Vector2[] parallaxStartingPositions= new Vector2[3];
    public float speedingParallax;

    //int counter = 0;
    
    float lastTime;
    float frameTime;
    void Start()
    {
        cameraTransform = this.transform;
        cameraStartingPosition= transform.position;

        for(int i = 0; i < objects.Length; i++)
        {
            parallaxStartingPositions[i] = objects[i].position;

        }




    }

    // Update is called once per frame
    void Update()
    {

        cameraTotalDisplacement = (Vector2)transform.position - cameraStartingPosition;

        for (int i = 0; i < objects.Length; i++)
        {
            targets[i] = parallaxStartingPositions[i] + cameraTotalDisplacement;

        }
        objects[2].position = Vector2.Lerp(objects[2].position, targets[2], Time.deltaTime);


        //frameTime = Time.realtimeSinceStartup - lastTime;





        /*if(latestTransformPositionX != cameraTransform.position.x || latestTransformPositionY != cameraTransform.position.y)
        {
            differenceTransformPositionX = cameraTransform.position.x - latestTransformPositionX;
            differenceTransformPositionY = cameraTransform.position.y - latestTransformPositionY;


            

            latestTransformPositionX = cameraTransform.position.x;   
            latestTransformPositionY= cameraTransform.position.y;
        }

        else 
        {
            differenceTransformPositionX = 0;
            differenceTransformPositionY = 0; 
        }*/



        //lastTime = Time.realtimeSinceStartup;
        frameTime = 1 / Time.deltaTime;
        Debug.Log(frameTime);
        //MovingParallax(1);
        //StartCoroutine(InterpolatingParallaxMovement(10));
        //  if (cameraTransform.position.x - objects[0].position.x  > 0 && counter == 0)
        // {
        //   ReproductionOfParallax();
        // counter++;
        //}
        


    }

    private void FixedUpdate()
    {
      
    }

    void LateUpdate()
    {
        // StartCoroutine(InterpolatingParallaxMovement(25));
        
    }

    void MovingParallax(int divider)
    {

        //Vector2 target0 = new Vector2(objects[0].position.x + (differenceTransformPositionX / 2f) ,
        //objects[0].position.y + (differenceTransformPositionY / 2f) );

        //Vector2 target1 = new Vector2(objects[1].position.x + (differenceTransformPositionX * 9.5f / 10) ,
        //objects[1].position.y + (differenceTransformPositionY * 9.5f / 10));

        //Vector2 target2 = new Vector2(objects[2].position.x + (differenceTransformPositionX),
        //objects[2].position.y + (differenceTransformPositionY) );


        //objects[0].position = Vector2.Lerp(objects[0].position, target0, Time.deltaTime);
        //objects[1].position = Vector2.Lerp(objects[1].position, target1, Time.deltaTime);
        //objects[2].position = Vector2.Lerp(objects[2].position, target2, Time.deltaTime);

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
            yield return new WaitForSeconds(Time.deltaTime / divider);
           
        }
        

    }

}
