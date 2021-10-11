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

    public AudioSource musicAudioSource;
    public AudioSource effectAudioSource;

    public List<AudioClip> musicClips;

    public AudioClip invisibleClip;

    public AudioClip bookLeafClip;
    public AudioClip cardFlipClip;

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
        audioIndex = Random.Range(0,musicClips.Count);
        ChooseAndPlayAudio();
    }

    public void PlayBookLeafSound(){
        effectAudioSource.clip = bookLeafClip;
        effectAudioSource.Play();
    }

    public void PlayCardFlipSound(){
        effectAudioSource.clip = cardFlipClip;
        effectAudioSource.Play();
    }


    public void ChangeMusicToInvisible(){
        musicAudioSource.clip = invisibleClip;
        musicAudioSource.Play();
    }

    public void ChangeMusicToRegular(){
        musicAudioSource.clip = musicClips[audioIndex];
        musicAudioSource.Play();
    }

    private void ChooseAndPlayAudio(){
        musicAudioSource.clip = musicClips[audioIndex];
        musicAudioSource.Play();
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
