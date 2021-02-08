using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instance : MonoBehaviour
{
    test t1 = new test(1, "테스트1");
    test t2 = new test(2, "테스트2");
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(t1.testCount + t1.testName);            
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(t2.testCount + t2.testName);
        }
    }
}
