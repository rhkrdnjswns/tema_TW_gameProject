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
        /*int RandRotationX = Random.Range(0, rotateDegree.Length);
        int RandRotationY = Random.Range(0, rotateDegree.Length);
        int RandRotationZ = Random.Range(0, rotateDegree.Length);
        Quaternion RandRotation = Quaternion.Euler(rotateDegree[RandRotationX], rotateDegree[RandRotationY], rotateDegree[RandRotationZ]);
        transform.rotation = RandRotation;*/

    }
    public void SetBlockRot(Transform transform)
    {
        int RandRotationX = Random.Range(0, rotateDegree.Length);
        int RandRotationY = Random.Range(0, rotateDegree.Length);
        int RandRotationZ = Random.Range(0, rotateDegree.Length);
        Quaternion RandRotation = Quaternion.Euler(rotateDegree[RandRotationX], rotateDegree[RandRotationY], rotateDegree[RandRotationZ]);
        transform.rotation = RandRotation;
        transform.position = CheckBlockTransform(transform);
    }
    private void OnEnable()
    {
        /*foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            Debug.Log(roundX);
            int roundZ = Mathf.RoundToInt(children.transform.position.z);
            Debug.Log(roundZ);
            if (roundX > Grid.stageX)
            {
                while(roundX <= Grid.stageX)
                    transform.position += new Vector3(-1, 0, 0);

                Debug.Log("X 줄임");
            }
            else if (roundX < 0)
            {
                while (roundX >= 0)
                    transform.position += new Vector3(1, 0, 0);

                Debug.Log("X 늘림");
            }
            else if (roundZ > Grid.stageZ)
            {
                while (roundZ <= Grid.stageZ)
                    transform.position += new Vector3(0, 0, -1);   

                Debug.Log("Z 줄임");
            }
            else if (roundZ < 0)
            {
                while (roundZ >= 0)
                    transform.position += new Vector3(0, 0, 1);

                Debug.Log("Z 늘림");
            }
           
        }*/
    }
    public Vector3 CheckBlockTransform(Transform transform)
    {
        Debug.Log("호출");

        foreach (Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x); 
            int roundZ = Mathf.RoundToInt(children.transform.position.z);
            if (roundX >= Grid.stageX)
            {
                switch (roundX)
                {
                    case 3:
                        transform.position += new Vector3(-1, 0, 0);
                        Debug.Log("X 1 줄임");
                        break;
                    case 4:
                        transform.position += new Vector3(-2, 0, 0);
                        Debug.Log("X 2 줄임");
                        break;
                    default:
                        Debug.Log("안줄임");
                        break;
                }
                    
              
                    
            }
            else if (roundX < 0)
            {

                switch (roundX)
                {
                    case -1:
                        transform.position += new Vector3(1, 0, 0);
                        Debug.Log("X 1 늘림");
                        break;
                    case -2:
                        transform.position += new Vector3(2, 0, 0);
                        Debug.Log("X 2 늘림");
                        break;
                    default:
                        Debug.Log("안늘림");
                        break;
                }


            }
            else if (roundZ >= Grid.stageZ)
            {

                switch (roundZ)
                {
                    case 3:
                        transform.position += new Vector3(0, 0, -1);
                        Debug.Log("Z 1 줄임");
                        break;
                    case 4:
                        transform.position += new Vector3(0, 0, -2);
                        Debug.Log("Z 2 줄임");
                        break;
                    default:
                        Debug.Log("안줄임");
                        break;
                }


            }
            else if (roundZ < 0)
            {

                switch (roundZ)
                {
                    case -1:
                        transform.position += new Vector3(0, 0, 1);
                        Debug.Log("Z 1 늘림");
                        break;
                    case -2:
                        transform.position += new Vector3(0, 0, 2);
                        Debug.Log("Z 2 늘림");
                        break;
                    default:
                        Debug.Log("안늘림");
                        break;
                }
            }
            
        }
        Debug.Log("암것도안함");
        return transform.position;
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
  

