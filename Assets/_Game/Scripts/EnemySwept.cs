using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemySwept : MonoBehaviour
{
    public float anguloBarrido;
    public float distanciaVision;
    public UnityEvent atacar;

    public static bool invisible;

    // Update is called once per frame
    void Update()
    {
        //if (PlayerMovement.singleton.playerIsInvisible) return;
         RaycastHit hit;

         transform.localEulerAngles = Vector3.up * anguloBarrido * Mathf.Sin(Time.time*5);
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanciaVision))
        {
            atacar.Invoke();
        }
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * distanciaVision);
	}
}
