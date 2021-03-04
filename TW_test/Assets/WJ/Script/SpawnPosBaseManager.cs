using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosBaseManager : MonoBehaviour
{
    [SerializeField]
    private SpawnManager[] SpM;
    int level = 1;
    int StageCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpM = GetComponentsInChildren<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnManage();
            StageCount++;
            if(StageCount > 2)
            {
                StageCount = 0;
                //level++;
            }
        }
    }
    void SpawnManage()
    {
        for (int i = 0; i < level; i++)
        {
            SpM[Random.Range(0, SpM.Length)].CreateBlock();
        }
        
    }
}
