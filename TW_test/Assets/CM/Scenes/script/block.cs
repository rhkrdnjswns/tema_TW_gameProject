using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Video;

public class block : MonoBehaviour
{
   
    MeshRenderer mesh;//색바꾸기 위해 
    Material mat;//색바꾸는 변수
    Color matColor;//색바꾸는 변수
    public GameObject thisblock, parents;// 이블록, 부모의 게임오브젝트
    public enum Blocktype { fb, sb, tb };//블록의 종류
    public Blocktype blocktype;//
    Char cha;
    bool get;//손에 블록이 있는지
    public int value;//몇번째 블록인지
    public bool up;//블록이 바닥에 닿았는지
    bool xt;
    bool yt;
    bool zt;
    bool firstRay;
    bool secondRay;
    bool findS;
 
   
    float xr = 0f;
    float yr = 0f;
    float zr = 0f;
    public float frayl = 2f;
    float srayl = 2f;
    GameObject myObject;
    GameObject tri;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        
        parents = transform.parent.gameObject;
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        cha = GameObject.Find("PlayerCon").GetComponent<Char>();
        matColor = mat.color;
       
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        First();//입력받는 함수
        Rotat();//회전 함수
       
    }
    void First()
    {
        xt = Input.GetButtonDown("Xturn");//1번
        yt = Input.GetButtonDown("Yturn");//2번
        zt = Input.GetButtonDown("Zturn");//3번
    }
    void Rotat()
    {
        get = cha.handBlock;//플레이어 손에 블록이 있는지
        if (get)
        {
            rigid.isKinematic = true;
            if (cha.getblock == this.parents)//손에 있는 블록이 자신인지
            {
                if (xt)
                {
                    xr += 90f; //x로 90도
                }
                if (yt)
                {
                    yr += 90f;//y로 90도
                }
                if (zt)
                {
                    zr += 90f;//z로 90도
                }
                rigid.isKinematic = false;
                parents.transform.rotation = Quaternion.Euler(xr, yr, zr);// 회전
                rigid.isKinematic = true;
            }
        }
        if (!get)
        {
            matColor.a = 1f;//손에 있을때는 반투명 이지만 내려 놓을땐 불투명
            this.mat.color = matColor;
        }
    }
    void UpFloor()//블록이 땅속으로 들어가는걸 막는 스크립트 지워질 예정
    {
        firstRay = Physics.Raycast(transform.position, -transform.up, frayl,LayerMask.GetMask("Floor"));
        secondRay= Physics.Raycast(transform.position, -transform.up, srayl, LayerMask.GetMask("Floor"));
        if (firstRay&&secondRay)
        {
            parents.transform.position = new Vector3(parents.transform.position.x, frayl, parents.transform.position.z);
        }
        if(!firstRay&&secondRay)
        {
            parents.transform.position = new Vector3(parents.transform.position.x, srayl, parents.transform.position.z);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == "Player")
         {
            myObject= collision.gameObject;
         }     
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myObject = null;
        }
    }
     void FixedUpdate()
    {
        //UpFloor();
    }
}