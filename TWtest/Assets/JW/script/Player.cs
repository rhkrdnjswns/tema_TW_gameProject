using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       //UI관련 메서드를 쓰려면 필수이다

public class Player : MonoBehaviour
{
    private float speed = 5;//속도

    private GameObject keepPocket;

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputFront = false;
    public bool inputBack = false;
    public bool inputFR = false;
    public bool inputBR = false;
    public bool inputFL = false;
    public bool inputBL = false;        //DPad 클릭 여부를 알수있는 bool변수 선언

    private RaycastHit hit;
    private float maxDistance = 1.0f;           //레이캐스트 관련, 합치면 킵하는데 레이캐스트는 필요 없을듯
    [SerializeField] private LayerMask layerMask; //레이어로 구별

    [SerializeField] private GameObject keepslot;     //가지고있는 블록 슬롯 오브젝트 변수
    private bool keeptf = false;     //현재 블럭을 가지고있는가? 에대한 변수

    [SerializeField] private Sprite keepButtonImage;        //킵할수 있을때 킵 버튼의 이미지
    [SerializeField] private Sprite outputButtonImage;      //꺼낼 수 있을때 킵 버튼의 이미지

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

    private void Move()
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
        else if (inputFront)
        {
            moveVelocity = Vector3.forward;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputBack)
        {
            moveVelocity = Vector3.back;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputFR)
        {
            moveVelocity = new Vector3(1, 0, 1).normalized;     //대각선 이동에는 normalized 사용
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputFL)
        {
            moveVelocity = new Vector3(-1, 0, 1).normalized;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputBR)
        {
            moveVelocity = new Vector3(1, 0, -1).normalized;
            transform.LookAt(transform.position + moveVelocity);
        }
        else if (inputBL)
        {
            moveVelocity = new Vector3(-1, 0, -1).normalized;
            transform.LookAt(transform.position + moveVelocity);
        }
        transform.position += moveVelocity * speed * Time.deltaTime;        //움직임
    }

    public void Keep()
    {
        float lx = this.transform.position.x;
        float ly = this.transform.position.y;
        float lz = this.transform.position.z;       //Player 오브젝트의 현재 위치를 받와서 저장하는 변수

        if (keeptf == false)
        {
            Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.blue, 0.3f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))    //레이어마스크참조
            {
                if (keepslot.activeSelf == false)
                {
                    keepslot.SetActive(true);
                    hit.transform.position = new Vector3(lx, ly + 1.0f, lz);
                    hit.transform.GetComponent<PickUp>().Setkeeping(); //slot의 activeself도 true로
                    keeptf = true;      //킵해있는 상태로
                    GameObject.Find("KeepButton").GetComponent<Image>().sprite = outputButtonImage;           //미니맵레이어 충돌해제
                }
                else if (keepslot.activeSelf == true)
                {
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red; //킵이 불가능한 블록 색칠
                    Debug.Log("꽉참!");
                }
            }
        }
        else if (keeptf == true)
        {
            keepPocket = GameObject.Find("KeepManager").transform.Find("1").gameObject;
            keepPocket.transform.position = new Vector3(lx, ly + 1.0f, lz);
            keepslot.SetActive(false);
            keepPocket.SetActive(true);
            keepPocket.transform.parent = null;     //부모자식 해제
            keeptf = false;
            GameObject.Find("KeepButton").GetComponent<Image>().sprite = keepButtonImage;
        }
    }

    public void Hold()      //집기, 창민이 스크립트로 대체
    {
        float lx = this.transform.position.x;
        float ly = this.transform.position.y;
        float lz = this.transform.position.z;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))   //레이캐스트를 쏜다
            hit.transform.position = new Vector3(lx, ly + 1.0f, lz);
    }
}
