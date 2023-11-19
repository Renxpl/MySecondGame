using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound : MonoBehaviour
{
    public string name;
    public float delaySeconds;
    public AudioClip audio;
    [Range(0f, 1f)]
    public float volume;
    [HideInInspector]
    public AudioSource source;



}
