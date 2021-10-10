using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageCtrl : MonoBehaviour
{
    public void SetLanguage(int lang){
        PlayerPrefs.SetInt("Lang", lang);
    }
}
