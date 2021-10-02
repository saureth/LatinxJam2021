using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCtrl : MonoBehaviour
{
    public List<Phrase> allTexts;
    public List<Phrase> currentTexts;
    public static BookCtrl singleton;
    public bool isSpanishLang = true;

    private void Awake() {
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
        this.currentTexts = new List<Phrase>();
    }

    public void AddTextToList(int phraseIndex){
        Phrase nPhr = allTexts[phraseIndex];
        currentTexts.Add(nPhr);
        BookUICtrl.singleton.addTextToBook(isSpanishLang ? nPhr.getSpanishPhrase() : nPhr.getEnglishPhrase());
    }

    public void AddTextToList(string spanish, string english){
        Phrase nPhr = new Phrase(spanish,english);
        allTexts.Add(nPhr);
        currentTexts.Add(nPhr);
        BookUICtrl.singleton.addTextToBook(isSpanishLang ? nPhr.getSpanishPhrase() : nPhr.getEnglishPhrase());
    }

}

[System.Serializable]
public class Phrase {
    
    [SerializeField]
    private string spanishPhrase;
    [SerializeField]
    private string englishPhrase;

    public Phrase(){
    }

    public Phrase(string spanishText, string englishText){
        this.spanishPhrase = spanishText;
        this.englishPhrase = englishText;
    }

    public string getSpanishPhrase(){
        return this.spanishPhrase;
    }

    public void setSpanishPhrase(string newSpanishPhrase){
        this.spanishPhrase = newSpanishPhrase;
    }

    public string getEnglishPhrase(){
        return this.englishPhrase;
    }

    public void setEnglishPhrase(string newEnglishPhrase){
        this.englishPhrase = newEnglishPhrase;
    }
}
