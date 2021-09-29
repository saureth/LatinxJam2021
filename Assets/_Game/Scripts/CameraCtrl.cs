using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public bool firstApproach;
    public bool secondApproach;
    public Transform cameraGoal;
    public Transform cameraTransform;

    [Header("Mixed stuff")]
    public float cameraMovSpeed = 1.0f;
    public float cameraRotSpeed = 1.0f;

    [Header("First Approach stuff")]
    public bool goalIsReached = false;
    public float movementThreshold = 1.0f;

    void Start()
    {
        if(firstApproach){
            StartCoroutine(MoveCameraToGoal());
        }
    }

    void Update()
    {
            
    }

    private IEnumerator MoveCameraToGoal(){
        while(!goalIsReached){
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraGoal.position, Time.deltaTime * cameraMovSpeed);        
            cameraTransform.rotation = Quaternion.Lerp (cameraTransform.rotation, cameraGoal.rotation, Time.deltaTime*cameraRotSpeed);
            goalIsReached = Vector3.Distance(cameraGoal.position,cameraTransform.position) <= movementThreshold;
            yield return new WaitForEndOfFrame();
        }
    }
}
