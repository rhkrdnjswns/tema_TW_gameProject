using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI : MonoBehaviour
{
    GameObject Minimap;
    GameObject MinimapR;
    GameObject MinimapCamera;

    // Start is called before the first frame update
    void Start()
    {
        Minimap = GameObject.FindWithTag("Minimap");
        MinimapR = GameObject.Find("Canvas").transform.Find("MinimapR").gameObject;
        MinimapCamera = GameObject.Find("MinimapCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MinimapClick()
    {
        Minimap.SetActive(false);
        MinimapR.SetActive(true);
    }
}
