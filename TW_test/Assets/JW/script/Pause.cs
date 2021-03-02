using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject PauseWindow;
    bool IsPause;

    void Start()
    {
        PauseWindow = GameObject.Find("Canvas").transform.Find("Pause").gameObject;
        IsPause = false;
    }

    void Update()
    {

    }

    public void PauseClick()        //일시정지 버튼 클릭 시 함수 호출
    {
        if (IsPause == false)
        {
            Time.timeScale = 0;     //시간정지
            PauseWindow.gameObject.SetActive(true);     //일시정지 창 보이기
            IsPause = true;     //일시정지 상태 변수 true
            return;
        }
        else if (IsPause == true)
        {
            Time.timeScale = 1;     //시간정지 해제
            PauseWindow.gameObject.SetActive(false);            //일시정지 창 숨기기
            IsPause = false;        //일시정지 상태 변수 false
            return;
        }
    }

    public void GoMain()
    {
        Debug.Log("메인화면으로 돌아갑니다");
    }

    public void PauseOption()
    {
        Debug.Log("게임옵션 창 활성화");
    }
}
