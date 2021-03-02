using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private SpawnerTetris[] Spawner;
    // Start is called before the first frame update
    void Start()
    {
        Spawner = GetComponentsInChildren<SpawnerTetris>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Spawner[Random.Range(0, Spawner.Length)].NewTetris();
        }
    }
}
