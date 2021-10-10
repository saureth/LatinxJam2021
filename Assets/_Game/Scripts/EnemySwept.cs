using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemySwept : MonoBehaviour
{
    public float anguloBarrido;
    public float distanciaVision;
    public UnityEvent atacar;

    // Update is called once per frame
    void Update()
    {
         RaycastHit hit;

         transform.localEulerAngles = Vector3.up * anguloBarrido * Mathf.Sin(Time.time);
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanciaVision))
            {
                atacar.Invoke();
            }
    }
}
