using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class ParallaxTest : MonoBehaviour
{
    public Transform[] groundsTransforms;
    public Transform sunTransform;
    Vector2 sunStartingPosition;
    public Transform[] cloudTransforms;

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
    Vector2[] parallaxStartingPositionsForSky = new Vector2[3];
    public float speedingParallax;
    int counter;
    int counterForSky;
    Vector2[] targetsForSky = new Vector2[3];
    Vector2 targetForSun;

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

        cloudTransforms[0] = Instantiate(cloudTransforms[1]);
        cloudTransforms[0].position = new Vector2(cloudTransforms[1].position.x - 16f, cloudTransforms[1].position.y);

        cloudTransforms[2] = Instantiate(cloudTransforms[1]);
        cloudTransforms[2].position = new Vector2(cloudTransforms[1].position.x + 16f, cloudTransforms[1].position.y);


        for (int i = 0; i < groundsTransforms.Length; i++)
        {
            parallaxStartingPositions[i] = groundsTransforms[i].position;

        }
        for (int i = 0; i < groundsTransforms.Length; i++)
        {
            parallaxStartingPositionsForSky[i] = cloudTransforms[i].position;

        }

        sunStartingPosition = sunTransform.position;


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
        //}

    

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




        ReproductionOfParallax();

        GroundParallaxTranform();



    }



    void GroundParallaxTranform()
    {
        for (int i = 0; i < 3; i++)
        {
            targetsForGround[i] = parallaxStartingPositions[i] + (cameraTotalDisplacement / 2f);

        }

        for (int i = 0; i < 3; i++)
        {
            targetsForSky[i] = parallaxStartingPositionsForSky[i] + (cameraTotalDisplacement * 9f / 10f);

        }

        if (Mathf.Abs(targetsForGround[2].x - groundsTransforms[2].position.x) > 1 / 32f)
        {


            groundsTransforms[2].position = Vector2.Lerp(groundsTransforms[2].position, targetsForGround[2], Time.deltaTime * 20);
            groundsTransforms[0].position = Vector2.Lerp(groundsTransforms[0].position, targetsForGround[0], Time.deltaTime * 20);
            groundsTransforms[1].position = Vector2.Lerp(groundsTransforms[1].position, targetsForGround[1], Time.deltaTime * 20);

        }

        if (Mathf.Abs(targetsForSky[2].x - cloudTransforms[2].position.x) > 1 / 32f)
        {


            cloudTransforms[2].position = Vector2.Lerp(cloudTransforms[2].position, targetsForSky[2], Time.deltaTime * 20);
            cloudTransforms[0].position = Vector2.Lerp(cloudTransforms[0].position, targetsForSky[0], Time.deltaTime * 20);
            cloudTransforms[1].position = Vector2.Lerp(cloudTransforms[1].position, targetsForSky[1], Time.deltaTime * 20);

        }

        targetForSun = sunStartingPosition + cameraTotalDisplacement;

        if (Mathf.Abs(targetForSun.x - sunTransform.position.x) > 1 / 128f)
        {

            sunTransform.position = Vector2.Lerp(sunTransform.position, targetForSun, Time.deltaTime * 20);            

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



        if (this.transform.position.x > (groundsTransforms[(counter + 1) % 3].position.x + 8f))
        {
            parallaxStartingPositions[(counter % 3)].x += 48f;

            targetsForGround[counter % 3] = parallaxStartingPositions[counter % 3] + (cameraTotalDisplacement / 2f);

            groundsTransforms[counter % 3].position = Vector2.Lerp(groundsTransforms[counter % 3].position, targetsForGround[counter % 3], 1);

            counter++;
        }




        else if (this.transform.position.x < (groundsTransforms[(counter + 1) % 3].position.x - 8f))
        {
            parallaxStartingPositions[((counter + 2) % 3)].x -= 48f;

            targetsForGround[((counter + 2) % 3)] = parallaxStartingPositions[((counter + 2) % 3)] + (cameraTotalDisplacement / 2f);

            groundsTransforms[((counter + 2) % 3)].position = Vector2.Lerp(groundsTransforms[((counter + 2) % 3)].position, targetsForGround[((counter + 2) % 3)], 1);

            counter--;
        }





        if (this.transform.position.x > (cloudTransforms[(counterForSky + 1) % 3].position.x + 8f))
        {
            parallaxStartingPositionsForSky[(counterForSky % 3)].x += 48f;

            targetsForSky[counterForSky % 3] = parallaxStartingPositionsForSky[counterForSky % 3] + (cameraTotalDisplacement / 2f);

            cloudTransforms[counterForSky % 3].position =  targetsForSky[counterForSky % 3];

            counterForSky++;
        }




        else if (this.transform.position.x < (cloudTransforms[(counterForSky + 1) % 3].position.x - 8f))
        {
            parallaxStartingPositionsForSky[((counterForSky + 2) % 3)].x -= 48f;

            targetsForSky[((counterForSky + 2) % 3)] = parallaxStartingPositionsForSky[((counterForSky + 2) % 3)] + (cameraTotalDisplacement / 2f);

            cloudTransforms[((counterForSky + 2) % 3)].position = targetsForSky[((counter + 2) % 3)];

            counterForSky--;
        }

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
