using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTextureChange : MonoBehaviour
{
    public Material[] materiales;
    void Start()
    {
        GetComponent<Renderer>().material = materiales[Random.Range(0, materiales.Length)];
    }
}
