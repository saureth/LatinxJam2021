using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform doll;
    public Vector3 arrivalPoint;
    public float speed;
    public static bool congelados = false;
    public Adventure aventura;

	private void Start()
	{
        transform.position = A.position;
        transform.LookAt(B.position);
        arrivalPoint = B.position;
        aventura.myEvent.AddListener(Activar);
	}
    	private void Update()
	{
        float distance = Vector3.SqrMagnitude(arrivalPoint - doll.position);
        
        doll.Translate(Vector3.forward * speed * Time.deltaTime);
        if(distance <= .1f)
        {
            arrivalPoint = (arrivalPoint==B.position)?A.position:B.position;
        }
            Quaternion targetRotation = Quaternion.LookRotation(arrivalPoint - doll.position, Vector3.up);
            doll.rotation = Quaternion.Slerp(doll.rotation, targetRotation, Time.deltaTime * 3.0f);
            
        

    }
    public void Activar()
	{

	}


	private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(A.position, B.position);    
    }
}
