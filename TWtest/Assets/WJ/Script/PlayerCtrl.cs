using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotSpeed = 10f;
    [SerializeField] private Transform grabPos;
    [SerializeField] private Transform dropPos;
    Vector3 forward;
    Vector3 right;

    private Vector3 moveDir;
    private Transform blockPivot;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private float rotationZ = 0f;
    private float rotate = 90f;
    private float rotateReverse = -90f;
    private Block block;
    private Rigidbody rigidbody;
    private Vector3 movement;
    [SerializeField] private bool isGrab = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

    }
    private void Update()
    {
        if (isGrab == true && block != null)
        {
            DropBlock();
            RotateBlockX();
            RotateBlockY();
            RotateBlockZ();
        }
        //if (Input)
        
    }

    

    private void FixedUpdate()
    {
       // float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

       // moveDir = (Vector3.forward * v) + (Vector3.right * h);
       // moveDir = moveDir.normalized * speed * Time.deltaTime;

        //transform.Translate(moveDir, Space.Self);
        

        //Move(h, v);
        //Turn(h, v);


    }
    private void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;

        rigidbody.MovePosition(transform.localPosition + movement);
    }
    private void Turn(float h, float v)
    {
        if (h == 0 && v == 0)
            return;

        Quaternion newRotation = Quaternion.LookRotation(moveDir);

        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation, rotSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (other.gameObject.tag == "Block")
            {
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                other.gameObject.transform.position = grabPos.position;
                other.gameObject.transform.parent = grabPos.gameObject.transform;
                block = other.GetComponent<Block>();
                blockPivot = block.Pivot;
                rotationX = blockPivot.rotation.x;
                rotationY = blockPivot.rotation.y;
                rotationZ = blockPivot.rotation.z;
                isGrab = true;

            }
        }
    }
    void RotateBlockX()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGrab == true)
            {
                rotationX += rotate;
                float roundRotX = Mathf.RoundToInt(rotationX);
                Quaternion rotX = Quaternion.Euler(rotationX, rotationY, rotationZ);

               blockPivot.rotation = rotX;

            }
        }
    }
    void RotateBlockY()
    { 
        if (Input.GetKeyDown(KeyCode.R))
        {
                rotationY += rotate;
                float roundRotY = Mathf.RoundToInt(rotationY);
                Quaternion rotY = Quaternion.Euler(rotationX, rotationY, rotationZ);

                blockPivot.rotation = rotY;
        }
    }
    void RotateBlockZ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
                rotationZ += rotate;
                float roundRotY = Mathf.RoundToInt(rotationZ);
                Quaternion rotZ = Quaternion.Euler(rotationX, rotationY, rotationZ);

                blockPivot.rotation = rotZ;
        }
    }
    private void DropBlock()
    {
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                    int ronndX = Mathf.RoundToInt(dropPos.position.x);
                    int ronndY = Mathf.RoundToInt(dropPos.position.y);
                    int ronndZ = Mathf.RoundToInt(dropPos.position.z);

                    block.transform.parent = null;
                    block.transform.position = new Vector3(ronndX, ronndY, ronndZ);
                    block.transform.rotation = block.Pivot.rotation;
                    block.Pivot.rotation = Quaternion.Euler(0, 0, 0);
                    block.gameObject.GetComponent<BoxCollider>().enabled = true;

                    block = null;
                    isGrab = false;
            }
    }
}
