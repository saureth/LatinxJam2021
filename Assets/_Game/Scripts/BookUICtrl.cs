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
    public int amountOfPages = 0;
    public int currentPage;
    public int currentLeftPhrases = 0;
    public int currentRightPhrases = 0;
    public string leftLeaftText;
    public string rightLeafText;

    private void Awake() {
        currentPage = amountOfPages;
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
    }

    public void addTextToBook(string text){
        //longitud antes es %6 == 0 -> nueva página y escribir en izquierda
        if(textList.Count % (phraseAmountPerPage *2) == 0){
            //aumenta páginas
            amountOfPages++;
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
        // Se resetea la página actual a la última
        currentPage = amountOfPages;
    }

    public void ShowBookUI(){
        this.panel.SetActive(true);
        PlayerMovement.singleton.canMove = false;
        leftLeafUI.text = leftLeaftText;
        rightLeafUI.text = rightLeafText;
    }

    public void CloseBook(){
        this.panel.SetActive(false);
        PlayerMovement.singleton.canMove = true;
    }

    public void PageUp(){
        // Si la página actual está entre 1 y la penúltima puede subir página, de resto no haga nada   
        if( currentPage >= 1 && currentPage < amountOfPages ){
            currentPage++;
            //Mostrar página deseada
            showTextAtPage(currentPage);
        }
    }

    public void PageDown(){
        // Si la página actual está entre 2 y la última puede bajar página, de resto no haga nada
        if( currentPage >= 2 && currentPage < amountOfPages ){
            currentPage--;
            //Mostrar página deseada
            showTextAtPage(currentPage);
        }
    }

    private void showTextAtPage(int pageToShow){
        // Crear sublista inicialmente vacía
        List<string> pageList = new List<string>();
        // de la lista general, el índice de inicio es 6 * páginaamostrar
        int startIndex = pageToShow * phraseAmountPerPage*2;
        // de la lista general, el último índice posible es el inicial +6 pues son 6 frases por página máximo
        int endIndex = startIndex +6;
        // Si el cálculo anterior dió más de la cantidad actual, entonces el índice final es el último de los actuales
        if(endIndex > textList.Count){
            endIndex = textList.Count-1;
        }
        // Añado entre 1 y 6 textos a la sublista
        string text;
        for (int i = startIndex; i < endIndex; i++)
        {        
            pageList.Add(textList[i]);
        }
        leftLeaftText ="";
        rightLeafText ="";
        for (int i = 0; i < pageList.Count; i++)
        {
            // Si el índice va entre 0 y 2 se añade texto a izquierda
            if(i <= 3){
                leftLeaftText += pageList[i];
            }
                // Si el índice va entre 3 y 6 se añade texto a derecha
            else{
                rightLeafText += pageList[i];
            }
        }        
        leftLeafUI.text = leftLeaftText;
        rightLeafUI.text = rightLeafText;
    }
}
