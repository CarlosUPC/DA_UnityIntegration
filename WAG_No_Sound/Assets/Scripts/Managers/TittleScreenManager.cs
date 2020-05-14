using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TittleScreenManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio_init;
    [SerializeField]
    private AudioSource audio_loop;

    void Start()
    {
        audio_init.loop = false;
        audio_init.Play();

        audio_loop.loop = true;
        audio_loop.PlayDelayed(audio_init.clip.length);
    }

}
