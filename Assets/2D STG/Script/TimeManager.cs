using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // 게임시간 변수
    public float gameTime;
    // 비교시간 변수
    public float checkTime;

    public Text text_Time;

    void Awake()
    {
        // 남은시간 초기화
        gameTime = 60;
        // 비교시간 초기화
        checkTime = 0;
    }

    void Update()
    {
        // 게임시간에서 시간값을 계속 빼줌
        gameTime = gameTime - Time.deltaTime;

        // 게임시간이 비교시간보다 작다면
        if (gameTime < checkTime)
        {
            // 게임시간 초기화
            gameTime = 60;

            // 라운드 증가
            RoundManager.roundManager.AddRound();

            // Round 씬 불러옴
            SceneControll.sceneControll.RoundScene_Load();
        }

        //text_Time.text = string.Format("{0:N2}", gameTime);
        // Ceil은 올림 함수
        text_Time.text = "남은 시간 : " + Mathf.CeilToInt(gameTime).ToString();
    }
}
