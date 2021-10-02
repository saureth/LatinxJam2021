using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    
    public string tagToCompare = "Player";
    public bool autoDestruir = true;
    public LayerMask capa;

    public static float tiempoUltimaActivacion;

    private void OnTriggerEnter(Collider other){
		if (Time.time < tiempoUltimaActivacion)
		{
            Destroy(gameObject);
            return;
		}
        if(other.gameObject.CompareTag(tagToCompare)){
            GameCtrl.singleton.EntroPuerta();
            tiempoUltimaActivacion = Time.time + 3;
            if (autoDestruir)
            {
                Destroy(this.gameObject);
                Collider[] cols = Physics.OverlapSphere(transform.position, 1, capa);
				for (int i = 0; i < cols.Length; i++)
				{
                    Destroy(cols[i].gameObject);
				}
            }
        }

    }
}
