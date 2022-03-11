using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseWindow;
    private bool isPause;       //일시정지 상황 판단 변수

    void Start()
    {
        isPause = false;
    }

    void Update()
    {

    }

    public void SetPauseClick()        //일시정지 버튼 클릭 시 함수 호출
    {
        if (isPause == false)       //게임 진행 중이였을시
        {
            Time.timeScale = 0;     //시간정지
            pauseWindow.gameObject.SetActive(true);     //일시정지 창 보이기
            isPause = true;     //일시정지 상태 변수 true
            //return;
        }
        else if (isPause == true)       //게임 정지 중이였을시
        {
            Time.timeScale = 1;     //시간정지 해제
            pauseWindow.gameObject.SetActive(false);            //일시정지 창 숨기기
            isPause = false;        //일시정지 상태 변수 false
            //return;
        }
    }

    public void SetGoMain()        //일시정지 윈도우에서 메인화면으로 돌아가는 버튼 클릭시 이벤트 발생
    {
        Debug.Log("메인화면으로 돌아갑니다");
    }

    public void SetPauseOption()       //일시정지 윈도우에서 게임 옵션 버튼 클릭시 이벤트 발생
    {
        Debug.Log("게임옵션 창 활성화");
    }
}
