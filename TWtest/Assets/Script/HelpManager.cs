using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    [SerializeField] private GameObject[] helps;
    private int rightCount;   
     
    private void Awake()
    {
        for (int i = 1; i < helps.Length; i++)
        {
            helps[i].SetActive(false);
        }
    }
    public void Right()
    {
        if (rightCount < helps.Length-1)
        {
            helps[rightCount].SetActive(false);
            rightCount++;
            helps[rightCount].SetActive(true);
            Debug.Log(rightCount);
        }
        else
        {
            helps[rightCount].SetActive(false);
            rightCount = 0;
            helps[rightCount].SetActive(true);
        }
    }
    public void Left()
    {
        if (rightCount > 0)
        {
            helps[rightCount].SetActive(false);
            rightCount--;
            helps[rightCount].SetActive(true);
        }
        else
        {
            helps[rightCount].SetActive(false);
            rightCount = helps.Length - 1;
            helps[rightCount].SetActive(true);
        }
    }
    public void Exit()
    {
        GameManager.Instance.LoadMainScene();
    }
}
