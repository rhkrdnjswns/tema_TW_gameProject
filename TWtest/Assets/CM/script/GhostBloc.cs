using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        Moving();
        PutBlock();
        Ghost();
        Turn();
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
        if (playerctrl.grabObject != null)
        {
            if (Input.GetMouseButtonDown(0)&&!playerctrl.handBlock)
            {
                Debug.Log("a");
                // block = grabObject.GetComponent<Block>();
                for (int i = 0; i < playerctrl.grabObject.transform.childCount; i++)
                {
                    //   child[i] = grabObject.transform.GetChild(i).gameObject;
                    childx = Mathf.RoundToInt(playerctrl.grabObject.transform.GetChild(i).transform.position.x)/*- Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.position.x)*/;
                    childy = Mathf.RoundToInt(playerctrl.grabObject.transform.GetChild(i).transform.position.y)/*- Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.position.y)*/;
                    childz = Mathf.RoundToInt(playerctrl.grabObject.transform.GetChild(i).transform.position.z)/*- Mathf.RoundToInt(playerctrl.getblock.transform.GetChild(0).transform.position.z)*/;

                    ghostblocks[i].SetActive(true);
                    ghostblocks[i].transform.position = playerctrl.grabObject.transform.GetChild(i).transform.position;
                    Grid.grid[childx, childy, childz] = null;
                    handblock = true;
                    blockcount = i;
                }
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
    void Turn()
    {
        if (playerctrl.handBlock)
        {
            if (Input.GetButtonDown("Xturn"))
            {
                Debug.Log("b");
                if (xr < 45)
                    xr = 90f;
                else
                   xr = 0f;

            }
            if (Input.GetButtonDown("Yturn"))
            {
                if (yr < 45)
                    yr = 90f;
                else
                    yr = 0f;
              
            }
            if (Input.GetButtonDown("Zturn"))
            {
                if (zr < 45)
                   zr = 90f;
                else
                   zr = 0f;
              
            }
            this.transform.rotation = playerctrl.getblock.transform.rotation;
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



