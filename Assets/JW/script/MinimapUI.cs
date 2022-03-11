using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI : MonoBehaviour
{
    GameObject minimap;
    GameObject minimapR;
    GameObject minimapCamera;

    // Start is called before the first frame update
    void Start()
    {
        minimap = GameObject.FindWithTag("Minimap");
        minimapR = GameObject.Find("Canvas").transform.Find("MinimapR").gameObject;
        minimapCamera = GameObject.Find("MinimapCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MinimapClick()
    {
        minimap.SetActive(false);
        minimapR.SetActive(true);
    }
}
