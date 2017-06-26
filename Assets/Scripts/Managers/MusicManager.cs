using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioSource backMusic;
    public AudioClip sneak;
    public AudioClip alarmMusic;
    bool songSwitch = true;

    void Awake()
    {
        backMusic = GetComponent<AudioSource>();
        backMusic.clip = sneak;
        backMusic.Play();
    }

    void Update()
    {
        if (SquadManger.alarmSounded)

        {
            if (songSwitch)
            {
                backMusic.clip = alarmMusic;
                backMusic.Play();
                songSwitch = false;
            }
      
        }
    }






}
