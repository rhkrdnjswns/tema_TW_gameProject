using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;

    private int[] scoreUp = { 0, 1, 4, 16 };
    private int score = 0;
    private int bestScore;
    private const int CLEAR_SCORE = 500;
    private const int SPAWN_SCORE = 25;
    private int levelCount = 1;

    [Header("레벨 상승에 필요한 점수")]
    [SerializeField] private int levelUpScore = 5000;

    private BlockSpawner blockSpawner;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    public static ScoreManager Instance //인스턴스 게터
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public Text BestScoreText { get => bestScoreText; set => bestScoreText = value; }
    public Text ScoreText { get => scoreText; set => scoreText = value; }

    private void Awake()
    {
        
        LoadScore();
        if(instance == null) //스코어매니저 인스턴스 생성
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject); //해당 함수가 다시 호출된 경우 (씬 전환이 일어난 경우) 해당 오브젝트 삭제
        }

        blockSpawner = FindObjectOfType<BlockSpawner>();
    }
    public void ScoreUp(bool isClear, int clearCount = 0)//true면 클리어 시, false면 블록 생성 시
    {
        if (!isClear)
        {
            score += SPAWN_SCORE;
        }
        else
        {
            switch (clearCount)
            {
                case 1:
                    score += CLEAR_SCORE * scoreUp[clearCount]; //배열의 클리어카운트 인자값 인덱스만큼 곱해줌
                break;
                case 2:
                    score += CLEAR_SCORE * scoreUp[clearCount];
                    break;
                case 3:
                    score += CLEAR_SCORE * scoreUp[clearCount];
                    break;
                default:
                    Debug.Log("4줄 이상");
                    break;

            }
        }
        scoreText.text = score.ToString();
        if(PlayerPrefs.GetInt("Score") < score)
        {
            SaveScore();
            bestScoreText.text = score.ToString();
        }
        if (score >= levelUpScore)
        {
            levelUpScore = levelUpScore * 3;
            levelCount++;
            blockSpawner.Level = levelCount;
        }
        //else if()
    }
    
    public void SaveScore()
    { 
        PlayerPrefs.SetInt("Score", score);
    }
    public void LoadScore()
    {
        bestScore = PlayerPrefs.GetInt("Score", 0);
        bestScoreText.text = bestScore.ToString();
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");
        bestScore = 0;
        bestScoreText.text = bestScore.ToString();
    }
}
