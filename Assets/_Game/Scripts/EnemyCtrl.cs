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
    public Animator muñecaAnim;
    public Phrase[] phrases;

    float distance;

    private void Start()
	{
        doll.position = A.position;
        doll.LookAt(B.position);
        aventura.phrase = phrases[Random.Range(0, phrases.Length)];
        arrivalPoint = B.position;
        aventura.myEvent.AddListener(Activar);
        DeckCtrl.singleton.adventureDeck.Add(aventura);
        doll.gameObject.SetActive(false);
	}
    private void Update()
    {
        
		if (congelados || !doll.gameObject.activeSelf)
		{
            return;
		}

        distance = Vector3.SqrMagnitude(arrivalPoint - doll.position);
        
        doll.Translate(Vector3.forward * speed * Time.deltaTime);
        if(distance <= .1f)
        {
            arrivalPoint = (arrivalPoint==B.position)?A.position:B.position;
        }
        Quaternion targetRotation = Quaternion.LookRotation(arrivalPoint - doll.position, Vector3.up);
        doll.rotation = Quaternion.Slerp(doll.rotation, targetRotation, Time.deltaTime * 3.0f);
    }

	private void FixedUpdate()
	{
        muñecaAnim.enabled = !congelados; 
    }

	public static void Congelar()
    {
        congelados = true;
    }
    public static void Descongelar()
    {
        congelados = false;
    }

    public void Activar()
	{
        doll.gameObject.SetActive(true);
	}


	private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(A.position, B.position);    
    }
}
