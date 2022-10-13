using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBoxManager : MonoBehaviour
{
    // Player의 남은 HP를 저장하는 전역 변수
    public static int g_Hp = 0;

    public static HPBoxManager hpBoxManager = null;

    private GameObject text_Hp;
    public Text t_Hp;

    private void Start()
    {
        // Player의 기본 HP
        g_Hp = 3;
        
        // text_Hp를 private로 선언했기 때문에 인스펙터창에서 드래그 앤 드롭이 불가능 그래서 Find함수로 Hp가 이름인 GameObject 가져옴, 테스트용
        text_Hp = GameObject.Find("Hp");
        t_Hp = text_Hp.GetComponent<Text>();
    }

    void Awake()
    {
        hpBoxManager = this;
    }

    public void addHp(int Hp)
    {
        if (g_Hp < 3)
        {
            g_Hp = g_Hp + Hp;
            t_Hp.text = g_Hp.ToString();
        }

        // 최대 Hp 3 유지
        if (g_Hp == 3)
        {
            g_Hp = 3;
            t_Hp.text = g_Hp.ToString();
        }
    }
}
