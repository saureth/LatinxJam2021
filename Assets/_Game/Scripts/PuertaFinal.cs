using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    public float rangoLiberador = 3;
    public Transform pivote;
    public static PuertaFinal singleton;
	public Animator anim;
	public bool abierta = false;

	private void Awake()
	{
        singleton = this;
	}

	void Start()
    {
        DestruirCosas();
    }

    public void Abrir()
	{
		anim.SetTrigger("activar");
		abierta = true;
	}

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pivote.position, rangoLiberador);
	}

    void DestruirCosas()
	{
        Collider[] cosas;
        cosas = Physics.OverlapSphere(pivote.position, rangoLiberador);
		for (int i = 0; i < cosas.Length; i++)
		{
			if (cosas[i].CompareTag("prop"))
			{
                Destroy(cosas[i].gameObject);
			}
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if (abierta && other.CompareTag("Player"))
		{
			StartCoroutine(Victoria());
		}
	}

	public IEnumerator Victoria()
	{
		yield return new WaitForSeconds(0.5f);
		print("Victoria");
		///////////////////////////////////////////////// Para hacer el código de ganar
	}
}
