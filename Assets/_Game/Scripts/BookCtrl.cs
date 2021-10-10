using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCtrl : MonoBehaviour
{
    public List<Phrase> allTexts;
    public List<Phrase> currentTexts;
    public static BookCtrl singleton;

    private void Awake() {
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
    }
    

    public void AddTextToList(string spanish, string english){
        Phrase nPhr = new Phrase(spanish,english);
        allTexts.Add(nPhr);
        currentTexts.Add(nPhr);
    }

    public void AddPhraseToBook(Phrase phrase){
        StartCoroutine(BookUICtrl.singleton.AddCharactersToUI(phrase));
    }

    public void AddTextToList(Phrase f)
    {
        AddTextToList(f.GetSpanishPhrase(), f.GetEnglishPhrase());
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

    public string GetPhrase()
	{
        return PlayerPrefs.GetInt("Lang") == 0 ? GetSpanishPhrase() : GetEnglishPhrase();
	}

    public string GetSpanishPhrase(){
        return this.spanishPhrase;
    }

    public void SetSpanishPhrase(string newSpanishPhrase){
        this.spanishPhrase = newSpanishPhrase;
    }

    public string GetEnglishPhrase(){
        return this.englishPhrase;
    }

    public void SetEnglishPhrase(string newEnglishPhrase){
        this.englishPhrase = newEnglishPhrase;
    }
}
