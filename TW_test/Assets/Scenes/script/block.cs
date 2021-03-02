using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Video;

public class block : MonoBehaviour
{
    Transform mytransform;
    MeshRenderer mesh;
    Material mat;
    Color matColor;
    public GameObject thisblock, parents;
    public enum Blocktype { fb, sb, tb };
    public Blocktype blocktype;
    Char cha;
    bool get;
    public int value;
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
        mytransform = GetComponent<Transform>();
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
        First();
        Rotat();
       
    }
    void First()
    {
        xt = Input.GetButtonDown("Xturn");
        yt = Input.GetButtonDown("Yturn");
        zt = Input.GetButtonDown("Zturn");
    }
    void Rotat()
    {
        get = cha.handBlock;
        if (get)
        {
            rigid.isKinematic = true;
            if (cha.getblock == this.parents)
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
                parents.transform.rotation = Quaternion.Euler(xr, yr, zr);
                rigid.isKinematic = true;
            }
        }
        if (!get)
        {
            matColor.a = 1f;
            this.mat.color = matColor;
        }
    }
    void UpFloor()
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
        UpFloor();
    }
}