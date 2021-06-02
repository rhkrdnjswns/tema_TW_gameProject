using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 전환

public class MainButtonManager : MonoBehaviour
{
    private GameObject settingwindow;

    // Start is called before the first frame update
    void Start()
    {
        settingwindow = GameObject.Find("Canvas").transform.Find("Pause").gameObject;
        settingwindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartBtn()
    {
        Debug.Log("드가자");
        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene("3D_TETRIS_BETA");
    }
    public void SettingBtn()
    {
        Debug.Log("세팅");
        Time.timeScale = 0;
        settingwindow.gameObject.SetActive(true);
    }
    public void SettingGomain()
    {
        Debug.Log("메인으로 돌아가기");
        Time.timeScale = 1;
        settingwindow.gameObject.SetActive(false);
    }
}
