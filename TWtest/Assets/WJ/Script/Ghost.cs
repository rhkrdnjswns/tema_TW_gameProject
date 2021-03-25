using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Block block;
    private GameObject currentBlockForGhost;

    public void setCurrnetBlockForGhost(GameObject currentBlock)
    {
        this.currentBlockForGhost = currentBlock;
    }
    // Start is called before the first frame update
    void Start()
    {
        block = currentBlockForGhost.GetComponent<Block>();
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundZ = Mathf.RoundToInt(children.transform.position.z);
            if (roundZ >= Grid.stageZ)
            {
                transform.position += new Vector3(0, 0, -1);

            }
            else if (roundZ < 0)
            {
                transform.position += new Vector3(0, 0, 1);
            }
            else if (roundX >= Grid.stageX)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if (roundX < 0)
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        while (isValidGridPos())
        {
            transform.position += new Vector3(0, -1, 0);
        }
        transform.position += new Vector3(0, 1, 0);

        DestroyGhost();
    }
    private void DestroyGhost()
    {
        if (currentBlockForGhost != null)
        {
            if (!block.isValidMove())
            {
                Destroy(this.gameObject);
            }
        }
    }
    private bool isValidGridPos()
    {
        foreach (Transform children in transform) 
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundZ = Mathf.RoundToInt(children.transform.position.z);
            int roundY = Mathf.RoundToInt(children.transform.position.y);                                                                                                                          
            if (roundX < 0 || roundX >= Grid.stageX || roundZ < 0 || roundZ >= Grid.stageZ || roundY <= 0 || roundY >= Grid.stageY) 
            {
                return false;
            }
            var Spawner = GameObject.FindGameObjectWithTag("BlockSpawner"); 
            var currentBlock = Spawner.GetComponent<BlockSpawner>().getCurrentBlock(); 
            if (Grid.grid[roundX, roundZ, roundY] != null) 
            {
                if (Grid.grid[roundX, roundZ, roundY].parent != currentBlock.transform) 
                    return false;
            }
        }
        return true;
    }
}
