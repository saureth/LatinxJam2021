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
        mallasOrejas.Cargar("mallaOrejas");
        mallasOjos.Cargar("mallasOjos");
        mallasColas.Cargar("mallasColas");
        materialPrincipal.Cargar("materialPrincipal");
        materialOjos.Cargar("materialOjos");
        materialNariz.Cargar("materialNariz");
    }

    [ContextMenu("Cambiar Ojos")]
    public void CambiarMallaOjos()
    {
        mallasOjos.Siguiente();
        mallasOjos.Guardar("mallasOjos");
    }

    [ContextMenu("Cambiar Colas")]
    public void CambiarMallaColas()
    {
        mallasColas.Siguiente();
        mallasColas.Guardar("mallasColas");
    }

    [ContextMenu("Cambiar Orejas")]
    public void CambiarMallaOrejas()
    {
        mallasOrejas.Siguiente();
        mallasOrejas.Guardar("mallaOrejas");
    }

    [ContextMenu("Cambiar material ppal")]
    public void CambiarMaterialPrincipal()
    {
        materialPrincipal.Siguiente();
        materialPrincipal.Guardar("materialPrincipal");
    }
    [ContextMenu("Cambiar material Ojos")]
    public void CambiarMaterialOjos()
    {
        materialOjos.Siguiente();
        materialOjos.Guardar("materialOjos");
    }
    [ContextMenu("Cambiar material Nariz")]
    public void CambiarMaterialNariz()
    {
        materialNariz.Siguiente();
        materialNariz.Guardar("materialNariz");
    }
}
[System.Serializable]
public class Materializador
{
    public Material[]   materiales;
    public Renderer[]   mallas;
    public int          actual;
    
    public void Cargar(string nombre)
	{
        actual = PlayerPrefs.GetInt(nombre, 0);
        ActualizarMateriales();
    }

    public void Guardar(string nombre)
    {
        PlayerPrefs.SetInt(nombre, actual);
    }

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
    public void Cargar(string nombre)
    {
        actual = PlayerPrefs.GetInt(nombre, 0);
        Actualizar();
    }

    public void Guardar(string nombre)
    {
        PlayerPrefs.SetInt(nombre, actual);
    }
}