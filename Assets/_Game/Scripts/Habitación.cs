using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitación : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			CameraCtrl.singleton.posObjetivo = transform.position;
		}
	}
}
