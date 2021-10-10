﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement singleton;

    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    public Vector3 rotation;
    Animator playerAnimator;

    void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
        playerAnimator = this.GetComponentsInChildren<Animator>()[0];
    }

    void Update(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");        
        if(!GameCtrl.singleton.pausado && (horizontalInput!= 0f || verticalInput!= 0f)){
            playerAnimator.SetFloat("velocidad",1f*(horizontalInput*horizontalInput + verticalInput*verticalInput));
            Quaternion q = transform.rotation;
            rotation = new Vector3 (horizontalInput,0,verticalInput);
            transform.forward = rotation.normalized;
            transform.rotation = Quaternion.Lerp(q, transform.rotation, 5 * Time.deltaTime);
            transform.Translate (Vector3.forward * movementSpeed * Time.deltaTime );
        }
        else{
            playerAnimator.SetFloat("velocidad",0f);
        }
    }
    
}
