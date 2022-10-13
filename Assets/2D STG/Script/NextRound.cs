using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour
{
    // nextRound텍스트를 저장할 변수
    public Text text_NextRound;
    // NextRound객체 선언
    public static NextRound nextRound;

    private void Awake()
    {
        nextRound = this;

        text_NextRound.text = "다음 라운드 : " + RoundManager.g_gameRound.ToString() + "라운드";
    }
}
