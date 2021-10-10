using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
	public GameObject particulas;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (!PuertaFinal.singleton.abierta)
			{
				StartCoroutine(Finalizar());
			}
			
		}
	}

	IEnumerator Finalizar()
	{
		Instantiate(particulas, transform.position, transform.rotation);
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
		PuertaFinal.singleton.Abrir();
	}
}
