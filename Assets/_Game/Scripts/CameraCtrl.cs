using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public bool firstApproach;
    public bool secondApproach;
    public Transform cameraGoal;
    public float cameraMovSpeed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if(firstApproach){
            transform.position = Vector3.Lerp(transform.position, cameraGoal.position, Time.deltaTime * cameraMovSpeed);
            transform.rotation = Quaternion.Lerp (transform.rotation, cameraGoal.rotation, Time.deltaTime*1.0f);
        }        
    }
}
