using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUICtrl : MonoBehaviour
{
    public GameObject panel;
    public Text leftLeafUI;
    public Text rightLeafUI;
    public static BookUICtrl singleton;
    public List<string> textList;
    public int phraseAmountPerPage = 3;
    public int currentPages = 0;
    public int currentLeftPhrases = 0;
    public int currentRightPhrases = 0;
    public string leftLeaftText;
    public string rightLeafText;

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
        //longitud antes es %6 == 0 -> nueva página y escribir en izquierda
        if(textList.Count % (phraseAmountPerPage *2) == 0){
            //aumenta páginas
            currentPages++;
            leftLeaftText = text;
            rightLeafText = "";
            currentLeftPhrases = 1;
            currentRightPhrases = 0;
        }
        // longitud antes %6 != 0 -> calcular izquierda o derecha
        else {
            // frases a izquierda %3 ==0 -> añadir a lo ya escrito en derecha 
            if(currentLeftPhrases % phraseAmountPerPage == 0){
                currentRightPhrases++;
                rightLeafText += text;
            }
            // frases a izquierda %3 != 0 -> añadir a lo ya escrito en izquierda
            else {
                currentLeftPhrases++;
                leftLeaftText += text;
            }
        }
        // Siempre, al final, añadir texto a la lista
        textList.Add(text);
    }

    public void ShowBookUI(){
        this.panel.SetActive(true);
    }
}
