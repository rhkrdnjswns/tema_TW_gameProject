using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance { get => instance; }
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        SoundManager.Instance.PlaySound(true, 0);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Load");
        SoundManager.Instance.StopSound();
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("3D_TETRIS_BETA");
        SoundManager.Instance.PlaySound(true, 1);
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainTitle");
        SoundManager.Instance.PlaySound(true, 0);
    }
    public void LoadHelpScene()
    {
        SceneManager.LoadScene("Help");

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    
}
