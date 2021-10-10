using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitación : MonoBehaviour
{

	public GameObject miniMapa;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			CameraCtrl.singleton.posObjetivo = transform.position;
			miniMapa.SetActive(true);
		}
	}

	public void ActivarLlave()
	{
		miniMapa.GetComponent<SpriteRenderer>().color = Color.green;
		miniMapa.SetActive(true);
	}
	public void ActivarPuerta()
	{
		miniMapa.GetComponent<SpriteRenderer>().color = Color.red;
		miniMapa.SetActive(true);
	}
}
