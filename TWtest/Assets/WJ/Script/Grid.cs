using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{
    public static int stageX = 6;
    public static int stageZ = 6;
    public static int stageY = 14;
    public static Transform[,,] grid = new Transform[stageX, stageZ, stageY];


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < stageX; i++)
            {
                for (int j = 0; j < stageZ; j++)
                {
                    for (int k = 0; k < stageY; k++)
                    {
                        if(grid[i,j,k] != null)
                        {
                            //Debug.Log(grid[i, j, k].gameObject.ToString());
                            Debug.Log(grid[i, j, k].transform.position);
                        }
                        
                    }
                }
            }
        }
    }
    public void AddToGrid(Transform transform) //그리드에 추가
    {
        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundZ = Mathf.RoundToInt(children.transform.position.z);
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundX, roundZ, roundY] = children;
        }
    }
    public void CheckForLines() // 층 검사
    {
        for (int i = stageY-1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeletLine(i);
                RowDown(i);
            }
        }
    }
    private bool HasLine(int i) //층이 비었는지 아닌지 확인
    {
        for(int z = 0; z < stageZ; z++)
        {
            for (int x = 0; x < stageX; x++)
            {
                if (grid[z, x, i] == null)
                    return false;
            }
        }
        return true;
    }
    private void DeletLine(int i) //층이 안비었으면 실행, 층 삭제
    {
        for (int z = 0; z < stageZ; z++)
        {
            for (int x = 0; x < stageX; x++)
            {
                Destroy(grid[z, x, i].gameObject);    
                grid[z, x, i] = null;
            }
        }
    }
    private void RowDown(int i) //층이 삭제되면 해당 층 위에있던 블록들 해당 층 그리드에 저장
    {
        for (int y = i; y < stageY; y++)
        {
            for (int z = 0; z < stageZ; z++)
            {
                for (int x = 0; x < stageX; x++)
                {
                    if(grid[z,x,y] != null)
                    {
                        grid[z, x, y - 1] = grid[z, x, y];
                        grid[z, x, y] = null;
                    }
                }
            }
        }
    }
   
}
