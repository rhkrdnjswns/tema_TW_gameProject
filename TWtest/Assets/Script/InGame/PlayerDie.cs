using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private ButtonManager btnMgr;

    private void Awake()
    {
        btnMgr = FindObjectOfType<ButtonManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Block")
        {
            Debug.Log("사망");
            btnMgr.GameOver();
        }
    }
}
