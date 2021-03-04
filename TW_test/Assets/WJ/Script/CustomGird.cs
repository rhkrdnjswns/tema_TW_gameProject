using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGird : MonoBehaviour
{
    public GameObject target;
    public GameObject structuer;
    Vector3 truePos;
    public float gridSize;
   
    void LateUpdate()
    {
        truePos.x = Mathf.Floor(target.transform.position.x / gridSize) * gridSize;
        truePos.y = this.transform.position.y;
        truePos.z = Mathf.Floor(target.transform.position.z / gridSize) * gridSize;

        structuer.transform.position = truePos;
    }
}
