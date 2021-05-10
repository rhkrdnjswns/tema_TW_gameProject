using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GhostBloc : MonoBehaviour
{
    block1 block1;
    PlayerCtrl playerctrl;
    Block block;
    PutPos putpos;
    BlockChildT blockchildt;
   public GameObject grabObject;
    float xr;
    float yr;
    float zr;
    bool ghostlive = true;
    int childx;
    int childy;
    int childz;
    float downY;
    int mz;
    int[,,] childspot;
    int blockcount;//블록수
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
        Moving();
        PutBlock();
       Ghost();
        Turn();
        NBlock();
      //  CanPut();
    }
    void CanPut()
    {
        if (playerctrl.handBlock)
        {
            for (int i = 0; i < blockcount; i++)
            {
                childx = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.x;
                childy = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.y;
                childz = (int)this.transform.GetChild(0).transform.GetChild(i).transform.position.z;
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
                if (playerctrl.getblock != null&&ghostlive)
                {
                    //this.transform.GetChild(0).transform.rotation = playerctrl.grabObject.transform.rotation;
                    // block = grabObject.GetComponent<Block>();
                    for (int i = 0; i < playerctrl.grabObject.transform.childCount; i++)
                    {
                        //   child[i] = grabObject.transform.GetChild(i).gameObject;
                        childx = Mathf.RoundToInt(playerctrl.grabObject.transform.GetChild(i).transform.position.x);
                        childy = Mathf.RoundToInt(playerctrl.grabObject.transform.GetChild(i).transform.position.y);
                        childz = Mathf.RoundToInt(playerctrl.grabObject.transform.GetChild(i).transform.position.z);
                        ghostblocks[i].SetActive(true);
                      ghostblocks[i].transform.position = new Vector3(childx, childy, childz);
                    //Grid.grid[childx, childy, childz] = null;
                        
                        blockcount = i;
                ghostlive = false;
                
               // this.transform.GetChild(0).position = playerctrl.grabObject.transform.position;
            }
            Debug.Log(blockcount);
        }
    }

    void Moving()
    {
        this.transform.position = new Vector3((int)Mathf.Round(dropPos.position.x), (int)Mathf.Round(dropPos.position.y), (int)Mathf.Round(dropPos.position.z));
        if (playerctrl.handBlock)
        {
            for(int i = 0; i <= blockcount; i++)
            {
                if (this.transform.GetChild(0).transform.GetChild(i).transform.position.y < 0)
                {
                    upblock=true;
                }
            }
            if (upblock)
            {
                this.transform.GetChild(0).position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            }
        }
    }
    void PutBlock()
    {
        if (!playerctrl.handBlock&&!ghostlive)
        {
            if (Input.GetMouseButton(1))
            {
                for (int i = 0; i <= blockcount; i++)
                {
          
                    childx = Mathf.RoundToInt(this.transform.GetChild(0).transform.GetChild(i).transform.position.x);
                    childy = Mathf.RoundToInt(this.transform.GetChild(0).transform.GetChild(i).transform.position.y);
                    childz = Mathf.RoundToInt(this.transform.GetChild(0).transform.GetChild(i).transform.position.z);
                    ghostblocks[i].SetActive(false);
                    //  Grid.grid[childx, childy, childz] = this.transform.GetChild(0).transform.GetChild(i).transform;
                }
               
                ghostlive = true;
            }
           
        }
    }
    void NBlock()
    {
        if (playerctrl.getblock != null)
        {
            switch (playerctrl.getblock.name)
            {
                case "1":
                    downY = -1.2f;
                    break;
                case "2":
                    downY = -1f;
                    break;
                case "3":
                    downY = -2f;
                    break;
            }
        }
    }
    void Turn()
    {
        if (playerctrl.handBlock)
        {
            this.transform.GetChild(0).transform.rotation = playerctrl.getblock.transform.rotation;
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



