using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public void Setkeeping()       //다른 클래스에 넣어서 간략화 할 수 있을듯
    {
        if (gameObject.activeSelf == true)
        {
            Debug.Log("집어넣기");
            //gameObject.transform.SetParent(Par.transform);
            transform.parent = GameObject.Find("KeepManager").transform;
            gameObject.SetActive(false);
        }
        else if (gameObject.activeSelf == false)
        {
            Debug.Log("뱉기");
            gameObject.SetActive(true);
        }
    }
}
