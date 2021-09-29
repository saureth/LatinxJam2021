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

    [Header("First Approach stuff")]
    public bool goalIsReached = false;
    public float movementThreshold = 1.0f;

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
            Debug.Log("Mostrar RenderTexture de la ruleta en una RawImage");
        }
    }

}
