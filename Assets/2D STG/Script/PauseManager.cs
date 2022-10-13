using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // 현재 정지상태이지 판별하는 변수
    public bool isPause = false;

    // SetActive 함수를 사용하기위해 GameObject로 선언
    // 정지버튼 이미지 저장 변수
    public GameObject pausedImage;

    // 다시시작 이미지 저장변수
    public GameObject retryImage;
    // 다시시작 텍스트 저장 변수
    public GameObject retryuText;

    // 타이틀로 이미지 저장 변수
    public GameObject toTileImage;
    // 타이틀로 텍스트 저장 변수
    public GameObject toTItleText;

    // time 텍스트 저장 변수
    public GameObject time;
    // score 텍스트 저장 변수
    public GameObject score;
    // gold 텍스트 저장 변수
    public GameObject gold;

    // PauseManager 객체 선언
    public static PauseManager pauseManager = null;

    private void Awake()
    {
        pauseManager = this;
    }

    private void Start()
    {
        // 시작할때 일시정지 UI보이지 않게 설정
        pausedImage.SetActive(false);

        retryImage.SetActive(false);
        retryuText.SetActive(false);

        toTileImage.SetActive(false);
        toTItleText.SetActive(false);
    }

    private void Update()
    {
        // Esc를 누르면
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // 현재 정지상태가 아니라면
            if (isPause == false)
            {
                // 0으로 설정해서 일시정지
                Time.timeScale = 0;
                // 정지상태 true로 변경
                isPause = true;

                // 일시정지 UI보이게 설정
                pausedImage.SetActive(true);

                retryImage.SetActive(true);
                retryuText.SetActive(true);

                toTileImage.SetActive(true);
                toTItleText.SetActive(true);

                // 플레이 UI 보이지 않게 설정
                time.SetActive(false);
                gold.SetActive(false);
                score.SetActive(false);

                // 마우스 보이게 설정하고 잠금 해제
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if(isPause == true)        // 현재 정지상태라면
            {
                // 일시정지 해제
                Time.timeScale = 1;
                // 정지상태 false로 변경
                isPause = false;

                // 일시정지 UI 보이지 않게 설정
                pausedImage.SetActive(false);

                retryImage.SetActive(false);
                retryuText.SetActive(false);

                toTileImage.SetActive(false);
                toTItleText.SetActive(false);

                // 플레이 UI 보이게 설정
                time.SetActive(true);
                gold.SetActive(true);
                score.SetActive(true);

                // 마우스 안보이게 설정하고 잠금
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
