using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    // 게임 라운드를 저장할 전역변수
    public static int g_gameRound = 1;
    // 게임 라운드 텍스트를 저장할 변수
    public Text text_gameRound;
    // RoundManager 객체 선언
    public static RoundManager roundManager = null;

    private void Awake()
    {
        roundManager = this;

        text_gameRound.text = "최종 라운드 : " + g_gameRound.ToString() + "라운드";
    }

    // 전 라운드 retry
    public void RetryRound()
    {
        if(g_gameRound > 1)
        {
            g_gameRound = g_gameRound - 1;
        }
        else if(g_gameRound == 1)
        {
            g_gameRound = 1;
        }
    }

    // 다음 라운드로
    public void AddRound()
    {
        g_gameRound = g_gameRound + 1;
    }
}
