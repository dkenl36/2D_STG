using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButtonScript : MonoBehaviour
{
    public void Retry()
    {
        // Game 씬으로 이동
        SceneManager.LoadScene("Game");

        // 만약 일시정지 상태라면 해제
        Time.timeScale = 1;

        // RetryRound() 함수 불러옴
        RoundManager.roundManager.RetryRound();
    }
}
