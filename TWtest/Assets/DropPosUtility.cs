using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPosUtility : MonoBehaviour
{
    private int roundX;
    private int roundZ;
    [SerializeField] private GameObject ghostPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundX = Mathf.RoundToInt(transform.position.x);
        roundZ = Mathf.RoundToInt(transform.position.z);
        if (roundX >= Grid.stageX)
        {
            ghostPos.SetActive(false);
        }
        else if (roundX < 0)
        {
            ghostPos.SetActive(false);
        }
        else if (roundZ >= Grid.stageZ)
        {
            ghostPos.SetActive(false);
        }
        else if (roundZ < 0)
        {
            ghostPos.SetActive(false);
        }
        else
        {
            ghostPos.SetActive(true);
        }

    }
}

