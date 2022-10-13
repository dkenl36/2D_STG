using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public Text result_score;

    void Awake()
    {
        result_score.text = "점수 : " + ScoreManager.g_iScore.ToString();
    }

    void Start()
    {
        // 점수 초기화 
        ScoreManager.g_iScore = 0;
    }
}