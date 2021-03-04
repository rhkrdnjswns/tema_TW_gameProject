using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;         //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
    float hAxis;
    float vAxis;
    Vector3 moveVec;        //움직임

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputUp = false;
    public bool inputDown = false;     //DPad 클릭 여부 선언
    public bool inputFr = false;
    public bool inputBr = false;
    public bool inputFl = false;
    public bool inputBl = false;

    RaycastHit hit;
    float MaxDistance = 1.0f;
    public LayerMask LayerMask; //레이어로 구별

    public GameObject slot;     //가지고있는 블록 슬롯 오브젝트 변수
    public bool Keeptf = false;     //현재 블럭을 가지고있는가? 에대한 변수

    public Sprite KeepImage;
    public Sprite OutputImage;

    // Start is called before the first frame update
    void Start()
    {
        DPad ui = GameObject.FindGameObjectWithTag("Manager").GetComponent<DPad>();
        ui.Init();
    }

    void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position); //진행방향 바라보기
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (inputLeft)
        {
            moveVelocity = Vector3.left;
            transform.LookAt(transform.position + moveVelocity);        //lookat으로 바라보게하기
        }
        else if (inputRight)
        {
            moveVelocity = Vector3.right;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputUp)
        {
            moveVelocity = Vector3.forward;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputDown)
        {
            moveVelocity = Vector3.back;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputFr)
        {
            Debug.Log("1시");
            moveVelocity = new Vector3(1, 0, 1).normalized;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputFl)
        {
            Debug.Log("11시");
            moveVelocity = new Vector3(-1, 0, 1).normalized;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputBr)
        {
            Debug.Log("5시");
            moveVelocity = new Vector3(1, 0, -1).normalized;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputBl)
        {
            Debug.Log("7시");
            moveVelocity = new Vector3(-1, 0, -1).normalized;
            transform.LookAt(transform.position + moveVelocity);
        }
        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    public void Keep()
    {
        float lx = this.transform.position.x;
        float ly = this.transform.position.y;
        float lz = this.transform.position.z;

        if (Keeptf == false)
        {
            Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue, 0.3f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance, LayerMask))    //레이어마스크참조
            {
                if (slot.activeSelf == false)
                {
                    slot.SetActive(true);
                    hit.transform.position = new Vector3(lx, ly + 1.0f, lz);
                    hit.transform.GetComponent<PickUp>().keeping(); //slot의 activeself도 true로
                    Keeptf = true;      //킵해있는 상태로
                    GameObject.Find("KeepButton").GetComponent<Image>().sprite = OutputImage;           //미니맵레이어 충돌해제
                }
                else if (slot.activeSelf == true)
                {
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red; //킵이 불가능한 블록 색칠
                    Debug.Log("꽉참!");
                }
            }
        }
        else if (Keeptf == true)
        {
            GameObject.Find("KeepManager").transform.Find("1").gameObject.transform.position = new Vector3(lx, ly + 1.0f, lz);
            slot.SetActive(false);
            GameObject.Find("KeepManager").transform.Find("1").gameObject.SetActive(true);
            GameObject.Find("KeepManager").transform.Find("1").gameObject.transform.parent = null;     //부모자식 해제
            Keeptf = false;
            GameObject.Find("KeepButton").GetComponent<Image>().sprite = KeepImage;
        }
    }

    public void Hold()
    {
        float lx = this.transform.position.x;
        float ly = this.transform.position.y;
        float lz = this.transform.position.z;

        if (Physics.Raycast(transform.position, transform.forward, out hit, MaxDistance, LayerMask))
        {
            hit.transform.position = new Vector3(lx, ly + 1.0f, lz);
        }
    }
}
