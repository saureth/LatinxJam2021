using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUICtrl : MonoBehaviour
{
    public GameObject panel;
    public Text leftLeaf;
    public Text rightLeaf;
    public static BookUICtrl singleton;
    public List<string> textList;
    public int phraseAmountPerPage = 3;
    public int currentPages = 1;
    int currentLeftPhrases = 0;
    int currentRightPhrases = 0;
    string leftLeaftText;
    string rightLeafText;

    private void Awake() {
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
        this.textList = new List<string>();
    }

    public void addTextToBook(string text){
        textList.Add(text);
    }

    public void ShowBookUI(){
        this.panel.SetActive(true);
    }
}
