using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotSpeed = 10f;
    [SerializeField] private Transform grabPos;
    [SerializeField] private Transform dropPos;

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

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turn(h, v);
        if (isGrab == true && block != null)
        {
            DropBlock();
            RotateBlockX();
            RotateBlockY();
            RotateBlockZ();
        }
        
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

        Quaternion newRotation = Quaternion.LookRotation(movement);

        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation, rotSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (other.gameObject.tag == "Block")
            {
                other.gameObject.transform.position = grabPos.position;
                other.gameObject.transform.parent = grabPos.gameObject.transform;
                block = other.GetComponent<Block>();
                blockPivot = block.GetPivot();
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

                    block = null;
                    isGrab = false;
            }
    }
}
