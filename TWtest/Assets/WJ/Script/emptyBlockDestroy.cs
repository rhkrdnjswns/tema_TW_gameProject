﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyBlockDestroy : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        if(this.transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
