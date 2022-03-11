using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Transform Pivot { get => pivot; set => pivot = value; }
    public int Count { get => count; set => count = value; }

    private int count;

    private bool isGrab = false;

    private float[] rotateDegree = { 0, 90, 180, -90 };

    [SerializeField] private Transform pivot;

    [SerializeField] private Material grabMat;
    [SerializeField] private Material originMat;
    private Grid grid;

    

  
    public float[] getRotateDegree()
    {
        return rotateDegree;
    }
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        count = transform.childCount;

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
                    case 6:
                        transform.position += new Vector3(-1, 0, 0);
                        Debug.Log("X 1 줄임");
                        break;
                    case 7:
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
                    case 6:
                        transform.position += new Vector3(0, 0, -1);
                        Debug.Log("Z 1 줄임");
                        break;
                    case 7:
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

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            isGrab = true;
            ReduceBlockScaleAndColorAlpha(isGrab);
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
    
    private void ReduceBlockScaleAndColorAlpha(bool isGrab)
    {
        if (isGrab)
        {
            GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
            foreach(Transform child in transform)
            {
                child.GetComponent<MeshRenderer>().material = grabMat;
            }
        }
    }
}
  

