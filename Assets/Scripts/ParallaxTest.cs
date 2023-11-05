using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        for (int i = 0; i < 3; i += 2)
        {
            groundsTransforms[i] = Instantiate(groundsTransforms[1]);
            groundsTransforms[i].position = new Vector2(groundsTransforms[1].position.x - 16f + (i * 16f), groundsTransforms[1].position.y);

            cloudTransforms[i] = Instantiate(cloudTransforms[1]);
            cloudTransforms[i].position = new Vector2(cloudTransforms[1].position.x - 16f + (i * 16f), cloudTransforms[1].position.y);
        }

        for (int i = 0; i < groundsTransforms.Length; i++)
        {
            parallaxStartingPositions[i] = groundsTransforms[i].position;
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
        //Debug.Log(frameTime);
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

        //ReproductionOfParallax();
        ReproductionOfParallax(cloudTransforms, parallaxStartingPositionsForSky, targetsForSky, 16f ,ref counterForSky, 9 / 10f, cameraTotalDisplacement);
        ReproductionOfParallax(groundsTransforms, parallaxStartingPositions, targetsForGround, 16f, ref counter, 1 / 2f, cameraTotalDisplacement);
        //GroundParallaxTranform();
        ParallaxTransform(sunTransform, sunStartingPosition, targetForSun, cameraTotalDisplacement, 1f, 0f);
        ParallaxTransform(cloudTransforms, parallaxStartingPositionsForSky, targetsForSky, cameraTotalDisplacement, 9f/10f, 1/ 64f, 12f);
        ParallaxTransform(groundsTransforms, parallaxStartingPositions, targetsForGround, cameraTotalDisplacement, 1f / 2f, 1 / 128f, 25f);

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

    void ParallaxTransform(Transform[] parallax, Vector2[] startingPositions, Vector2[] targets, Vector2 cameraDisplacement, float speed, float pixelLimit, float lerpFactor)
    {

        for (int i = 0; i < 3; i++)
        {
            targets[i] = startingPositions[i] + (cameraDisplacement * speed);
        }

        if (Mathf.Abs(targets[2].x - parallax[2].position.x) > pixelLimit)
        {

            parallax[2].position = Vector2.Lerp(parallax[2].position, targets[2], Time.deltaTime * lerpFactor);
            parallax[0].position = Vector2.Lerp(parallax[0].position, targets[0], Time.deltaTime * lerpFactor);
            parallax[1].position = Vector2.Lerp(parallax[1].position, targets[1], Time.deltaTime * lerpFactor);

        }

    }

    void ParallaxTransform(Transform parallax, Vector2 startingPosition, Vector2 target, Vector2 cameraDisplacement, float speed, float pixelLimit)
    {

        target = startingPosition + (cameraDisplacement * speed);

        if (Mathf.Abs(target.x - parallax.position.x) > pixelLimit)
        {
            float number = 0.1f;

            Debug.Log(Mathf.Abs(target.x - parallax.position.x));
           
            if (Mathf.Abs(target.x - parallax.position.x) > (1 / 2)) number = 20;
            else if (Mathf.Abs(target.x - parallax.position.x) > (1 / 4)) number = 12;
            else if (Mathf.Abs(target.x - parallax.position.x) > (1 / 8)) number = 5;
            else if (Mathf.Abs(target.x - parallax.position.x) > (1 / 10)) number = 1;
            else if (Mathf.Abs(target.x - parallax.position.x) > (1 / 48)) number = 0.1f;
            else if (Mathf.Abs(target.x - parallax.position.x) > (1 / 64)) number = 0.1f;

            Vector2 lerpResult = Vector2.Lerp(parallax.position, target, Time.deltaTime * number);
            parallax.position = lerpResult;
            //parallax.position = new Vector2((float)Math.Round(lerpResult.x, 5) , (float)Math.Round(lerpResult.y, 5));
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

   /* void ReproductionOfParallax()
    {
        
               // float direction = Mathf.Sign(playerTransform.localScale.x);
                //GameObject testing = Instantiate(objects[0].gameObject);
                //testing.transform.position = new Vector2(objects[0].position.x + (direction * 16f), objects[0].position.y);

                //objects[0] = testing.transform;
        



        if (this.transform.position.x > (groundsTransforms[(counter + 1) % 3].position.x + 8f))
        {
            parallaxStartingPositions[(counter % 3)].x += 48f;

            Destroy(groundsTransforms[(counter % 3)].gameObject);
            groundsTransforms[(counter % 3)] = Instantiate(groundsTransforms[((counter + 2) % 3)]);
            groundsTransforms[(counter % 3)].position = new Vector2(groundsTransforms[((counter + 2) % 3)].position.x + 16f, groundsTransforms[((counter + 2) % 3)].position.y);

            targetsForGround[counter % 3] = parallaxStartingPositions[counter % 3] + (cameraTotalDisplacement / 2f);

            counter++;
        }




        else if (this.transform.position.x < (groundsTransforms[(counter + 1) % 3].position.x - 8f))
        {
            parallaxStartingPositions[((counter + 2) % 3)].x -= 48f;

            Destroy(groundsTransforms[((counter + 2) % 3)].gameObject);
            groundsTransforms[((counter + 2) % 3)] = Instantiate(groundsTransforms[(counter % 3)]);
            groundsTransforms[((counter + 2) % 3)].position = new Vector2(groundsTransforms[(counter % 3)].position.x - 16f, groundsTransforms[(counter % 3)].position.y);

            targetsForGround[((counter + 2) % 3)] = parallaxStartingPositions[((counter + 2) % 3)] + (cameraTotalDisplacement / 2f);

            counter--;
        }





        if (this.transform.position.x > (cloudTransforms[(counterForSky + 1) % 3].position.x + 8f))
        {
            parallaxStartingPositionsForSky[(counterForSky % 3)].x += 48f;

            Destroy(cloudTransforms[(counterForSky % 3)].gameObject);
            cloudTransforms[(counterForSky % 3)] = Instantiate(cloudTransforms[((counterForSky + 2) % 3)]);
            cloudTransforms[(counterForSky % 3)].position = new Vector2(cloudTransforms[((counterForSky + 2) % 3)].position.x + 16f, cloudTransforms[((counterForSky + 2) % 3)].position.y);

            targetsForSky[counterForSky % 3] = parallaxStartingPositionsForSky[counterForSky % 3] + (cameraTotalDisplacement / 2f);

            counterForSky++;
            
        }

        


        else if (this.transform.position.x < (cloudTransforms[(counterForSky + 1) % 3].position.x - 8f))
        {
            parallaxStartingPositionsForSky[((counterForSky + 2) % 3)].x -= 48f;

            Destroy(cloudTransforms[((counterForSky + 2) % 3)].gameObject);
            cloudTransforms[((counterForSky + 2) % 3)] = Instantiate(cloudTransforms[(counterForSky % 3)]);
            cloudTransforms[((counterForSky + 2) % 3)].position = new Vector2(cloudTransforms[(counterForSky % 3)].position.x - 16f, cloudTransforms[(counterForSky % 3)].position.y);

            targetsForSky[((counterForSky + 2) % 3)] = parallaxStartingPositionsForSky[((counterForSky + 2) % 3)] + (cameraTotalDisplacement / 2f);

            counterForSky--;
        }





    }*/


    void ReproductionOfParallax(Transform[] parallax, Vector2[] startingPositions, Vector2[] targets, float width ,ref int counters, float speed, Vector2 cameraDisplacement)
    {
        
        if (this.transform.position.x > (parallax[(counters + 1) % 3].position.x + (width / 2f)))
        {
            startingPositions[(counters % 3)].x += (3 * width);

            Destroy(parallax[(counters % 3)].gameObject);
            parallax[(counters % 3)] = Instantiate(parallax[((counters + 2) % 3)]);
            parallax[(counters % 3)].position = new Vector2(parallax[((counters + 2) % 3)].position.x + width, parallax[((counters + 2) % 3)].position.y);

            targets[counters % 3] = startingPositions[counters % 3] + (cameraDisplacement * speed);

            counters++;

        }




        else if (this.transform.position.x < (parallax[(counters + 1) % 3].position.x - (width / 2f)))
        {
            startingPositions[((counters + 2) % 3)].x -= (3 * width);

            Destroy(parallax[((counters + 2) % 3)].gameObject);
            parallax[((counters + 2) % 3)] = Instantiate(parallax[(counters % 3)]);
            parallax[((counters + 2) % 3)].position = new Vector2(parallax[(counters % 3)].position.x - width, parallax[(counters % 3)].position.y);

            targets[((counters + 2) % 3)] = startingPositions[((counters + 2) % 3)] + (cameraDisplacement * speed);

            counters--;
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
