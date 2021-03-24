using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutPos : MonoBehaviour
{
    public Vector3 pos;// 자기위치 
    public GameObject forwardObject;
    // Start is called before the first frame update
  
    void Update()
    {
        pos = this.gameObject.transform.position;//자신의 위치 계속 초기화
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            if (other.gameObject != null)
            {
                forwardObject = other.transform.parent.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Block")
        {
            forwardObject = null;
        }
    }
}

