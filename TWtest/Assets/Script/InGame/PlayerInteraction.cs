using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerInteraction : MonoBehaviour
{
   
    [SerializeField] private GrabCollider grabCollider;
    [SerializeField] private Transform grabPos;   
    [SerializeField] private GameObject[] ghostBlocks;
    [SerializeField] private GameObject[] putBlocks;
    [SerializeField] private GameObject currentBlock;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject blockParent;
    [SerializeField] private Transform keepTr;
    [SerializeField] private Transform keepTrReverse;
    [SerializeField] private GameObject currentKeepBlock;
    [SerializeField] private ParticleSystem keepTrParticle;
    [SerializeField] private ParticleSystem keepTrReverseParticle;
    [SerializeField] private Transform keepParent;
    [SerializeField] private Animator animator;

    private GhostUtility ghostUtility;
    private ButtonManager btManager;
    private List<Vector3> ghostLocalPos = new List<Vector3>();

    private bool isPutPossiable = false;

    private bool isPut;
    private bool isGrab;
    private bool isKeep;
    public bool IsGrab { get => isGrab; }
    public bool IsPut { get => isPut; set => isPut = value; }
    public bool IsPutPossiable { get => isPutPossiable; set => isPutPossiable = value; }

    private void Awake()
    {
        btManager = FindObjectOfType<ButtonManager>();
        ghostUtility = GetComponentInChildren<GhostUtility>();     

    }
 
    public void GrabBlock()
    {
        if(grabCollider.CollidedBlock != null)
        {
            if(currentBlock == null)
            {
                animator.SetTrigger("Pick");
                switch (grabCollider.CollidedBlock.tag)
                {

                    case "BlockO":
                        var objO = grabPos.GetChild(0).gameObject;
                        currentBlock = objO;
                        CreateGhostBlock(grabCollider.CollidedBlock);
                        objO.SetActive(true);
                        objO.transform.rotation = grabCollider.CollidedBlock.transform.rotation;
                        DestroyCaughtBlock(grabCollider.CollidedBlock);
                        isGrab = true;
                        break;

                    case "BlockminiI":
                        var objMiniI = grabPos.GetChild(1).gameObject;
                        currentBlock = objMiniI;
                        CreateGhostBlock(grabCollider.CollidedBlock);
                        objMiniI.SetActive(true);
                        objMiniI.transform.rotation = grabCollider.CollidedBlock.transform.rotation;
                        DestroyCaughtBlock(grabCollider.CollidedBlock);
                        isGrab = true;
                        break;

                    case "BlockI":
                        var objI = grabPos.GetChild(2).gameObject;
                        currentBlock = objI;
                        CreateGhostBlock(grabCollider.CollidedBlock);
                        objI.SetActive(true);
                        objI.transform.rotation = grabCollider.CollidedBlock.transform.rotation;
                        DestroyCaughtBlock(grabCollider.CollidedBlock);
                        isGrab = true;
                        break;
                    case "BlockR":
                        var objR = grabPos.GetChild(3).gameObject;
                        currentBlock = objR;
                        CreateGhostBlock(grabCollider.CollidedBlock);
                        objR.SetActive(true);
                        objR.transform.rotation = grabCollider.CollidedBlock.transform.rotation;
                        DestroyCaughtBlock(grabCollider.CollidedBlock);
                        isGrab = true;
                        break;
                    default:
                        Debug.Log("디폴트");
                        break;

                }
            }
           
        }
     
    }
    void DestroyCaughtBlock(GameObject destroyBlock)
    {
        foreach (Transform child in destroyBlock.transform) {
            int childX = Mathf.RoundToInt(child.position.x);
            int childY= Mathf.RoundToInt(child.position.y);
            int childZ= Mathf.RoundToInt(child.position.z);
            //destroyBlock.
            Debug.Log(Grid.grid[childX, childY, childZ]);
            Grid.grid[childX, childZ, childY] = null;
            Debug.Log(Grid.grid[childX, childY, childZ]);
        }
        CheckGridForGrab(destroyBlock);
        Destroy(destroyBlock);
    }
    void CreateGhostBlock(GameObject caughtBlock)
    {
        for (int i = 0; i < caughtBlock.transform.childCount; i++)
        {
            int childX = Mathf.RoundToInt(caughtBlock.transform.GetChild(i).position.x);
            int childY = Mathf.RoundToInt(caughtBlock.transform.GetChild(i).position.y);
            int childZ = Mathf.RoundToInt(caughtBlock.transform.GetChild(i).position.z);
            ghostBlocks[i].transform.position = new Vector3(childX, childY, childZ);
            ghostBlocks[i].SetActive(true);
        }
    }
    public void RotateBlockX()
    {
        foreach (Transform block in grabPos)
        {
            if(block.gameObject.activeSelf == true)
            {
               
                
                RotateBlock(grabPos, 90, 0, 0);
            }
        }
    }
    public void RotateBlockY()
    {
        foreach (Transform block in grabPos)
        {
            if (block.gameObject.activeSelf == true)
            {
                
                RotateBlock(grabPos, 0, 90, 0);
            }
        }
    }
    public void RotateBlockZ()
    {
        foreach (Transform block in grabPos)
        {
            if (block.gameObject.activeSelf == true)
            {
                
                RotateBlock(grabPos, 0, 0, 90);
            }
        }
    }
    private void RotateBlock(Transform target, float x, float y, float z)
    {
        
        target.Rotate(x, y, z,Space.Self);
        ghostUtility.RotateGhost(target);
    }
    
    public void PutBlock()//GameObject putBlock)
    {
        if (isPutPossiable)
        {
            if (ghostUtility.CheckGrid())
            {
                animator.SetTrigger("Put");
                var objParent = Instantiate(blockParent, Vector3.zero, currentBlock.transform.rotation);
                objParent.name = currentBlock.name;
                objParent.tag = currentBlock.tag;
                for (int i = 0; i < ghostBlocks.Length; i++)
                {
                    if (ghostBlocks[i].activeSelf)
                    {
                        int roundX = Mathf.RoundToInt(ghostBlocks[i].transform.position.x);
                        int roundY = Mathf.RoundToInt(ghostBlocks[i].transform.position.y);
                        int roundZ = Mathf.RoundToInt(ghostBlocks[i].transform.position.z);

                        Vector3 blockPos = new Vector3(roundX, roundY, roundZ);

                        var obj = Instantiate(block, blockPos, Quaternion.identity);
                        obj.transform.parent = objParent.transform;
                        obj.transform.localScale = new Vector3(47.5f, 47.5f, 47.5f);
                        obj.tag = "Block";
                        obj.GetComponent<MeshRenderer>().material = currentBlock.transform.GetChild(i).GetComponent<MeshRenderer>().material;
                    }
                }
                objParent.GetComponent<Block>().enabled = true;
                currentBlock.SetActive(false);
                DestroyGhost(false);
                currentBlock = null;
                if (objParent.transform.childCount < 1)
                {
                    Destroy(objParent);
                }
                isPut = true;
                isGrab = false;
            }
            else
            {
                btManager.ActiveWarningMsg();
            }
        }
        
       
    }
    private void DestroyGhost(bool KeepBlock)
    {
        for (int i = 0; i < ghostBlocks.Length; i++)
        {
            if (KeepBlock)
            {
                ghostLocalPos.Add(ghostBlocks[i].transform.localPosition);
            }
            ghostBlocks[i].transform.localPosition = Vector3.zero;
            ghostBlocks[i].SetActive(false);
            
        }
    }
    public bool KeepBlock()
    {
        if(currentBlock != null&&!isKeep)
        {
            animator.SetTrigger("Put");
            CreateKeepBlock(keepTr);
            CreateKeepBlock(keepTrReverse);
            keepTrParticle.Play();
            keepTrReverseParticle.Play();
            DestroyGhost(true);
            currentBlock.SetActive(false);
            currentBlock = null;
            isGrab = false;
            grabCollider.IsTriggerBlock = false;
            isKeep = true;
            return true;
        }
        return false;
    }
    public bool KeepOut()
    {
        if (!isGrab)
        {
            animator.SetTrigger("Pick");
            GameObject keepOutBlock = keepTr.GetChild(1).gameObject;
            currentBlock = currentKeepBlock;

            for (int i = 0; i < grabPos.transform.childCount; i++)
            {
                if (grabPos.GetChild(i).tag == keepOutBlock.tag)
                {
                    grabPos.GetChild(i).gameObject.SetActive(true);
                    KeepOutGhost(currentKeepBlock);
                    Destroy(keepTr.GetChild(1).gameObject);
                    Destroy(keepTrReverse.GetChild(1).gameObject);
                }
            }
            keepTrParticle.Stop();
            keepTrReverseParticle.Stop();
            currentKeepBlock = null;
            isGrab = true;
            isKeep = false;
            return true;
        }
        return false;
    }
    private void CreateKeepBlock(Transform keepTr)
    {
        
        var keepBlock = Instantiate(currentBlock, keepTr);
        

        keepBlock.transform.position = keepTr.GetChild(0).position;
        keepBlock.transform.position += new Vector3(0, 0.8f, 0);
        keepBlock.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        keepBlock.transform.rotation = currentBlock.transform.rotation;

        currentKeepBlock = currentBlock;
    }
    
    private void KeepOutGhost(GameObject currentKeepBlock)
    {
        for (int i = 0; i < currentKeepBlock.transform.childCount; i++)
        {
            ghostBlocks[i].SetActive(true);
            ghostBlocks[i].transform.localPosition = ghostLocalPos[i];
        }
        ghostUtility.RotateGhost(grabPos);
    }
    
    private void CheckGridForGrab(GameObject block) //그랩 시에 집은 블록 윗칸 검사
    {
        foreach (Transform child in block.transform)
        {
            int roundX = Mathf.RoundToInt(child.position.x);
            int roundY = Mathf.RoundToInt(child.position.y);
            int roundZ = Mathf.RoundToInt(child.position.z);

            if (Grid.grid[roundX, roundZ, roundY + 1] != null)
            {
                if(Grid.grid[roundX, roundZ, roundY + 1].parent != block.transform)
                Grid.grid[roundX, roundZ, roundY + 1].parent.GetComponent<Block>().enabled = true;
                Grid.grid[roundX, roundZ, roundY + 1] = null;
            }
        }
    }

}
