using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonControll : MonoBehaviour
{
    // 라운드 종료 페이지
    public GameObject score_text;
    public GameObject shop_button;
    public GameObject toTitle_button;
    public GameObject nextRound_text;
    public GameObject nextRound_button;
    public GameObject gold_text;
    public GameObject roundClear_text;

    // 상점 페이지
    public GameObject return_button;
    public GameObject attackSpeed_button;
    public GameObject attackNum_button;

    public Text attackSpeed_text;
    public Text attackNum_text;

    private void Awake()
    {
        score_text.SetActive(true);
        shop_button.SetActive(true);
        toTitle_button.SetActive(true);
        nextRound_text.SetActive(true);
        nextRound_button.SetActive(true);
        gold_text.SetActive(true);          // 코인은 그대로 두기
        roundClear_text.SetActive(true);

        return_button.SetActive(false);
        attackSpeed_button.SetActive(false);
        attackNum_button.SetActive(false);
    }

    // shop 버튼 클릭, 상점 페이지로
    public void ChnageShop()
    {
        score_text.SetActive(false);
        shop_button.SetActive(false);
        toTitle_button.SetActive(false);
        nextRound_text.SetActive(false);
        nextRound_button.SetActive(false);
        roundClear_text.SetActive(false);

        return_button.SetActive(true);
        attackSpeed_button.SetActive(true);
        attackNum_button.SetActive(true);
    }

    // return 버튼 클릭, 라운드 종료 페이지로
    public void ReturnShop()
    {
        score_text.SetActive(true);
        shop_button.SetActive(true);
        toTitle_button.SetActive(true);
        nextRound_text.SetActive(true);
        nextRound_button.SetActive(true);
        roundClear_text.SetActive(true);

        return_button.SetActive(false);
        attackSpeed_button.SetActive(false);
        attackNum_button.SetActive(false);
    }

    // 공격 속도 레벨 증가 함수
    public void ClickAttackSpeedButton()
    {
        if(Missile.fSpeed < 10 && GoldManager.g_iGold >= 100)
        {
            // 100골드 사용
            GoldManager.goldmanager.Use100Gold();

            // 공격 속도 1 증가
            Missile.fSpeed = Missile.fSpeed + 1;

            attackSpeed_text.text = "현재 레벨 : " + (Missile.fSpeed - 5).ToString();
        }

        // 공격 속도 최대 레벨이라면
        if(Missile.fSpeed == 10)
        {
            attackSpeed_text.text = "최대 레벨";
        }
    }

    // 공격 횟수 레벨 증가 함수
    public void ClickAttackNumButton()
    {
        if(MissileManager.g_AttackNum_level < 5 && GoldManager.g_iGold >= 100)
        {
            // 100골드 사용
            GoldManager.goldmanager.Use100Gold();

            MissileManager.g_AttackNum_level = MissileManager.g_AttackNum_level + 1;

            attackNum_text.text = "현재 레벨 : " + MissileManager.g_AttackNum_level.ToString();
        }

        // 공격 횟수 최대 레벨이라면
        if(MissileManager.g_AttackNum_level == 5)
        {
            attackNum_text.text = "최대 레벨";
        }
    }

    private void Update()
    {
        // 공격 속도
        if(Missile.fSpeed < 10)
        {
            attackSpeed_text.text = "현재 레벨 : " + (Missile.fSpeed - 5).ToString();
        }
        else if(Missile.fSpeed == 10)
        {
            attackSpeed_text.text = "최대 레벨";
        }

        // 공격 횟수
        if (MissileManager.g_AttackNum_level < 5)
        {
            attackNum_text.text = "현재 레벨 : " + MissileManager.g_AttackNum_level.ToString();
        }
        else if (MissileManager.g_AttackNum_level == 5)
        {
            attackNum_text.text = "최대 레벨";
        }
    }
}
