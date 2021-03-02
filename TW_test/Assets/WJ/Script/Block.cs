using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody rig;
    int power = 5;
    public static int StageX = 3;
    public static int StageY = 3;
    public static int StageZ = 3;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();

        
    }
    // Update is called once per frame
    void Update()
    {
            if(rig.isKinematic == true)
        {

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Stage")
        {
            rig.isKinematic = true;
        }
    }
    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundX = Mathf.RoundToInt(children.transform.position.x);
            int roundZ = Mathf.RoundToInt(children.transform.position.z);

            if(roundX <0 || roundX >=StageX || roundZ <0 || roundZ >= StageZ)
            {
                return false;
            }

        }
        return true;
    }
}
