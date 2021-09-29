using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement singleton;

    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    public Vector2 rotation;
    public bool canMove = true;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        if(!!canMove){
            rotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
            rotation.y += Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0);
            transform.Translate(new Vector3(horizontalInput * rotationSpeed * Time.deltaTime, 0, verticalInput*movementSpeed * Time.deltaTime));

        }        
    }
    
}
