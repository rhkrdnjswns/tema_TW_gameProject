using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost12 : MonoBehaviour
{
    public GameObject ghostb;
    PlayerCtrl cha;
    PutPos putpos;
    bool get = false;

    [SerializeField] private int value;

    private bool xt;
    private bool yt;
    private bool zt;
    public float gxr = 0f;
    public float gyr = 0f;
    public float gzr = 0f;

    private int aaa = 0;
    private int bbb = 0;
    private int ccc = 0;


    // Start is called before the first frame update
    void Start()
    {
        cha = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        putpos = GameObject.Find("GrabCollider").GetComponent<PutPos>();
    }
    void Update()
    {
        ghostb = this.gameObject;
        SavePos();

        SetFirst();
        SetRotat();
    }
    void SavePos()
    {
        if(value == 2)
            this.transform.position = new Vector3(cha.spotx + 1, putpos.pos.y + 0.5f, cha.spotz);
        else
            this.transform.position = new Vector3(cha.spotx, putpos.pos.y, cha.spotz);
    }
    private void SetFirst()
    {
        xt = Input.GetButtonDown("Xturn");//1번
        yt = Input.GetButtonDown("Yturn");//2번
        zt = Input.GetButtonDown("Zturn");//3번
    }
    private void SetRotat()
    {
        get = cha.handBlock;
        if (get)
        {
            if (cha.handindex == value)
            {
                if(value == 2)
                {
                    valuethree();
                }
                else
                {
                    valueonetwo();
                }
                this.transform.rotation = Quaternion.Euler(gxr, gyr, gzr);
            }
        }
    }
    private void valuethree()
    {
        if (xt)
        {
            if (gxr < 45)
            {
                gxr = 90f;
            }
            else
            {
                gxr = 0f;
            }
        }
        if (yt)
        {
            if (gyr < 45)
                gyr = 90f;
            else
                gyr = 0f;
        }
        if (zt)
        {
            if (gzr < 45)
                gzr = 90f;
            else
                gzr = 0f;
        }
    }
    private void valueonetwo()
    {
        if (xt)
        {
            Debug.Log("1");
            if (gxr < 45)
                gxr = 90f;
            else
                gxr = 0f;

        }
        if (yt)
        {
            if (gyr < 45)
                gyr = 90f;
            else
                gyr = 0f;
            Debug.Log("2");

        }
        if (zt)
        {
            if (gzr < 45)
                gzr = 90f;
            else
                gzr = 0f;
            Debug.Log("3");
        }
    }
    // Update is called once per frame
}
