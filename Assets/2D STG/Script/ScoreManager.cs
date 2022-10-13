using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 점수 텍스트 저장할 변수
    public Text text_Score;
    // 점수를 저장할 전역 변수
    public static int g_iScore = 0;
    // ScoreManager 객체 선언
    public static ScoreManager scoreManager = null;

    // score1과 score2사이의 랜덤한 값을 저장할 변수
    int score3;

    void Awake()
    {
        scoreManager = this;

        text_Score.text = "점수 : " + g_iScore.ToString() + "점";
    }

    // 점수 10점 더하기
    public void AddScore()
    {
        g_iScore += 10;

        text_Score.text = "점수 : " + g_iScore.ToString() + "점";
    }

    // AddScore 함수 오버로딩
    public void AddScore(int score)
    {
        g_iScore += score;

        text_Score.text = "점수 : " + g_iScore.ToString() + "점";
    }

    // 랜덤한 점수 얻는 함수
    public void AddRandomScore(int score1, int score2)
    {
        score3 = Random.Range(score1, score2);

        g_iScore = g_iScore + score3;

        text_Score.text = "점수 : " + g_iScore.ToString() + "점";
    }
}