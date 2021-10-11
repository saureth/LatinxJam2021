using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDesactivarObjetos : MonoBehaviour
{
    public float probActivarObj;
    // Start is called before the first frame update
    void Start()
    {        
        gameObject.SetActive(Random.Range(0f, 1f) < probActivarObj);
    }
}
