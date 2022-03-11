﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Block;
    private GameObject currentBlock;
    [SerializeField]
    private GameObject GhostBlock;
    private GameObject currentGhostBlock;

    private int level = 1;
    private float[] waitTimes = { 10f, 18f, 24f };
    private float waitTime = 10f;

    private Transform transform;
    private Vector3 PreviousPos = Vector3.zero;

    public int Level
    {
        set
        {
            this.level = value;
        }
    }
    public GameObject getCurrentBlock()
    {
        return currentBlock;
    }
    private void Awake()
    {
        transform = GetComponent<Transform>();
        
    }
    private void Start()
    {
        StartCoroutine(createNewBlock());
    }
    private void Update()
    {
        
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            for (int x = 0; x < Grid.stageX; x++)
            {
                for (int z = 0; z < Grid.stageZ; z++)
                {
                    transform.position = new Vector3(x, transform.position.y, z);
                    currentBlock = Instantiate(Block, transform.position, Quaternion.identity);
                    currentGhostBlock = Instantiate(GhostBlock, transform.position, currentBlock.transform.rotation);
                    currentGhostBlock.GetComponent<Ghost>().setCurrnetBlockForGhost(currentBlock);
                }
            }
        }*/
        
    }
        
 
    /*public void createNewBlock(int level)
    {
        int RandomPosX = Random.Range(0, Grid.stageX);
        int RandomPosZ = Random.Range(0, Grid.stageZ);
        
        int blockNum = Random.Range(0, 4);
        transform.position = new Vector3(RandomPosX, transform.position.y, RandomPosZ);
        transform.position = new Vector3(RandomPosX, transform.position.y, RandomPosZ);
        if(level > 1)
            if (PreviousPos != Vector3.zero)
                if(transform.position == PreviousPos)
                {
                    int _RandomPosX = Random.Range(0, Grid.stageX);
                    int _RandomPosZ = Random.Range(0, Grid.stageZ);
                    transform.position = new Vector3(_RandomPosX, transform.position.y, _RandomPosZ);
                }
        currentBlock = ObjectPool.GetBlock(blockNum,transform).gameObject;
        currentGhostBlock = ObjectPool.GetGhost(blockNum).gameObject;
        currentGhostBlock.transform.position = currentBlock.transform.position;
        currentGhostBlock.transform.rotation = currentBlock.transform.rotation;
        currentGhostBlock.GetComponent<Ghost>().setCurrnetBlockForGhost(currentBlock);
        ScoreManager.Instance.ScoreUp(false);

        PreviousPos = transform.position;
        
    }*/
    public IEnumerator createNewBlock()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            int RandomPosX = Random.Range(0, Grid.stageX);
            int RandomPosZ = Random.Range(0, Grid.stageZ);

            int blockNum = Random.Range(0, 4);
            transform.position = new Vector3(RandomPosX, transform.position.y, RandomPosZ);
            transform.position = new Vector3(RandomPosX, transform.position.y, RandomPosZ);
            for(int i = 0; i < level; i++)
            {
                if (PreviousPos != Vector3.zero)
                {
                    if (transform.position == PreviousPos)
                    {
                        int _RandomPosX = Random.Range(0, Grid.stageX);
                        int _RandomPosZ = Random.Range(0, Grid.stageZ);
                        transform.position = new Vector3(_RandomPosX, transform.position.y, _RandomPosZ);
                    }
                }

                currentBlock = ObjectPool.GetBlock(blockNum, transform).gameObject;
                currentGhostBlock = ObjectPool.GetGhost(blockNum).gameObject;
                currentGhostBlock.transform.position = currentBlock.transform.position;
                currentGhostBlock.transform.rotation = currentBlock.transform.rotation;
                currentGhostBlock.GetComponent<Ghost>().setCurrnetBlockForGhost(currentBlock);                

                PreviousPos = transform.position;
            }          
            yield return new WaitForSeconds(waitTimes[level-1]);
        }
        

    }
}