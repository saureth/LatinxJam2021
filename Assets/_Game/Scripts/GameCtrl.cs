﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl  singleton; 
    public Transform        cameraTransform;
    public int              idioma;

    public bool cardUsed = false;

    public bool pausado = false;

    public AudioSource audioSource;

    void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
        audioSource.Play();
    }


    public void EntroPuerta()
	{
        StartCoroutine(ShowRoulette());
    }

    private IEnumerator ShowRoulette()
    {
        this.cardUsed = true;
        GameCtrl.singleton.pausado = true;
        DeckUICtrl.singleton.ShowDeckUI();
        yield return new WaitUntil(()=>cardUsed ==false);
        yield return new WaitUntil(()=>BookUICtrl.singleton.bookActive ==false);
        GameCtrl.singleton.pausado = false;
        DeckCtrl.singleton.TriggerLastCardEvent();
    }
}
