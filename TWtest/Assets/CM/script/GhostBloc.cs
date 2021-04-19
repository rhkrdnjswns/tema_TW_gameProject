using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBloc : MonoBehaviour
{

    PlayerCtrl playerctrl;
    Block block;
    PutPos putpos;
    BlockChildT blockchildt;
   public GameObject grabObject;
    public int x=1;
    int childx;
    int childy;
    int childz;
    int[,,] childspot;
    int blockcount;
    GameObject[] child;
    bool handblock = false;
    bool canput = false;
    bool upblock;
    bool downblock;
    [SerializeField] GameObject[] ghostblocks;
    [SerializeField] private Transform dropPos;
    [SerializeField] GameObject GrabCollider;
    // Update is called once per frame
    private void Start()
    {
        playerctrl= GameObject.Find("Player").GetComponent<PlayerCtrl>();
        putpos = GameObject.Find("GrabCollider").GetComponent<PutPos>();
    }
    void Update()
    {
        grabObject = putpos.forwardObject;
        Moving();
        PutBlock();
        Ghost();
      //  CanPut();
    }
    void CanPut()
    {
        if (handblock)
        {
            for (int i = 0; i < blockcount; i++)
            {
                childx = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.x- (int)this.transform.GetChild(0).transform.position.x;
                childy = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.y- (int)this.transform.GetChild(0).transform.position.y;
                childz = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.z- (int)this.transform.GetChild(0).transform.position.z;
                if (Grid.grid[childx, childy, childz] == null)
                {
                    canput = true;//블록 놓기 가능
                }
                else
                {
                    canput = false;
                    Debug.Log("불가");
                }
            }
        }
    }
    void Ghost()
    {
        if (playerctrl.getblock != null)
        {
            // block = grabObject.GetComponent<Block>();
            for (int i = 0; i < playerctrl.getblock.transform.GetChild(0).transform.childCount; i++)
            {
                 //   child[i] = grabObject.transform.GetChild(i).gameObject;
               childx = Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.GetChild(i).transform.position.x)- Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.position.x);
               childy = Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.GetChild(i).transform.position.y)- Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.position.y);
               childz = Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.GetChild(i).transform.position.z)- Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.position.z);
               
                ghostblocks[i].SetActive(true);
                ghostblocks[i].transform.position = playerctrl.getblock.transform.GetChild(0).transform.GetChild(i).transform.position;
                Grid.grid[childx, childy, childz] = null;
                handblock = true;
                blockcount = i;
            }
        }
    }
    void Moving()
    {
        this.transform.position = new Vector3((int)Mathf.Round(dropPos.position.x), (int)Mathf.Round(dropPos.position.y), (int)Mathf.Round(dropPos.position.z));
        /*if (playerctrl.getblock)
            for (int i = 0; i < blockcount; i++)
            {
                if (ghostblocks[i].transform.position.y < 0)
                {
                    downblock=true;
                }
                childx = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.x - (int)this.transform.GetChild(0).transform.position.x;
                childy = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.y - (int)this.transform.GetChild(0).transform.position.y;
                childz = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.z - (int)this.transform.GetChild(0).transform.position.z;
                if (childy != 0)
                {
                    if (Grid.grid[childx, childy - 1, childz] == null)
                    {
                        ghostblocks[i].transform.position = new Vector3(ghostblocks[i].transform.position.x, ghostblocks[i].transform.position.y - 1, ghostblocks[i].transform.position.z);
                    }
                }
            }*/
      
    }
    void PutBlock()
    {
        if (Input.GetMouseButtonDown(1))
        {
           // Debug.Log(blockcount);
            if (handblock)
            {
                for (int i = 0; i <= blockcount; i++)
                {
                    childx = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.x;
                    childy = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.y;
                    childz = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.z;
                    ghostblocks[i].SetActive(false);
                    Grid.grid[childx, childy, childz] = this.transform.GetChild(0).transform.GetChild(i).transform;
                }
               
                handblock = false;
            }
        }
    }
    /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            if (Input.GetMouseButtonDown(0))
            {
                grabObject = other.gameObject;
              
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            grabObject = null;
        
        }
    }*/
}



