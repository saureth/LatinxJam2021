using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personalizar : MonoBehaviour
{
    public Materializador materialPrincipal;
    public Materializador materialOjos;
    public Materializador materialNariz;
    public MallasCambiantes mallasOrejas;
    public MallasCambiantes mallasOjos;
    public MallasCambiantes mallasColas;

    private void Start()
	{
        mallasOrejas.Actualizar();
        mallasOjos.Actualizar();
    }

    [ContextMenu("Cambiar Ojos")]
    public void CambiarMallaOjos()
    {
        mallasOjos.Siguiente();
    }

    [ContextMenu("Cambiar Colas")]
    public void CambiarMallaColas()
    {
        mallasColas.Siguiente();
    }

    [ContextMenu("Cambiar Orejas")]
    public void CambiarMallaOrejas()
    {
        mallasOrejas.Siguiente();
    }

    [ContextMenu("Cambiar material ppal")]
    public void CambiarMaterialPrincipal()
    {
        materialPrincipal.Siguiente();
    }
    [ContextMenu("Cambiar material Ojos")]
    public void CambiarMaterialOjos()
    {
        materialOjos.Siguiente();
    }
    [ContextMenu("Cambiar material Nariz")]
    public void CambiarMaterialNariz()
    {
        materialNariz.Siguiente();
    }
}
[System.Serializable]
public class Materializador
{
    public Material[]   materiales;
    public Renderer[]   mallas;
    public int          actual;

    public void Siguiente()
	{
        actual = (actual + 1) % materiales.Length;
        ActualizarMateriales();
	}

    public void ActualizarMateriales()
	{
		for (int i = 0; i < mallas.Length; i++)
		{
            mallas[i].material = materiales[actual];
		}
	}
}

[System.Serializable]
public class MallasCambiantes
{
    public GameObject[] mallas;
    public int actual;
    public void Siguiente()
    {
        actual = (actual + 1) % mallas.Length;
        Actualizar();
    }
    public void Actualizar()
    {
        for (int i = 0; i < mallas.Length; i++)
        {
            mallas[i].SetActive(i == actual);
        }
    }
}