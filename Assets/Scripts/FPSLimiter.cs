using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{

    [SerializeField] int limit = 10;
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate= limit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
