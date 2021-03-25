using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Blocks;
    private GameObject currentBlock;
    [SerializeField]
    private GameObject[] GhostBlocks;
    private GameObject currentGhostBlock;

    private Vector3 PreviousPos = Vector3.zero;
    public GameObject getCurrentBlock()
    {
        return currentBlock;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            createNewBlock(0);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int x = 0; x < Grid.stageX; x++)
            {
                for (int z = 0; z < Grid.stageZ; z++)
                {
                    transform.position = new Vector3(x, transform.position.y, z);
                    currentBlock = Instantiate(Blocks[0], transform.position, Quaternion.identity);
                    currentGhostBlock = Instantiate(GhostBlocks[0], transform.position, currentBlock.transform.rotation);
                    currentGhostBlock.GetComponent<Ghost>().setCurrnetBlockForGhost(currentBlock);
                }
            }
        }
        
    }
    public void createNewBlock(int level)
    {
        int RandomPosX = Random.Range(0, Grid.stageX);
        int RandomPosZ = Random.Range(0, Grid.stageZ);
        int blockNum = Random.Range(0, Blocks.Length);
        transform.position = new Vector3(RandomPosX, transform.position.y, RandomPosZ);
        if(level > 1)
            if (PreviousPos != Vector3.zero)
                if(transform.position == PreviousPos)
                {
                    int _RandomPosX = Random.Range(0, Grid.stageX);
                    int _RandomPosZ = Random.Range(0, Grid.stageZ);
                    transform.position = new Vector3(_RandomPosX, transform.position.y, _RandomPosZ);
                } 
        currentBlock = Instantiate(Blocks[blockNum], transform.position, Quaternion.identity);
        currentGhostBlock = Instantiate(GhostBlocks[blockNum], transform.position, currentBlock.transform.rotation);
        currentGhostBlock.GetComponent<Ghost>().setCurrnetBlockForGhost(currentBlock);

        PreviousPos = transform.position;
        
    }
}
