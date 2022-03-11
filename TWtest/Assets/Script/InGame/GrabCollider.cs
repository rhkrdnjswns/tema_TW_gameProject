using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GrabCollider : MonoBehaviour
{
    private bool isTriggerBlock = false;
    private GameObject collidedBlock;
    public bool IsTriggerBlock { get => isTriggerBlock; set => isTriggerBlock = value; }
    public GameObject CollidedBlock { get => collidedBlock; set => collidedBlock = value; }
   
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            if (other.tag == "Block")
            {
                if (other.transform.parent.gameObject != null)
                {
                    var obj = other.transform.parent.gameObject;
                    if (obj != null)
                    {
                        isTriggerBlock = true;
                        collidedBlock = obj;
                        Debug.Log(isTriggerBlock);
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null)
        {
            if (other.tag == "Block")
            {
                var obj = other.transform.parent.gameObject;
                if (obj != null)
                {
                    isTriggerBlock = false;
                    collidedBlock = null;
                    Debug.Log(isTriggerBlock);
                }
            }
        }
    }
}
