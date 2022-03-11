using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpEvent : MonoBehaviour
{
    private PCTRLTest player;

    private void Awake()
    {
        player = GetComponentInParent<PCTRLTest>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("닿아있음");
        if(other.tag != "Player")
        {
            player.IsJump = false;
            GetComponent<BoxCollider>().enabled = false;
        }
        
    }


}
