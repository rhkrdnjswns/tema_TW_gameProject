using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPosCM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent.transform.Translate(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
