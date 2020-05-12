////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    public MaterialChecker materialChecker;
    public AK.Wwise.Event FootstepSound;

    #region private variables
    private bool inWater;
    #endregion

    public void PlayFootstepSound()
    {
        //if (!inWater)
        //{
        //    materialChecker.CheckMaterial(gameObject); //This also sets the material if a SoundMaterial is found!
        //}

        //FootstepSound.Post(gameObject);

        AudioSource source = GetComponent<AudioSource>();
        source.clip = RandomizeFootstepSound();
        source.Play();

        //source.PlayOneShot(RandomizeFootstepSound());

       
    }

    public void EnterWaterZone()
    {
        inWater = true;
    }

    public void ExitWaterZone()
    {
        inWater = false;
    }

    public AudioClip RandomizeFootstepSound()
    {
        AudioClip[] soundBank;
        soundBank = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().dirtWalk;

        int clip = Random.Range(0, soundBank.Length);
        return soundBank[clip];
    }

}
