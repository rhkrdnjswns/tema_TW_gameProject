using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class Char : MonoBehaviour
{
    int a, b, c; //그냥변수
    int jumpc = 2; //점프가능횟수
    public int handindex; //블록종류
    public int handindext;
    float speed = 10;//속도
    float h;//이동
    float v;//이동
    public float spotx, spoty, spotz; //블록을 놨을때 위치
    bool jump;//점프했는지 확인
    bool grap;//블록 잡을 때 확인
    bool put;//블록놓을 때 확인
    bool keep;
    public bool canup=false;
    public bool handBlock = false;//손에 블록이 있는지 확인
    public GameObject[] blocks;//블록의 종류
    public bool[] hasblocks;//블록활성화
    public GameObject getblock;
    public GameObject ghostblock;
    PutPos putpos;// putpos 받는거
    block block;
    public GameObject grabObject;// 충돌한 블록을 받는것
    public GameObject keepB=null;
    public GameObject keepT = null;
    GameObject underB;// 캐릭터 바닥에 블록이 있는지
   
    public Transform trans;//캐릭터의 transform
    public RaycastHit rayHitd, rayHitf;//
    Vector3 move;// 이동
    Vector3 blockS;
    Rigidbody rigid;// 
    // Start is called before the first frame update
    void Start()
    {
        block=GameObject.Find("Cube").GetComponent<block>();
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody>();
        putpos = GameObject.Find("PutPos").GetComponent<PutPos>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();//버튼 클릭 받는 함수 호출
        Jump();//점프 함수 호출
        Grap();// 잡기함수 호출
        CanPut();// 놓을수 있는지 호출
        Put();//놓는 함수 호출
        Keep();
        move = new Vector3(h, 0, v).normalized;//이동
        transform.position += move * speed * Time.deltaTime;
        transform.LookAt(transform.position + move);
       
    }

    void GetInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        jump = Input.GetButtonDown("Jump");
        keep = Input.GetButtonDown("Keep");
        grap = Input.GetMouseButtonDown(0);
        put = Input.GetMouseButtonDown(1);
    }
    void Jump()//점프 로직
    {
        if (jumpc > 0)
        {
            if (jump)
            {
                rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
                jumpc--;
            }
        }
    }
    int Grap()// 블록을 잡는 함수
    {
        if (grap && grabObject != null && !handBlock&&jumpc==2)// 좌클릭, 충돌한 물체가 있는지, 손에블록이 없는지
        {
            if (grabObject.tag == "Block")
            {
               /* blockS=block.parents.transform.localScale;
                blockS /= 0.5f;
;               ghostblock.transform.localScale =new Vector3(blockS.x, blockS.y, blockS.z);   */
                ghostblock.SetActive(true);
                canup = false;
                block = grabObject.GetComponent<block>();
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
    void Put()//블록을 놓는함수
    {
        if (put && handBlock&&jumpc==2)//우클릭, 블록이 있는지
        {
            Instantiate(blocks[handindex],
            new Vector3(spotx, Mathf.Round(putpos.transform.position.y), spotz),//
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
    void CanPut()// 블록을 놓는 위치 조정
    {
        for (int i = -6; i < 6; i += 2)
        {
            a = i + 1;
            b = i - 1;
            if (i < 0) { c = -1;}
            if (i >= 0) { c = 1; }
            if (b <= Mathf.Floor(putpos.pos.x) && Mathf.Floor(putpos.pos.x) < a)
            {
                spotx = i+c;
            }
            if (b <= Mathf.Floor(putpos.pos.z) && Mathf.Floor(putpos.pos.z) < a)
            {
                spotz = i+c;
            }
        }
    }
   void Keep()
    {
        if (keep&&handBlock&& keepB == null)//손에 블록이 있는데 킵
        {
         keepB = blocks[handindex];//손에있는 블록값 킵에 저장
         handBlock = false;//손에 블록없음
         put = false;//내려놓기 가능활성화
         getblock = null;//손에 블록값 없음
         hasblocks[handindex] = false;//index번째 블록 없음
         handindext = handindex;
         blocks[handindex].SetActive(false);//손에있던블록 비활성화
         keep = false;//킵 기능 활성화
        }
        if (keep && handBlock && keepB != null)//손에 손에 블록,킵한 블록있음
        {
            hasblocks[handindext] = true;
            hasblocks[handindex] = false;
            put = false;//내려놓기 활성화
            getblock = keepB;//손에있는블록값을 킵한블록 값으로 변경
            blocks[handindex].SetActive(false);//손에들고 있는블록 비활성화
            keepB.SetActive(true);//킵한블록 활성화
            keepT = keepB;// 
            keepB = blocks[handindex];//킵한블록값에 손에있는 블록값 저장
            blocks[handindex] = keepT;//손에있는 블록값에 킵한 블록값 저장
            keepT = null;//
            keep = false;//킵기능 활성화
        }
        if (keep && !handBlock && keepB != null) //손에 블록없고 킵한 블록있음
        {
            handBlock = true;//손에 블록있음
            put = false;//내려놓기 활성화
            blocks[handindex] = keepB;//손에있는 블록 값에 킵한 블록값 저장
            getblock = blocks[handindex];//손에있는 블록값 저장
            hasblocks[handindex] = true;//index번째 블록 있음
            keepB.SetActive(true);//킵한블록 활성화
            keepB = null;//킵블록 null
            keep = false;//킵기능 활성화
        }
    }
    void OnCollisionEnter(Collision collision)//충돌 채크 점프,블록
    {
        if (collision.gameObject.tag == "Floor")//점프 횟수 초기화
        {
            jumpc = 2;
           
        }
        if (collision.gameObject.tag == "Block")//충돌한 블록값 저장
        {
            grabObject = collision.gameObject;
            if(underB== collision.gameObject)
            {
                jumpc = 2;
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
    void FreezeRotation()//회전 안하게 하는 함수
    {
        rigid.angularVelocity = Vector3.zero;
    }
    void FixedUpdate()
    {
        FreezeRotation();
        Ray rayd = new Ray();

        rayd.origin = trans.position;

        rayd.direction = -trans.up;

        if (Physics.Raycast(rayd, out rayHitd) && rayHitd.collider.tag == "Block")
        {
            underB = rayHitd.collider.gameObject;
        }
    }
}