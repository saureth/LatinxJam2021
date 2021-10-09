using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUICtrl : MonoBehaviour
{
    public static DeckUICtrl singleton;
    public GameObject DeckPanel;
    private void Awake() {  
        if(singleton ==null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
    }

    public void ShowDeckUI(){
        DeckPanel.SetActive(true);
    }

    public void ChooseCard(){
        DeckCtrl.singleton.TriggerAdventureCard();
        DeckPanel.SetActive(false);
    }
}
