using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemySwept : MonoBehaviour
{
    public float anguloBarrido;
    public float distanciaVision;
    public UnityEvent atacar;

    public static bool invisible;
    public float tiempoVision = 0.8f;
    float tiempo;

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.singleton.playerIsInvisible) return;
         RaycastHit hit;

         transform.localEulerAngles = Vector3.up * anguloBarrido * Mathf.Sin(Time.time*5);
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanciaVision))
        {
			if (hit.collider.CompareTag("Player"))
			{
                tiempo += Time.deltaTime;
			    if (tiempo > tiempoVision)
			    {
                    GameOver();
			    }
                print("Detectado en:" + tiempo);
			}
		}
		else
		{
			if (tiempo > 0)
			{
                tiempo -= Time.deltaTime;
			}
		}
    }

    public void GameOver()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
	}

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * distanciaVision);
	}
}
