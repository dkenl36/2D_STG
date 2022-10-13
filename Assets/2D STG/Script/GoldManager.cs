using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text text_Gold;
    // 코인을 저장할 전역 변수
    public static int g_iGold = 0;
    // gold1과 gold2 더한 값을 저장할 변수
    private int gold3;

    public static GoldManager goldmanager = null;

    private void Awake()
    {
        goldmanager = this;

        text_Gold.text = "코인 : " + g_iGold.ToString() + "개";
    }

    public void AddGold(int gold)
    {
        g_iGold += gold;

        text_Gold.text = "코인 : " + g_iGold.ToString() + "개";
    }

    // 골드 랜덤으로 휙득하는 함수
    public void AddRandomGold(int gold1, int gold2)
    {
        gold3 = Random.Range(gold1, gold2);

        g_iGold = g_iGold + gold3;

        text_Gold.text = "코인 : " + g_iGold.ToString() + "개";
    }

    // 100골드 사용하는 함수
    public void Use100Gold()
    {
        if(g_iGold >= 100)
        {
            g_iGold = g_iGold - 100;
        }

        text_Gold.text = "코인 : " + g_iGold.ToString() + "개";
    }

    private void Update()
    {
        // F1 누르면 치트 사용
        if (Input.GetKey(KeyCode.F1))
        {
            GetGoldCheet();
        }
    }

    // 100골드를 얻는 치트 함수
    private void GetGoldCheet()
    {
        g_iGold = g_iGold + 100;

        text_Gold.text = "코인 : " + g_iGold.ToString() + "개";
    }
}
