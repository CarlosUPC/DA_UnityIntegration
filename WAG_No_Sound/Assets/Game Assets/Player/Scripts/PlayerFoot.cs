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
    //public AK.Wwise.Event FootstepSound;

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
        SoundMaterial.Materials mat = materialChecker.CheckMaterial(gameObject);

        AudioClip[] tmp = GetAudioBankFromMaterialSound(mat);
        
        AudioSource source = GetComponent<AudioSource>();
        //source.clip = RandomizeFootstepSound(tmp);
        source.PlayOneShot(RandomizeFootstepSound(tmp), 1.0f * PlayerManager.Instance.player.GetComponent<PlayerMovement>().runAmount);

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

    public AudioClip RandomizeFootstepSound(AudioClip[] soundBank)
    {
       // AudioClip[] soundBank;
        //soundBank = GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().dirtWalk;

        int clip = Random.Range(0, soundBank.Length);
        return soundBank[clip];
    }

    public AudioClip[] GetAudioBankFromMaterialSound(SoundMaterial.Materials mat)
    {
        //AudioClip[] audio;
        List<AudioClip[]> audio = new List<AudioClip[]>();


        switch (mat)
        {
            case SoundMaterial.Materials.DIRT:
                if (PlayerIsSprinting())
                   audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().dirtRun);
                else
                   audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().dirtWalk);
                break;
            case SoundMaterial.Materials.GRASS:
                if (PlayerIsSprinting())
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().grassRun);
                else
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().grassWalk);
                break;
            case SoundMaterial.Materials.RUBBLE:
                if (PlayerIsSprinting())
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().rubbleRun);
                else
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().rubbleWalk);
                break;
            case SoundMaterial.Materials.SAND:
                if (PlayerIsSprinting())
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().sandRun);
                else
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().sandWalk);
                break;
            case SoundMaterial.Materials.STONE:
                if (PlayerIsSprinting())
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().stoneRun);
                else
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().stoneWalk);
                break;
            case SoundMaterial.Materials.WATER:
                if (PlayerIsSprinting())
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().waterRun);
                else
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().waterWalk);
                break;
            case SoundMaterial.Materials.WOOD:
                if (PlayerIsSprinting())
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().woodRun);
                else
                    audio.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<AdventuressAnimationEventHandler>().woodWalk);
                break;
        }

        return audio[0];
    }

    private bool PlayerIsRunning()
    {
        return PlayerManager.Instance.player.GetComponent<PlayerMovement>().runAmount > 0.5f;
    }

    private bool PlayerIsSprinting()
    {
        return PlayerManager.Instance.isSprinting;
    }

}
