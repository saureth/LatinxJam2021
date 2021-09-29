using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement singleton;

    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public bool canMove = true;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    public Vector3 rotation;

    void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }

    void Update(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");        
        if(!!canMove && (horizontalInput!= 0f || verticalInput!= 0f)){
            rotation = new Vector3 (horizontalInput,0,verticalInput);
            transform.forward = rotation.normalized;
            transform.Translate (Vector3.forward * movementSpeed * Time.deltaTime );
        }
    }
    
}
