using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Char : MonoBehaviour
{
    int a, b, c, d; //그냥변수
    int jump_count = 2; //점프가능횟수
    public int handindex; //블록종류
    public int handindext;//블록종류 저장
    public int spotx, spoty, spotz; //블록이 놓일 위치
    float speed = 10;//속도
    float player_horizontal;//x이동
    float player_vectical;//z이동
    bool jump;//점프했는지 확인
    bool grap;//블록 잡을 때 확인
    bool put;//블록놓을 때 확인
    bool keep;//잡았는지
    bool canput = true;//블록놓을수있는지
    bool cangrap;
    public bool canup = false;//블록이 낑기는 현상 수정용 삭제될 변수
    public bool handBlock = false;//손에 블록이 있는지 확인
    public bool[] hasblocks;//블록활성화
    public GameObject[] blocks;//블록의 종류
    public GameObject getblock;//손에 있는 블록정보 저장용 변수
    public GameObject ghostblock;//블록이 놓일 위치를 나타내는 오브젝트
    public GameObject grabObject;// 충돌한 블록을 받는것
    public GameObject keepBlock = null;//킵한 블록의 오브젝트
    public GameObject keepT = null;// 킵한블록의 오브젝트를 저장하는 변수
    GameObject underB,forwardB;// 캐릭터 바닥에,앞에 블록이 있는지
    public Transform trans;//캐릭터의 transform
    public RaycastHit rayHitdown, rayHitforward;//
    PutPos putpos;//class putpos 받는거
    block1 block;//class block
    tetrisblock tetrisblock;//class tetrisblock
    Vector3 move;// 이동
    Rigidbody rigid;// 
    // Start is called before the first frame update
    void Start()
    {
        block = GameObject.Find("Cube").GetComponent<block1>();
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody>();
        putpos = GameObject.Find("PutPos").GetComponent<PutPos>();
       // tetrisblock = GameObject.Find("Block1").GetComponent<tetrisblock>();
    }
    // Update is called once per frame
    void Update()
    {
        SetInput();//버튼 클릭 받는 함수 호출
        SetJump();//점프 함수 호출
        CanGrap();
        GetGrap();// 잡기함수 호출
        SetCanPut();// 놓을수 있는지 호출
        SetPut();//놓는 함수 호출
        SetKeepBlock();
        SetMove();//이동관련 함수
    }
    void SetMove()
    {   // 스테이지 밖으로 못나가게 하는 제어문
        if (this.transform.position.x < tetrisblock.X || this.transform.position.x > tetrisblock.X || this.transform.position.z < tetrisblock.Z || this.transform.position.z > tetrisblock.Z)
        {
            move = Vector3.zero;
        }
        move = new Vector3(player_horizontal, 0, player_vectical).normalized;//이동
        transform.position += move * speed * Time.deltaTime;
        transform.LookAt(transform.position + move);
    }
    void SetInput()
    {
        player_horizontal = Input.GetAxisRaw("Horizontal");
        player_vectical = Input.GetAxisRaw("Vertical");
        jump = Input.GetButtonDown("Jump");
        keep = Input.GetButtonDown("Keep");//c눌렀을 때
        grap = Input.GetMouseButtonDown(0);
        put = Input.GetMouseButtonDown(1);
    }
    void SetJump()//점프 로직
    {
        if (jump_count > 0)
        {
            if (jump)
            {
                rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
                jump_count--;
            }
        }
    }
    int GetGrap()// 블록을 잡는 함수
    {
        if (grap && grabObject != null && !handBlock && jump_count == 2&&cangrap)// 좌클릭, 충돌한 물체가 있는지, 손에블록이 없는지
        {
            if (grabObject.tag == "Block")
            {
                /* blockS=block.parents.transform.localScale;
                 blockS /= 0.5f;
 ;               ghostblock.transform.localScale =new Vector3(blockS.x, blockS.y, blockS.z);   */
                ghostblock.SetActive(true);
                canup = false;
                block = grabObject.GetComponent<block1>();
                handindex = block.value;// value 블록의 종류
                hasblocks[handindex] = true;//
                handBlock = true;
                put = false;
                getblock = blocks[handindex];
                Destroy(grabObject);//잡은블록 제거
                if (handindex == 0) { blocks[0].SetActive(true); }
                if (handindex == 1) { blocks[1].SetActive(true); }
                if (handindex == 2) { blocks[2].SetActive(true); }
            }
        }
        return handindex;// put할때 블록 종류 기억
    }
    void SetPut()//블록을 놓는함수
    {
        if (put && handBlock && jump_count == 2 /*&& canput*/)//우클릭, 블록이 있는지, 블록놓을수있는지
        {
            Instantiate(blocks[handindex],
            new Vector3(spotx, spoty, spotz),//
            blocks[handindex].transform.rotation);
            handBlock = false;
            put = false;
            canup = true;
            getblock = null;
            hasblocks[handindex] = false;
            blocks[handindex].SetActive(false);
            ghostblock.SetActive(false);
        }
    }
    void SetCanPut()// 블록을 놓는 위치 조정
    {
        spotx = (int)Mathf.Round(putpos.pos.x);
        spotz = (int)Mathf.Round(putpos.pos.z);
        spoty = (int)Mathf.Round(putpos.pos.y);
       /* if (tetrisblock.grid[spotz, spoty, spotx] != null)//놓을자리에 블록이 있는지
        {
            canput = false;
        }
        else canput = true;*/
    }
    void SetKeepBlock()
    {
        if (keep && handBlock && keepBlock == null)//손에 블록이 있는데 킵
        {
            keepBlock = blocks[handindex];//손에있는 블록값 킵에 저장
            handBlock = false;//손에 블록없음
            put = false;//내려놓기 가능활성화
            getblock = null;//손에 블록값 없음
            hasblocks[handindex] = false;//index번째 블록 없음
            handindext = handindex;//손에 있는 블록 값 다른 곳에 저장
            blocks[handindex].SetActive(false);//손에있던블록 비활성화
            keep = false;//킵 기능 활성화
        }
        if (keep && handBlock && keepBlock != null)//손에 손에 블록,킵한 블록있음
        {
            hasblocks[handindext] = true;
            hasblocks[handindex] = false;
            put = false;//내려놓기 활성화
            getblock = keepBlock;//손에있는블록값을 킵한블록 값으로 변경
            blocks[handindex].SetActive(false);//손에들고 있는블록 비활성화
            keepBlock.SetActive(true);//킵한블록 활성화
            keepT = keepBlock;//킵한 블록값 다른 곳에 저장
            keepBlock = blocks[handindex];//킵한블록값에 손에있는 블록값 저장
            blocks[handindex] = keepT;//손에있는 블록값에 킵한 블록값 저장
            keepT = null;//
            keep = false;//킵기능 활성화
        }
        if (keep && !handBlock && keepBlock != null) //손에 블록없고 킵한 블록있음
        {
            handBlock = true;//손에 블록있음
            put = false;//내려놓기 활성화
            blocks[handindex] = keepBlock;//손에있는 블록 값에 킵한 블록값 저장
            getblock = blocks[handindex];//손에있는 블록값 저장
            hasblocks[handindex] = true;//index번째 블록 있음
            keepBlock.SetActive(true);//킵한블록 활성화
            keepBlock = null;//킵블록 null
            keep = false;//킵기능 활성화
        }
    }
  void CanGrap()//앞에있는 블록만 집을수 있게
    {
        if(Physics.Raycast(transform.position,transform.forward,out rayHitforward,5))
        {
            forwardB = rayHitforward.collider.gameObject;
            if (grabObject == forwardB) { cangrap= true; }
        }
        cangrap= false;
    }
    void OnCollisionEnter(Collision collision)//충돌 채크 점프,블록
    {
        if (collision.gameObject.tag == "Floor")//점프 횟수 초기화
        {
            jump_count = 2;
        }
        if (collision.gameObject.tag == "Block")//충돌한 블록값 저장
        {
            grabObject = collision.gameObject;
            if (underB == collision.gameObject)//주인공이 떨어진 블록위에 있을때 점프 초기화
            {
                jump_count = 2;
            }
        }
    }
    void OnCollisionExit(Collision collision)// 충돌채크 블록
    {
        if (collision.gameObject.tag == "Block")
        {
            grabObject = null;
        }
    }
    void SetFreezeRotation()//주인공이 강제로 회전하는걸 막는 메서드 
    {
        rigid.angularVelocity = Vector3.zero;
    }
    void FixedUpdate()
    {
        SetFreezeRotation();
        Ray rayd = new Ray();
        rayd.origin = trans.position;
        rayd.direction = -trans.up;
        if (Physics.Raycast(rayd, out rayHitdown) && rayHitdown.collider.tag == "Block")
        {
            underB = rayHitdown.collider.gameObject;
        }
    }
}