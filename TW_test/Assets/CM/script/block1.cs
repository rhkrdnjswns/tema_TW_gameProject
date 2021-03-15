using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Video;

public class block1 : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    Color matColor;
    Char cha;
    public enum Blocktype { fb, sb, tb };
    public Blocktype blocktype;
    public int value;
    public bool up;//블록이 바닥에 닿았는지
    bool get;
    bool xt;
    bool yt;
    bool zt;
    bool firstRay;
    bool secondRay;
    float xr = 0f;
    float yr = 0f;
    float zr = 0f;
    public float frayl = 2f;
    float srayl = 2f;
    GameObject myObject;
    public GameObject parents;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {

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
        SetFirst();
        SetRotat();
    }
    void SetFirst()
    {
        xt = Input.GetButtonDown("Xturn");//1번
        yt = Input.GetButtonDown("Yturn");//2번
        zt = Input.GetButtonDown("Zturn");//3번
    }
    void SetRotat()
    {
        get = cha.handBlock;
        if (get)
        {
            rigid.isKinematic = true;
            if (cha.getblock == this.gameObject)
            {
                if (xt)
                {
                    xr += 90f;
                }
                if (yt)
                {
                    yr += 90f;
                }
                if (zt)
                {
                    zr += 90f;
                }
                rigid.isKinematic = false;
                this.transform.rotation = Quaternion.Euler(xr, yr, zr);//블록 회전
                rigid.isKinematic = true;
            }
        }
        if (!get)
        {
            matColor.a = 1f;
            this.mat.color = matColor;
        }
    }
    
   /* void SetUpFloor()//블록이 끼이는 버그 수정용 앞으로 지울 예정
    {
        firstRay = Physics.Raycast(transform.position, -transform.up, frayl, LayerMask.GetMask("Floor"));
        secondRay = Physics.Raycast(transform.position, -transform.up, srayl, LayerMask.GetMask("Floor"));
        if (firstRay && secondRay)
        {
            parents.transform.position = new Vector3(parents.transform.position.x, frayl, parents.transform.position.z);
        }
        if (!firstRay && secondRay)
        {
            parents.transform.position = new Vector3(parents.transform.position.x, srayl, parents.transform.position.z);
        }
    }*/
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myObject = collision.gameObject;
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
        //SetUpFloor();
    }
}