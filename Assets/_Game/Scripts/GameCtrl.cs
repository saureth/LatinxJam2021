using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl  singleton; 
    public Transform        cameraTransform;
    public int              idioma;

    public bool pausado = false;

    [Header("Roulette control stuff")]
    public float            rouletteShowingTime= 2f;
    public GameObject       roulettePanel;

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
    }


    public void EntroPuerta()
	{
        StartCoroutine(ShowRoulette());
    }

    private IEnumerator ShowRoulette()
    {
        GameCtrl.singleton.pausado = true;
        //roulettePanel.SetActive(true);
        ////////////////////////////////////////// Implementar sistema de "Aventuras"
        yield return new WaitForSeconds(rouletteShowingTime);
        //roulettePanel.SetActive(false);
        Phrase frase = new Phrase("Hola mundo", "Hello world");
        BookCtrl.singleton.AddTextToList(0);
        BookUICtrl.singleton.ShowBookUI();
        GameCtrl.singleton.pausado = false;
    }
}
