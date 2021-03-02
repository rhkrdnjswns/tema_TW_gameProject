using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public Text stage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp()
    {
        if (Score_Update.score == 500)
        {
            stage.text = "Lv. 1 / AAA";
        }
        else if (Score_Update.score == 1000)
        {
            stage.text = "Lv. 2 / BBB";
        }
    }
}
