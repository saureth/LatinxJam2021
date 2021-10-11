using System.Collections;
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

    public List<AudioClip> clips;

    public AudioClip invisibleClip;

    public int audioIndex = -1;

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
        audioIndex = Random.Range(0,clips.Count);
        ChooseAndPlayAudio();
    }

    public void ChangeMusicToInvisible(){
        audioSource.clip = invisibleClip;
        audioSource.Play();
    }

    public void ChangeMusicToRegular(){
        audioSource.clip = clips[audioIndex];
        audioSource.Play();
    }

    private void ChooseAndPlayAudio(){
        audioSource.clip = clips[audioIndex];
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
