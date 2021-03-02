using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPad : MonoBehaviour
{

    GameObject player;
    Player playerScript;

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }
    //왼쪽
    public void LeftDown()
    {
        playerScript.inputLeft = true;
    }

    public void Leftup()
    {
        playerScript.inputLeft = false;
    }
    //오른쪽
    public void RightDown()
    {
        playerScript.inputRight = true;
    }

    public void RightUp()
    {
        playerScript.inputRight = false;
    }
    //앞
    public void UpDown()
    {
        playerScript.inputUp = true;
    }

    public void UpUp()
    {
        playerScript.inputUp = false;
    }
    //뒤
    public void DownDown()
    {
        playerScript.inputDown = true;
    }

    public void DownUp()
    {
        playerScript.inputDown = false;
    }
    //북동
    public void FrDown()
    {
        playerScript.inputFr = true;
    }

    public void FrUp()
    {
        playerScript.inputFr = false;
    }
    //남동
    public void BrDown()
    {
        playerScript.inputBr = true;
    }

    public void BrUp()
    {
        playerScript.inputBr = false;
    }
    //남서
    public void BlDown()
    {
        playerScript.inputBl = true;
    }

    public void BlUp()
    {
        playerScript.inputBl = false;
    }
    //북서
    public void FlDown()
    {
        playerScript.inputFl = true;
    }

    public void FlUp()
    {
        playerScript.inputFl = false;
    }
}
