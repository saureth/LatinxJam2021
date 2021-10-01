using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCtrl : MonoBehaviour
{

    public List<string> texts;
    public static BookCtrl singleton;

    private void Awake() {
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
        this.texts = new List<string>();
    }

    public void AddTextToList(string textToAdd){
        texts.Add(textToAdd);
    }

}
