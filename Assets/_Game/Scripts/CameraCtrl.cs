using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public static CameraCtrl singleton;

    public bool firstApproach;
    public bool secondApproach;
    public Transform cameraGoal;
    public Transform cameraInitialPos;
    public Transform cameraTransform;
    public bool triggered = false;

    [Header("Mixed stuff")]
    public float cameraMovSpeed = 1.0f;
    public float cameraRotSpeed = 1.0f;

    [Header("Second Approach stuff")]
    public float rouletteShowingTime= 2f;

    void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }

    void Update()
    {
        if(triggered){
            StartCoroutine(ShowRoulette());
            triggered = false;
        }
    }

    private IEnumerator ShowRoulette(){
        PlayerMovement.singleton.canMove = false;
        Debug.Log("Mostrar RenderTexture de la ruleta en una RawImage");
        yield return new WaitForSeconds(rouletteShowingTime);
        Debug.Log("Dejar de mostrar RenderTexture de la ruleta en una RawImage");
        PlayerMovement.singleton.canMove = true;
    }

}
