using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUICtrl : MonoBehaviour
{
    public Text leftLeafUI;
    public Text rightLeafUI;
    public static BookUICtrl singleton;
    public int amountOfPages = 0;
    public int currentPage;
    public Animator animLibro;
    public GameObject[] objetosLibro;

    public bool bookActive = false;

    private void Awake() 
    {
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(this.gameObject);
        }
    }

    public void ActualizarTexto()
	{
        rightLeafUI.text = "";
        leftLeafUI.text = "";
        int inicial = 6 * currentPage;
        for (int i = 0; i < 3; i++)
        {
            if (BookCtrl.singleton.currentTexts.Count > inicial + i)
            {
                leftLeafUI.text = leftLeafUI.text + BookCtrl.singleton.currentTexts[inicial + i].GetPhrase() + "\n";
            }
            if (BookCtrl.singleton.currentTexts.Count > 3 + inicial + i)
            {
                rightLeafUI.text = rightLeafUI.text + BookCtrl.singleton.currentTexts[3 + inicial + i].GetPhrase() + "\n";
            }
        }
	}

    public Text CalculateWhereToWrite(){
        return (BookCtrl.singleton.currentTexts.Count % 6 < 3) ? leftLeafUI: rightLeafUI;
    }

    public IEnumerator AddCharactersToUI(Phrase phrase){
        ShowBookUI();
        if((currentPage+1) * 6 <= BookCtrl.singleton.currentTexts.Count){
            leftLeafUI.text ="";
            rightLeafUI.text = "";
        }
        yield return new WaitForSeconds(1f);
        bool finishAdding = false;
        int charIndex = 0;
        while(!finishAdding){
            CalculateWhereToWrite().text += phrase.GetPhrase()[charIndex];
            charIndex++;
            yield return new WaitForSeconds(0.1f);
            finishAdding = charIndex >= phrase.GetPhrase().Length;
        }
        BookCtrl.singleton.AddTextToList(phrase);
        currentPage = Mathf.FloorToInt(BookCtrl.singleton.currentTexts.Count / 6);
        ActualizarTexto();
    }

    public void ShowHideBook()
	{
		if (animLibro.GetBool("abierto"))
		{
            CloseBook();
		}
		else
		{
            ShowBookUI();
		}
	}

    public void ShowBookUI()
    {
        animLibro.SetBool("abierto", true);
        animLibro.gameObject.SetActive(true);
        for (int i = 0; i < objetosLibro.Length; i++)
        {
            objetosLibro[i].SetActive(true);
        }
        bookActive = true;
        ActualizarTexto();
    }

    public void CloseBook()
    {
        animLibro.SetBool("abierto", false);
		for (int i = 0; i < objetosLibro.Length; i++)
		{
            objetosLibro[i].SetActive(false);
		}
        StartCoroutine(OcultarModelo());
    }


    IEnumerator OcultarModelo()
    {
        yield return new WaitForSeconds(1f);
        animLibro.gameObject.SetActive(false);
        bookActive = false;
    }

    public void PageUp(){
        amountOfPages = Mathf.FloorToInt((BookCtrl.singleton.currentTexts.Count - 1) / 6f);
        // Si la página actual está entre 1 y la penúltima puede subir página, de resto no haga nada   
        if(currentPage < amountOfPages){
            currentPage++;
            //Mostrar página deseada
            StartCoroutine(Pasar());
        }
    }

    public void PageDown(){
        // Si la página actual está entre 2 y la última puede bajar página, de resto no haga nada
        if( currentPage >= 1){
            currentPage--;
            //Mostrar página deseada
            StartCoroutine(Pasar());
        }
    }

    IEnumerator Pasar()
	{        
        animLibro.SetTrigger("pasar");
        yield return new WaitForSeconds(1f);
        ActualizarTexto();
    }
}
