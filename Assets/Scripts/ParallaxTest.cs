using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class ParallaxTest : MonoBehaviour
{
    public Transform[] groundsTransforms;
    Transform middleGround;
    public Transform playerTransform;
    
    Transform cameraTransform;
    float latestTransformPositionX;
    float latestTransformPositionY;
    float differenceTransformPositionX;
    float differenceTransformPositionY;
    Vector2 cameraStartingPosition;
    Vector2 cameraTotalDisplacement;
    Vector2[] targetsForGround = new Vector2[3];
    Vector2[] parallaxStartingPositions= new Vector2[3];
    public float speedingParallax;
    int counter;
    

    //int counter = 0;
    
    float lastTime;
    float frameTime;
    void Start()
    {
        cameraTransform = this.transform;
        cameraStartingPosition= transform.position;


        groundsTransforms[0]  = Instantiate(groundsTransforms[1]);
        groundsTransforms[0].position = new Vector2(groundsTransforms[1].position.x - 16f, groundsTransforms[1].position.y);

        groundsTransforms[2] = Instantiate(groundsTransforms[1]);
        groundsTransforms[2].position = new Vector2(groundsTransforms[1].position.x + 16f, groundsTransforms[1].position.y);

        for (int i = 0; i < groundsTransforms.Length; i++)
        {
            parallaxStartingPositions[i] = groundsTransforms[i].position;

        }


    }

    // Update is called once per frame
    void Update()
    {

        

        //sun.MovePosition(targets[2]);

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
        //if (playerTransform.position.x - (objects[0].position.x + 2)  > 0 && counter == 0)
        //{
         //   ReproductionOfParallax();
          //  counter++;
        //<}

    

    }

    void FixedUpdate()
    {
        /*if (latestTransformPositionX != cameraTransform.position.x || latestTransformPositionY != cameraTransform.position.y)
        {
            differenceTransformPositionX = cameraTransform.position.x - latestTransformPositionX;
            differenceTransformPositionY = cameraTransform.position.y - latestTransformPositionY;




            latestTransformPositionX = cameraTransform.position.x;
            latestTransformPositionY = cameraTransform.position.y;
        }

        else
        {
            differenceTransformPositionX = 0;
            differenceTransformPositionY = 0;
        }
        */
        
        //objects[2].position = Vector2.Lerp(objects[2].position, targets[2], 1 );
        //sun.velocity = (targets[2] - (Vector2)sun.gameObject.transform.position)/ Time.fixedDeltaTime;
        //sun.MovePosition(new Vector2(sun.gameObject.transform.position.x + (differenceTransformPositionX),
        //sun.gameObject.transform.position.y + (differenceTransformPositionY) ));

       


    }


    void LateUpdate()
    {
        // StartCoroutine(InterpolatingParallaxMovement(25));
        /*if (latestTransformPositionX != cameraTransform.position.x || latestTransformPositionY != cameraTransform.position.y)
        {
            differenceTransformPositionX = cameraTransform.position.x - latestTransformPositionX;
            differenceTransformPositionY = cameraTransform.position.y - latestTransformPositionY;




            latestTransformPositionX = cameraTransform.position.x;
            latestTransformPositionY = cameraTransform.position.y;
        }

        else
        {
            differenceTransformPositionX = 0;
            differenceTransformPositionY = 0;
        }*/


        //objects[2].position = Vector2.Lerp(objects[2].position, targets[2], 1 );

        /*   objects[0].position = new Vector2(objects[0].position.x + ((differenceTransformPositionX / 2f)),
        objects[0].position.y + ((differenceTransformPositionY / 2f)));

                objects[1].position = new Vector2(objects[1].position.x + ((differenceTransformPositionX * 9.5f / 10)),
             objects[1].position.y + ((differenceTransformPositionY * 9.5f / 10) ));
        */




        //objects[2].position = new Vector2(objects[2].position.x + ((differenceTransformPositionX) ),
        //objects[2].position.y + ((differenceTransformPositionY)));
        middleGround = groundsTransforms[1];

        cameraTotalDisplacement = (Vector2)transform.position - cameraStartingPosition;

        //for (int i = 0; i < objects.Length; i++)
        //{
        //targets[2] = parallaxStartingPositions[2] + cameraTotalDisplacement;

        //targets[1] = parallaxStartingPositions[1] + (cameraTotalDisplacement * 9f / 10);
        //}


        /*if (Mathf.Abs(targets[2].x - objects[2].position.x) > 1 / 17f)
        {


            objects[2].position = Vector2.Lerp(objects[2].position , targets[2],  Time.deltaTime * 20);            
            objects[0].position = Vector2.Lerp(objects[0].position, targets[0], Time.deltaTime * 20);
            objects[1].position = Vector2.Lerp(objects[1].position, targets[1], Time.deltaTime * 20);

        }*/


        

        if (this.transform.position.x > (groundsTransforms[1].position.x + 8f))
        {
            Transform spare;
            Vector2 spare2, spare3;
            
            spare = groundsTransforms[0];
            spare2 = parallaxStartingPositions[1];
            groundsTransforms[1] = groundsTransforms[2];
            parallaxStartingPositions[1] = parallaxStartingPositions[2];
            spare3 = parallaxStartingPositions[0];
            parallaxStartingPositions[0] = spare2;
            groundsTransforms[0] = middleGround;
            groundsTransforms[2] = spare;
            parallaxStartingPositions[2] = spare3;
            
            parallaxStartingPositions[2].x += 48f;

            for (int i = 0; i < 3; i++)
            {
                targetsForGround[i] = parallaxStartingPositions[i] + (cameraTotalDisplacement / 2f);
            }

            groundsTransforms[2].position = Vector2.Lerp(groundsTransforms[2].position, targetsForGround[2], 1);
            
        }
            

        else if(this.transform.position.x < (groundsTransforms[1].position.x - 8f))
        {
            Transform spare;
            Vector2 spare2, spare3;

            spare = groundsTransforms[2];
            spare2 = parallaxStartingPositions[1];
            groundsTransforms[1] = groundsTransforms[0];
            parallaxStartingPositions[1] = parallaxStartingPositions[0];
            spare3 = parallaxStartingPositions[2];
            parallaxStartingPositions[2] = spare2;
            groundsTransforms[2] = middleGround;
            groundsTransforms[0] = spare;
            parallaxStartingPositions[0] = spare3;

            parallaxStartingPositions[0].x -= 48f;

            for (int i = 0; i < 3; i++)
            {
                targetsForGround[i] = parallaxStartingPositions[i] + (cameraTotalDisplacement / 2f);
            }

            groundsTransforms[0].position = Vector2.Lerp(groundsTransforms[0].position, targetsForGround[0], 1);
            

        }

        GroundParallaxTranform();







    }



    void GroundParallaxTranform()
    {
        for (int i = 0; i < 3; i++)
        {
            targetsForGround[i] = parallaxStartingPositions[i] + (cameraTotalDisplacement / 2f);

        }

        if (Mathf.Abs(targetsForGround[2].x - groundsTransforms[2].position.x) > 1 / 32f)
        {


            groundsTransforms[2].position = Vector2.Lerp(groundsTransforms[2].position, targetsForGround[2], Time.deltaTime * 20);
            groundsTransforms[0].position = Vector2.Lerp(groundsTransforms[0].position, targetsForGround[0], Time.deltaTime * 20);
            groundsTransforms[1].position = Vector2.Lerp(groundsTransforms[1].position, targetsForGround[1], Time.deltaTime * 20);

        }
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

/*        objects[0].position = new Vector2(objects[0].position.x + ((differenceTransformPositionX / 2f)/divider),
        objects[0].position.y + ((differenceTransformPositionY / 2f) / divider));

        objects[1].position = new Vector2(objects[1].position.x + ((differenceTransformPositionX * 9.5f / 10)/divider),
        objects[1].position.y + ((differenceTransformPositionY * 9.5f / 10) / divider));

        objects[2].position = new Vector2(objects[2].position.x + ((differenceTransformPositionX)/(float)divider),
        objects[2].position.y + ((differenceTransformPositionY) / (float)divider));
*/
    }

    void ReproductionOfParallax()
    {
/*
        float direction = Mathf.Sign(playerTransform.localScale.x);
        GameObject testing = Instantiate(objects[0].gameObject);
        testing.transform.position = new Vector2(objects[0].position.x + (direction * 16f), objects[0].position.y);
        
        objects[0] = testing.transform;
*/

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
