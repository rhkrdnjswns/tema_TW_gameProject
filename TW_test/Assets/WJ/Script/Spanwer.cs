﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanwer : MonoBehaviour
{
    public GameObject[] groups;
    

    
    // Start is called before the first frame update
    void Start()
    {

        
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnNext()
    {
        int i = Random.Range(0, groups.Length);
        Instantiate(groups[i], transform.position, Quaternion.identity);
    }
}
