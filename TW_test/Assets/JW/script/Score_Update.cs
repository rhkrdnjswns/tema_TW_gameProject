using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Update : MonoBehaviour
{
    public static int score;
    public Text scoreLabel;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
    }
    
    void Start()
    {
        scoreLabel.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        score += 100;
        scoreLabel.text = "Score : " + score.ToString();

        GameObject.FindWithTag("Stage").GetComponent<Stage>().LevelUp();

    }
}
