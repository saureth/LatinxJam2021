using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public static bool congelados = false;
    public Adventure aventura;

	private void Start()
	{
        aventura.myEvent.AddListener(Activar);
	}

    public void Activar()
	{

	}


	private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(A.position, B.position);    
    }
}
