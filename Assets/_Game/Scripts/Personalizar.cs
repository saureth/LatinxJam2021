using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personalizar : MonoBehaviour
{
    public Materializador materialPrincipal;
    
    [ContextMenu("Cambiar material ppal")]
    public void CambiarMaterialPrincipal()
	{
        materialPrincipal.Siguiente();
	}
}
[System.Serializable]
public class Materializador
{
    public Material[] materiales;
    public MeshRenderer[] mallas;
    public int actual;

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
