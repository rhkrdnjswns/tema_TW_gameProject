using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private float[] rotateDegree = { 0, 90, 180, -90 };
    
    
    private Grid grid;

    public float[] getRotateDegree()
    {
        return rotateDegree;
    }
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        int RandRotationX = Random.Range(0, rotateDegree.Length);
        int RandRotationY = Random.Range(0, rotateDegree.Length);
        int RandRotationZ = Random.Range(0, rotateDegree.Length);
        Quaternion RandRotation = Quaternion.Euler(rotateDegree[RandRotationX], rotateDegree[RandRotationY], rotateDegree[RandRotationZ]);
        transform.rotation = RandRotation;

        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundZ = Mathf.RoundToInt(children.transform.position.z);
            if (roundX >= Grid.stageX)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if (roundX < 0)
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else if (roundZ >= Grid.stageZ)
            {
                transform.position += new Vector3(0, 0, -1);
            }
            else if (roundZ < 0)
            {
                transform.position += new Vector3(0, 0, 1);
            }
        }
    }
   
    private void Update()
    {
        if (!isValidMove())
        {
            grid.AddToGrid(transform);
            grid.CheckForLines();
            this.enabled = false;
        }
        
    }

    public bool isValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x); 
            int roundZ = Mathf.RoundToInt(children.transform.position.z); 
            int roundY = Mathf.RoundToInt(children.transform.position.y);

            if (roundX < 0 || roundX >= Grid.stageX || roundZ < 0 || roundZ >= Grid.stageZ || roundY <= 1 || roundY >= Grid.stageY)
            {
                return false;
            }
            if (Grid.grid[roundX, roundZ, roundY - 1] != null)
            {

                return false;
            }
        }
        return true;
    }
    
}
  

