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
    private int jumpcount = 2;
    private Transform trans;
    private RaycastHit rayHitdown;
    private GameObject underB;
    PutPos putpos;
    PutPos putpost;
    //Setinput bool변수
    private bool jump;
    private bool grap;
    private bool put;
    private bool keep;
    //GetGrab 변수
    public GameObject grabObject;
    //public Transform grabtrans;
    public bool handBlock = false;
    public GameObject ghostblock;
    block1 blockg;
    public int handindex;
    public bool[] hasblocks;
    public GameObject[] blocks;
    public GameObject getblock;
    //SetPut 함수
    public GameObject[] putblocks;
    //SetCanPut 함수
    public int spotx;
    public int spoty;
    public int spotz;
    public int spotxt;
    public int spotyt;
    public int spotzt;
    //SetKeepBlock 함수
    public GameObject keepBlock = null;
    public GameObject keepT = null;
    public int handindext;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }
    private void Update()
    {
        if (isGrab == true && block != null)
        {
            DropBlock();
        }
        SetInput();
        SetJump();
        GetGrap();
        SetPut();
        SetCanPut();
        SetKeepBlock();
    }
    private void Start()
    {
        putpos = GameObject.Find("GrabCollider").GetComponent<PutPos>();
        putpost = GameObject.Find("GrabCollider2").GetComponent<PutPos>();
        blockg = GameObject.Find("realbox (1)").GetComponent<block1>();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turn(h, v);

        if(Physics.Raycast(transform.position, Vector3.down, out rayHitdown) && rayHitdown.collider.tag == "Block")
        {
            underB = rayHitdown.collider.gameObject;
        }
    }
    void SetInput()
    {
        jump = Input.GetKeyDown(KeyCode.J);
        keep = Input.GetKeyDown(KeyCode.C);
        grap = Input.GetMouseButtonDown(0);
        put = Input.GetMouseButtonDown(1);
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
    /*void RotateBlockX()
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
    }*/
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
    private void SetJump()
    {
        if (jumpcount > 0)
        {
            if (jump)
            {
                rigidbody.AddForce(Vector3.up * 6, ForceMode.Impulse);
                jumpcount--;
            }
        }
    }
    int GetGrap()
    {
        grabObject = putpos.forwardObject;
        if (grap && grabObject != null && !handBlock && jumpcount == 2)
        {
            if (grabObject.tag == "Block")
            {
                //grabtrans = grabObject.GetComponent<Transform>();
                blockg = grabObject.transform.GetComponentInChildren<block1>();
                handindex = blockg.value;
                hasblocks[handindex] = true;
                handBlock = true;
                put = false;
                ghostblock.SetActive(true);
                getblock = blocks[handindex];
                for (int i = 0; i < blocks.Length; i++)
                {
                    if (i == handindex)
                    {
                        blocks[i].SetActive(true);
                    }
                }
                Destroy(grabObject);
            }
        }
        return handindex;
    }
    void SetPut()
    {
        if (put && handBlock && jumpcount == 2)
        {
            blockg = blocks[handindex].transform.GetComponentInChildren<block1>();
            if (handindex == 2 && blockg.xr == 90f && blockg.yr == 0 && blockg.zr == 0)
            {
            GameObject instantblock = Instantiate(putblocks[handindex],
            new Vector3(spotx, this.transform.position.y + 1f, spotz - 1f),
            blocks[handindex].transform.rotation);
            }
            else
            {
                GameObject instantblock = Instantiate(putblocks[handindex],
            new Vector3(spotx, this.transform.position.y, spotz),
            blocks[handindex].transform.rotation);
            }
            handBlock = false;
            put = false;

            getblock = null;
            hasblocks[handindex] = false;
            blocks[handindex].SetActive(false);
            ghostblock.SetActive(false);
        }
    }
    void SetCanPut()
    {
        spotx = (int)Mathf.Round(putpos.pos.x);
        spotz = (int)Mathf.Round(putpos.pos.z);
        spoty = (int)Mathf.Round(putpos.pos.y);

        spotxt = (int)Mathf.Round(putpost.pos.x);
        spotzt = (int)Mathf.Round(putpost.pos.z);
        spotyt = (int)Mathf.Round(putpost.pos.y);
    }
    void SetKeepBlock()
    {
        if (keep && handBlock && keepBlock == null)
        {
            keepBlock = blocks[handindex];
            handBlock = false;
            put = false;
            getblock = null;
            hasblocks[handindex] = false;
            handindext = handindex;
            blocks[handindex].SetActive(false);
            ghostblock.SetActive(false);
            keep = false;
        }
        if (keep && handBlock && keepBlock != null)
        {
            hasblocks[handindext] = true;
            hasblocks[handindex] = false;
            put = false;
            getblock = keepBlock;
            blocks[handindex].SetActive(false);
            keepBlock.SetActive(true);
            keepT = keepBlock;
            keepBlock = blocks[handindex];
            blocks[handindex] = keepT;
            keepT = null;
            keep = false;
        }
        if (keep && !handBlock && keepBlock != null)
        {
            handBlock = true;
            put = false;
            blocks[handindex] = keepBlock;
            getblock = blocks[handindex];
            hasblocks[handindex] = true;
            keepBlock.SetActive(true);
            ghostblock.SetActive(true);
            keepBlock = null;
            keep = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpcount = 2;
        }
        if (underB == collision.gameObject)
        {
            jumpcount = 2;
        }
        if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.gameObject.GetComponent<Rigidbody>().velocity.y < 0.1f)
            {
                Debug.Log("사망!");
            }
        }
    }
}
