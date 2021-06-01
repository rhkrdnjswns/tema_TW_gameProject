using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostUtility : MonoBehaviour
{
    [SerializeField] private Transform dropPos;
    [SerializeField] private Color originColor;
    [SerializeField] private Color setActiveFlaseColor;
    [SerializeField] private PlayerInteraction playerInteraction;
    //[SerializeField] private Transform ghostParent;
    private void Start()
    {
        playerInteraction = GetComponentInParent<PlayerInteraction>();
    }
    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3((int)Mathf.Round(dropPos.position.x), (int)Mathf.Round(dropPos.position.y), (int)Mathf.Round(dropPos.position.z));
        GhostSetFalse();


    }
    private void GhostSetFalse()
    {
        if (!CheckGrid())
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().material.color = setActiveFlaseColor;
            }

        }
        else if (CheckGrid())
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    transform.GetChild(i).GetComponent<MeshRenderer>().material.color = originColor;
                }
            }
        }

    }
    public void RotateGhost(Transform nowBlock)
    {
        dropPos.localPosition = new Vector3(0, -0.2f, 1.5f);
        this.transform.position = new Vector3((int)Mathf.Round(dropPos.position.x), (int)Mathf.Round(dropPos.position.y), (int)Mathf.Round(dropPos.position.z));

        transform.rotation = nowBlock.rotation;

        List<int> childGhosts = new List<int>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                int y = Mathf.RoundToInt(transform.GetChild(i).position.y);
                childGhosts.Add(y);
                Debug.Log(childGhosts[i]);
            }
        }

        if (childGhosts.Contains(-1))
        {
            dropPos.position += new Vector3(0, 2, 0);
            return;
        }
        if (childGhosts.Contains(0))
        {
            dropPos.position += new Vector3(0, 1, 0);
            return;
        }
        else
        {
            CheckGridForRotate();
        }
        
    }
    public bool CheckGrid() // 고스트 현재 위치 검사해서 한 칸이라도 차있으면 비활성화
    {
        List<Transform> childs = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                childs.Add(transform.GetChild(i));
            }

        }
        foreach (Transform child in childs)
        {
            int roundX = Mathf.RoundToInt(child.position.x);
            int roundY = Mathf.RoundToInt(child.position.y);
            int roundZ = Mathf.RoundToInt(child.position.z);

            if (roundX < 0 || roundX >= Grid.stageX || roundZ < 0 || roundZ >= Grid.stageZ)
            {
                Debug.Log("범위를 벗어났습니다.");
                return false;
            }
            if (Grid.grid[roundX, roundZ, roundY] != null)
            {
                return false;
            }

        }
        return true;
    }
    /*public bool CheckGridUnder() //고스트 밑에 칸 검사해서 한 칸이라도 차있으면 고스트 활성화
    {
        List<Transform> childs = new List<Transform>();
        if (Mathf.RoundToInt(transform.parent.position.y) >= 2)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    childs.Add(transform.GetChild(i));
                }

            }
            foreach (Transform child in childs)
            {
                int roundX = Mathf.RoundToInt(child.position.x);
                int roundY = Mathf.RoundToInt(child.position.y);
                int roundZ = Mathf.RoundToInt(child.position.z);

                if (Grid.grid[roundX, roundZ, roundY - 1] != null)
                {
                    return true; // 색깔 초록색
                }

            }
            return false; // 색깔 비활성화
        }
        return true;
    }*/

    private void CheckGridForRotate()
    {
        int ghostUp=0;
        List<Transform> childs = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                childs.Add(transform.GetChild(i));
            }
        }
        foreach (Transform child in childs)
        {
            int roundX = Mathf.RoundToInt(child.position.x);
            int roundY = Mathf.RoundToInt(child.position.y);
            int roundZ = Mathf.RoundToInt(child.position.z);
            
           /* if(roundY < Mathf.RoundToInt(transform.parent.position.y) - 1)
            {
                dropPos.position += new Vector3(0, 2, 0);
                return;
            }*/
            if (roundY < Mathf.RoundToInt(transform.parent.position.y))
            {
                ghostUp++;
            }
        }
        dropPos.position += new Vector3(0, ghostUp, 0);
        
    }
}