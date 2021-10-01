using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl singleton; 
    public Transform cameraTransform;
    public bool eventTriggered = false;

    [Header("Roulette control stuff")]
    public float rouletteShowingTime= 2f;
    public GameObject roulettePanel;

    void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }

    void Update()
    {
        if(eventTriggered){
            StartCoroutine(ShowRoulette());
            eventTriggered = false;
        }
    }

    private IEnumerator ShowRoulette(){
        PlayerMovement.singleton.canMove = false;
        roulettePanel.SetActive(true);
        yield return new WaitForSeconds(rouletteShowingTime);
        roulettePanel.SetActive(false);
        PlayerMovement.singleton.canMove = true;
        BookCtrl.singleton.AddTextToList(0);
    }
}
