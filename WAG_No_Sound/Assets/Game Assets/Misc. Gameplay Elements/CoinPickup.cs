////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour {

    public bool playSpawnSoundAtSpawn = true;
    public AK.Wwise.Event spawnSound;

    [Header("Sounds")]
    AudioSource audio_source;
	public AudioClip pick_coin_sound;
    public AudioClip drop_sound;

	void Start(){
        if (playSpawnSoundAtSpawn){
            //spawnSound.Post(gameObject);

            // -------- DROP SOUND ----------- //
            audio_source = GetComponent<AudioSource>();
            audio_source.PlayOneShot(drop_sound);
        }
	}

	public void AddCoinToCoinHandler(){
		InteractionManager.SetCanInteract(this.gameObject, false);
		GameManager.Instance.coinHandler.AddCoin ();

        // -------- PICK UP COIN SOUND ----------- //
        audio_source = GetComponent<AudioSource>();
        audio_source.PlayOneShot(pick_coin_sound);
        //Destroy (gameObject, 0.1f); //TODO: Pool instead?
    }
}
