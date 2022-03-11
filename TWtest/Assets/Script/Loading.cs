using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private Image loadingBar;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        loadingBar = GameObject.Find("LoadingBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        loadingBar.fillAmount += time * 0.1f;

        if(time > 3)
        {
            GameManager.Instance.LoadGameScene();
        }
    }
    
}
