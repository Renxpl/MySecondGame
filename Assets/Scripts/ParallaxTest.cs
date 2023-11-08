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

        

        
        frameTime = 1 / Time.deltaTime;
        

    

    }

    void LateUpdate()
    {

        cameraTotalDisplacement = (Vector2)transform.position - cameraStartingPosition;
     
        ReproductionOfParallax(cloudTransforms, parallaxStartingPositionsForSky, targetsForSky, 16f ,ref counterForSky, 9 / 10f, cameraTotalDisplacement);
        ReproductionOfParallax(groundsTransforms, parallaxStartingPositions, targetsForGround, 16f, ref counter, 1 / 2f, cameraTotalDisplacement);
      
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


    void ReproductionOfParallax(Transform[] parallax, Vector2[] startingPositions, Vector2[] targets, float width ,ref int counters, float speed, Vector2 cameraDisplacement)
    {

        int leftOne = counters % 3;
        int middleOne = (counters + 1) % 3;
        int rightOne = (counters + 2) % 3;



        if (this.transform.position.x > (parallax[middleOne].position.x + (width / 2f)))
        {
            startingPositions[leftOne].x += (3 * width);

            Destroy(parallax[leftOne].gameObject);
            parallax[leftOne] = Instantiate(parallax[rightOne]);
            parallax[leftOne].position = new Vector2(parallax[rightOne].position.x + width, parallax[rightOne].position.y);

            targets[leftOne] = startingPositions[leftOne] + (cameraDisplacement * speed);

            counters++;

        }




        else if (this.transform.position.x < (parallax[middleOne].position.x - (width / 2f)))
        {
            startingPositions[rightOne].x -= (3 * width);

            Destroy(parallax[rightOne].gameObject);
            parallax[rightOne] = Instantiate(parallax[leftOne]);
            parallax[rightOne].position = new Vector2(parallax[leftOne].position.x - width, parallax[leftOne].position.y);

            targets[rightOne] = startingPositions[rightOne] + (cameraDisplacement * speed);

            counters--;
        }


    }

}
