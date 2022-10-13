using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    // SceneControll 객체 선언
    public static SceneControll sceneControll = null;

    private void Awake()
    {
        sceneControll = this;
    }

    public void GameScene_Load()
    {
        SceneManager.LoadScene("Game");

        // 일시정지 상태에서 게임을 다시 시작했을때 멈추는 현상 방지
        Time.timeScale = 1;

        // 게임 시작전 각 종 변수 초기화
        GoldManager.g_iGold = 0;
        ScoreManager.g_iScore = 0;

        // 마우스 커서 숨기고 잠금
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MainScene_Load()
    {
        // Main 씬으로 넘어감
        SceneManager.LoadScene("Main");

        // 일시정지 상태에서 메인화면으로 갔을때 멈추는 현상 방지
        Time.timeScale = 1;

        // Main으로 갈 때 각 종 변수 초기화              
        GoldManager.g_iGold = 0;
        ScoreManager.g_iScore = 0;

        // 마우스 커서 보이고 잠금 해제
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RoundScene_Load()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Round");

        // 마우스 커서 보이기
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NextRoundScene_Load()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Game");

        // 마우스 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
