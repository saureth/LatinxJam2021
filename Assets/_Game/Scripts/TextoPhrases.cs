using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoPhrases : MonoBehaviour
{
    public Phrase frase;

    void Start()
    {
        GetComponent<Text>().text = frase.GetPhrase();        
    }

}
