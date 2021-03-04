using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int level = 1;
    [SerializeField]
    private Spanwer[] spawner;
    

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponentsInChildren<Spanwer>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    public void CreateBlock()
    {
        
        for (int i = 0; i < level; i++)
        {
            int R = Random.Range(0, spawner.Length);
            spawner[R].spawnNext();
            
        }
    }
}
