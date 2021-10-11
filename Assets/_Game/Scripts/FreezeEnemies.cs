using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator Congelar(float segundos)
    {
        EnemyCtrl.congelados = true;
        yield return new WaitForSeconds(segundos);
        EnemyCtrl.congelados = false;
    }

    // Update is called once per frame
    public void StartCongelar(float segundos)
    {
        StartCoroutine(Congelar(segundos));
    }
}
