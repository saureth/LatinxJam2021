using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUICtrl : MonoBehaviour
{
    public static DeckUICtrl singleton;
    public Animator DeckPanel;
    private void Awake() {  
        if(singleton ==null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
    }

    public void ShowDeckUI(){
        DeckPanel.SetBool("visible", true);
    }

    public void ChooseCard(){
        GameCtrl.singleton.PlayCardFlipSound();
        DeckCtrl.singleton.TriggerAdventureCard();
        DeckPanel.SetBool("visible", false);
    }
}
