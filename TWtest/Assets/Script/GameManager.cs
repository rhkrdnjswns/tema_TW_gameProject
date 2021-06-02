using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public GameManager Instance { get => instance; }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
