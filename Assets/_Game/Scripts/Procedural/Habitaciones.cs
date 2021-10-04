using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitaciones : MonoBehaviour
{
    public int nHabitacion;
    public GameObject[] habitaciones;

    void Start(){
    }

   
    public void Inicializar(int n){
        nHabitacion = n;
        Instantiate(habitaciones[nHabitacion], transform.position, Quaternion.Euler(0,180,0)).transform.parent = transform;

    }


}
