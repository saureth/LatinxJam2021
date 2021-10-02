using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personalizar : MonoBehaviour
{
    public Materializador materialPrincipal;
    public Materializador materialOjos;
    public Materializador materialNariz;

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