using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Phrase frase;
    void Start()
    {
        
    }
    [ContextMenu("Agregar Frase")]
    public void AgregarFrase()
	{
        BookCtrl.singleton.AddTextToList(frase);
	}
}
