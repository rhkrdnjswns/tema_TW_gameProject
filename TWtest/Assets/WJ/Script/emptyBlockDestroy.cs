using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyBlockDestroy : MonoBehaviour
{
    private Block block;

    private int count = 0;
    private void Awake()
    {
        block = GetComponent<Block>();
    }
    // Update is called once per frame
    void Update()
    {
        CheckChildForReturn();
    }
    private void CheckChildForReturn()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf == false)
            {
                count++;
            }
        }
        if (count == transform.childCount)
        {
            ObjectPool.ReturnObject(block);
        }
    }
}
