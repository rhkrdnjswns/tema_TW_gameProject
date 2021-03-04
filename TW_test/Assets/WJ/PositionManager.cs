using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    List<int> xValues = new List<int>();
    List<int> zValues = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            SetRandomValue();
            
        }
    }

    /*void SetRandomValue()
    {
        bool flag = true;
        int random = Random.Range(0, 4);
        if (xValues.Count > 0)
        {
            for (int i = 0; i < xValues.Count; i++)
            {
                if (xValues[i] == random)
                {
                    SetRandomValue();
                    flag = false;
                    break;
                }
            }
        }
        if (flag)
        {
            xValues.Add(random);
            Debug.Log(random);
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            xValues.Clear();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < 4; i++)
            {
                SetRandomValue();

            }
        }
        
        for (int i = 0; i < xValues.Count; i++)
        {
            //Debug.Log(xValues[i]);
        }
        
    }
    void SetRandomValue()
    {
        int randomX = Random.Range(0, 2);
        int randomZ = Random.Range(0, 2);
        xValues.Add(randomX);
        zValues.Add(randomZ);
        Debug.Log(randomX.ToString()+randomZ.ToString());
        
    }
}
