using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1 : MonoBehaviour
{
    public GameObject ghostb;
    Char cha;
    PutPos putpos;
    // Start is called before the first frame update
    void Start()
    {
        cha = GameObject.Find("PlayerCon").GetComponent<Char>();
        putpos = GameObject.Find("PutPos").GetComponent<PutPos>();
    }
    void Update()
    {
        ghostb = this.gameObject;
        SavePos();
    }
    void SavePos()
    {
        this.transform.position = new Vector3(cha.spotx, putpos.pos.y, cha.spotz);
    }
    // Update is called once per frame
}
