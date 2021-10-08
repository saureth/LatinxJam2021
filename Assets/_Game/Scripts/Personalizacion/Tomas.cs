using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomas : MonoBehaviour
{
    public Transform camara;
    public Transform[] posiciones;
    public int actualPos;
    public float velocidad = 3f;
    public float rotacion;
    // Update is called once per frame
    void Update()
    {
        camara.localPosition = Vector3.Lerp(camara.localPosition, posiciones[actualPos].localPosition, velocidad * Time.deltaTime);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotacion * Vector3.up, velocidad * Time.deltaTime);
    }

    public void CambiarPosActual(int cual)
    {
        actualPos = cual;
    }

    public void CambiarRotacionActual(float cual)
    {
        rotacion = cual;
    }
}
