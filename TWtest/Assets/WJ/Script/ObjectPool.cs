using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] GameObject[] poolingObjectPrefab;
    [SerializeField] GameObject[] poolingGhostPrefab;
    private Queue<Block> poolingObjectQueue = new Queue<Block>();
    private Queue<Ghost> poolingGohstQueue = new Queue<Ghost>();

    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }
    private Block CreateNewObject(int rand)
    {
        var newObj = Instantiate(poolingObjectPrefab[rand], transform).GetComponent<Block>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }
    private Ghost CreateNewGhost(int rand)
    {
        var newGhost = Instantiate(poolingGhostPrefab[rand], transform).GetComponent<Ghost>();
        newGhost.gameObject.SetActive(false);
        return newGhost;
    }
    private void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, poolingObjectPrefab.Length);
            poolingObjectQueue.Enqueue(CreateNewObject(rand));
            poolingGohstQueue.Enqueue(CreateNewGhost(rand));
        }
    }
    
    public static Block GetBlock(int rand, Transform position)
    {
        

        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue(); 
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            obj.gameObject.transform.position = position.position;
            obj.SetBlockRot(obj.transform);
            //obj.CheckBlockTransform(obj.transform);
           
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject(rand);
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            newObj.transform.position = position.position;
            newObj.CheckBlockTransform(newObj.transform);
            return newObj;
        }
    }
    public static Ghost GetGhost(int rand)
    {
        if (Instance.poolingGohstQueue.Count > 0)
        {
            var obj = Instance.poolingGohstQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewGhost(rand);
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(Block block)
    {
        block.gameObject.SetActive(false);
        block.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(block);
    }

}
