using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance { get; private set; }

    public Sound[] sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }

        foreach(Sound s in sounds)
        {
            s.source = new AudioSource();
            s.source.clip = s.audio;
            s.source.volume = s.volume;
        }


    }

    public void Play(string name, bool isLoop)
    {
        Sound s = Array.Find(sounds, sound =>sound.name==name);
        if (s == null) return;

        if (!s.source.isPlaying)
        {
            s.source.PlayDelayed(s.delaySeconds);
            s.source.loop= isLoop;
        }

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;

        if (s.source.isPlaying)
        {
            s.source.Stop();
        }
    }







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
