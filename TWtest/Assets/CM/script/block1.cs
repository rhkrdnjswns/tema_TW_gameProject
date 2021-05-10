using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Video;
using Debug = UnityEngine.Debug;
public class block1 : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    Color matColor;
    PlayerCtrl cha;
    public enum Blocktype { fb, sb, tb, rb };
    public Blocktype blocktype;
    public int value;
    public bool up;//블록이 바닥에 닿았는지
    bool get = false;
    bool xt;
    bool yt;
     bool zt;
    //bool firstRay;
   // bool secondRay;
    public float xr = 0f;
    public float yr = 0f;
    public float zr = 0f;
    //float frayl = 2f;
    //float srayl = 2f;
    Vector3 blockdirec;//블록의 방향
   public GameObject mydirec;
    GameObject parents;
    Rigidbody rigid;
    Collider collider;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        cha = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        mydirec = this.gameObject;
        collider = GetComponent<BoxCollider>();
        matColor = mat.color;
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
            if (cha.getblock == this.transform.parent.gameObject)
            {
                if (xt)
                {
                    Debug.Log("1");
                    if (xr < 45)
                        xr = 90f;
                    else
                        xr = 0f;
                    
                }
                if (yt)
                {
                    if (yr < 45)
                        yr = 90f;
                    else
                        yr = 0f;
                    Debug.Log("2");
                    
                }
                if (zt)
                {
                    if (zr < 45)
                        zr = 90f;
                    else
                        zr = 0f;
                    Debug.Log("3");
                }
                this.transform.parent.rotation = Quaternion.Euler(xr, yr, zr);
            }
        }
        if (!get)
        {
            matColor.a = 1f;
            this.mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1.0f); ;
         
        }
    }
    public void BlockRo()
    {
       
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
    }
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
    }*/
}