using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBloc : MonoBehaviour
{
    Block block;
    BlockChildT blockchildt;
    GameObject grabObject;
    int childx;
    int childy;
    int childz;
    int[,,] childspot;
    int blockcount;
    GameObject[] child;
    bool handblock = false;
    bool canput = false;
    [SerializeField] GameObject[] ghostblocks;
    [SerializeField] private Transform dropPos;
    [SerializeField] GameObject GrabCollider;
    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetMouseButtonDown(0) && !handblock && grabObject != null)
        {
            // block = grabObject.GetComponent<Block>();
            
            for (int i = 0; i < grabObject.transform.childCount; i++)
            {
                 //   child[i] = grabObject.transform.GetChild(i).gameObject;
                   childx = Mathf.RoundToInt(grabObject.transform.GetChild(i).transform.position.x);
                    childy = Mathf.RoundToInt(grabObject.transform.GetChild(i).transform.position.y);
                   childz = Mathf.RoundToInt(grabObject.transform.GetChild(i).transform.position.z);
               // Debug.Log(childx);
               // Debug.Log(childy);
               // Debug.Log(childz);
                ghostblocks[i].SetActive(true);
                ghostblocks[i].transform.position = grabObject.transform.GetChild(i).transform.position;
              
                Grid.grid[childx, childy, childz] = null;
               
                handblock = true;
                blockcount = i;
            }
        }
    }
    void Moving()
    {
        this.transform.position = new Vector3((int)Mathf.Round(dropPos.position.x), (int)Mathf.Round(dropPos.position.y), (int)Mathf.Round(dropPos.position.z));
        
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
         //   Debug.Log(other.gameObject);
            grabObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
         
            grabObject = null;
          //  Debug.Log("null");
        }
    }
}



