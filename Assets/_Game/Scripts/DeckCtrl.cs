using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCtrl : MonoBehaviour
{
    public List<Adventure> adventureDeck;
    public static DeckCtrl singleton;

    public float timeForFreeze;
    public float timeForInvisible;

    private void Awake() {
        if(singleton ==null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
        Shuffle();
    }


    private void Shuffle()
    {  
        int n = adventureDeck.Count;
        Adventure value;
        while (n > 1) {  
            n--;  
            int k = Random.Range(0,n);  
            value = adventureDeck[k];  
            adventureDeck[k] = adventureDeck[n];  
            adventureDeck[n] = value;  
        }  
    }

    public Adventure GetAdventureCard(){
        Adventure dequeuedCard = adventureDeck[0];
        adventureDeck.RemoveAt(0);
        adventureDeck.Add(dequeuedCard);
        return dequeuedCard;
    }

    public void CreateEnemyAtRoom(){

    }

    
    public void FreezeEnemies(){
        
    }

    public void BecomeInvisible(){
        
    }

    public void KeyRoomVisible(){
        
    }
    public void DoorRoomVisible(){
        
    }
}