////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventSounds : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AK.Wwise.Event OnPointerDownSound;
    public AK.Wwise.Event OnPointerUpSound;
    public AK.Wwise.Event OnPointerEnterSound;
    public AK.Wwise.Event OnPointerExitSound;
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioSource audio_source = GameObject.Find("Menus").GetComponent<AudioSource>();
        AudioClip audio_clip = Resources.Load<AudioClip>("Audio/SFX/Interface/BAS_Button_Over");
        audio_source.PlayOneShot(audio_clip, 0.7f);
        //OnPointerDownSound.Post(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioSource audio_source = GameObject.Find("Menus").GetComponent<AudioSource>();
        AudioClip audio_clip = Resources.Load<AudioClip>("Audio/SFX/Interface/BAS_Inventory_Select");
        audio_source.PlayOneShot(audio_clip, 0.7f);
        //OnPointerEnterSound.Post(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //audio_source.PlayOneShot(on_exit_hover);
        //OnPointerExitSound.Post(gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //audio_source.PlayOneShot(on_release);
        //OnPointerUpSound.Post(gameObject);
    }
}
