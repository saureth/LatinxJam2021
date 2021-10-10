using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCtrl : MonoBehaviour
{
    public List<Adventure> adventureDeck;
    public static DeckCtrl singleton;

    public float timeForFreeze;
    public float timeForInvisible;

    public Adventure lastCard;

    private void Awake() {
        if(singleton ==null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
        
    }

	private IEnumerator Start()
	{
        yield return new WaitForSeconds(0.5f);
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

    public void TriggerAdventureCard(){
        lastCard = adventureDeck[0];
        adventureDeck.RemoveAt(0);
        adventureDeck.Add(lastCard);
        GameCtrl.singleton.cardUsed = false;
        BookCtrl.singleton.AddPhraseToBook(lastCard.phrase);
    }

    public void TriggerLastCardEvent(){
        lastCard.myEvent.Invoke();
    }

    public void CreateEnemyAtRoom(){
    }
    
    public void FreezeEnemies(){
    }

    public void BecomeInvisible(){
        StartCoroutine(PlayerMovement.singleton.MakeInvisible());
    }

    public void KeyRoomVisible(){
    }
    public void DoorRoomVisible(){
    }
}