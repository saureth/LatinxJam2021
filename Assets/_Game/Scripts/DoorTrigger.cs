using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string tagToCompare = "Player";

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag(tagToCompare)){
            CameraCtrl.singleton.triggered = true;
            Destroy(this.gameObject);
        }
    }
}
