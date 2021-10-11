using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardarNombreJugador : MonoBehaviour
{
    public InputField campoTextoNombre;
    // Start is called before the first frame update
    void Start()
    {
        campoTextoNombre.text = PlayerPrefs.GetString("nombre");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuardarNombre(string _nombre){
        PlayerPrefs.SetString("nombre", _nombre);
    }

}
