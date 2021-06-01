using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Block")
        {
            Debug.Log("게임 오버");
        }
    }
}
