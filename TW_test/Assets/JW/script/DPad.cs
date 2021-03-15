using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPad : MonoBehaviour
{
    private GameObject player;      //플레이어 스크립트를 가지고있는 오브젝트 player 선언
    private Player playerScript;        //player 아래에 있는 playerScript

    public void Init()      //Player 스크립트의 Start() 함수에서 실행
    {
        player = GameObject.FindGameObjectWithTag("Player");        //Player 태그로 플레이어 오브젝트 찾기
        playerScript = player.GetComponent<Player>();       //playerScript는 player오브젝트 아래에 있는 스크립트컴포넌트
    }
    //왼쪽
    public void SetLeftDown()          //public 선언을 해서 DPad 버튼의 Event Trigger에 달아줄 수 있음
    {
        playerScript.inputLeft = true;      //키보드 버튼이 Down 눌리는 동안 playerScript의 inputLeft 활성화(움직임)
    }

    public void SetLeftup()
    {
        playerScript.inputLeft = false;     //키보드 버튼이 Up 떼어지는 동안 playerScript의 inputLeft 비활성화(안움직임)
    }
    //오른쪽
    public void SetRightDown()
    {
        playerScript.inputRight = true;
    }

    public void SetRightUp()
    {
        playerScript.inputRight = false;
    }
    //앞
    public void SetFrontDown()
    {
        playerScript.inputFront = true;
    }

    public void SetFrontUp()
    {
        playerScript.inputFront = false;
    }
    //뒤
    public void SetBackDown()
    {
        playerScript.inputBack = true;
    }

    public void SetBackUp()
    {
        playerScript.inputBack = false;
    }
    //북동
    public void SetFRDown()
    {
        playerScript.inputFR = true;
    }

    public void SetFRUp()
    {
        playerScript.inputFR = false;
    }
    //남동
    public void SetBRDown()
    {
        playerScript.inputBR = true;
    }

    public void SetBRUp()
    {
        playerScript.inputBR = false;
    }
    //남서
    public void SetBLDown()
    {
        playerScript.inputBL = true;
    }

    public void SetBLUp()
    {
        playerScript.inputBL = false;
    }
    //북서
    public void SetFLDown()
    {
        playerScript.inputFL = true;
    }

    public void SetFLUp()
    {
        playerScript.inputFL = false;
    }
}
