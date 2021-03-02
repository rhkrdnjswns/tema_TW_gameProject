using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockList : MonoBehaviour
{
    [SerializeField]
    private Transform BSpacePrefab;

    [SerializeField]
    private int height;
    [SerializeField]
    private int width;

    private BlockSpace[,] bSpace;
    private int cubePosCountX = 1;
    private int cubePosCountY = 0;
    [SerializeField]
    private Transform[] cubePos;
    // Start is called before the first frame update
    void Start()
    {
        cubePos = GameObject.Find("Stage").GetComponentsInChildren<Transform>();
        CreateBSpace();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(bSpace[0, 0].Obj.name);
        }
    }

    void CreateBSpace()
    {
       /* for (int i = 0; i < cubePos.Length; i++)
        {
            Vector3 worldPos = new Vector3(cubePos[i].position.x, 0.75f, cubePos[i].position.z);
            Transform obj = Instantiate(BSpacePrefab, worldPos, Quaternion.identity);
           
        }*/
        bSpace = new BlockSpace[width, height];
        int count = 0;
        for (int i = 0; i < width; i++)
        {
            
            for (int j = 0; j < height; j++)
            {
                
                Vector3 worldPosition = new Vector3(cubePos[cubePosCountX].position.x, 0.75f, cubePos[cubePosCountX].position.z);
                GameObject go = BSpacePrefab.gameObject;
                go.name = "cube" + count;
                Instantiate(go, worldPosition, Quaternion.identity);                
                bSpace[i, j] = new BlockSpace(true, worldPosition, go );
                count++;
                cubePosCountX++;
            }
        }
    }
    public class BlockSpace
    {
        public bool isPlaceable;
        public Vector3 SpacePos;
        public GameObject Obj;
        public Transform objPos;
        public BlockSpace(bool isPlaceable, Vector3 SpacePos, GameObject Obj)
        {
            this.isPlaceable = isPlaceable;
            this.SpacePos = SpacePos;
            this.Obj = Obj;
            objPos = Obj.transform;
        }
    }
}
