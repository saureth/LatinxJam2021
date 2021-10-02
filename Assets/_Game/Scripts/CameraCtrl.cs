using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
	public float velocidad;
	public Vector3 posObjetivo = Vector3.zero;
	public static CameraCtrl singleton;

	private void Awake()
	{
		singleton = this;
	}

	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, posObjetivo, velocidad * Time.deltaTime);
	}

}
