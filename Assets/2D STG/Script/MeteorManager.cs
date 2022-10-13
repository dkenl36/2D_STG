using UnityEngine;
using System.Collections;

public class MeteorManager : MonoBehaviour
{

    // warning prefab을 저장할 변수
    public GameObject warning;
    // meteor prefab을 저장할 변수
    public GameObject meteor;
    // player 위치를 저장할 변수
    public GameObject player;
    // 메테오가 생성되는 간격
    public float MeteoInterval = 0;

    void Start()
    {
        // 라운드가 바뀔 때 메테오 수 증가
        switch (RoundManager.g_gameRound)
        {
            case 1:
                {
                    StartCoroutine(MakeMeteor(0));

                    break;
                }

            case 2:
                {
                    StartCoroutine(MakeMeteor(0));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 2.0f)));

                    break;
                }

            case 3:
                {
                    StartCoroutine(MakeMeteor(0));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 2.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 3.0f)));

                    break;
                }

            case 4:
                {
                    StartCoroutine(MakeMeteor(0));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 2.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 3.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 4.0f)));

                    break;
                }

            case 5:
                {
                    StartCoroutine(MakeMeteor(0));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 2.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 3.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 4.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 5.0f)));

                    break;
                }

            default:
                {
                    StartCoroutine(MakeMeteor(0));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 2.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 3.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 4.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 5.0f)));
                    StartCoroutine(MakeMeteor(Random.Range(0.0f, 6.0f)));

                    break;
                }
        }
    }

    // 메테오 생성 코루틴
    IEnumerator MakeMeteor(float time)
    {
        // warning 복사본
        GameObject warningCopy;
        // meteor 복사본
        GameObject meteorCopy;
        // waring의 위치를 임시로 저장할 변수
        float tempWarningPos = 0;

        // warning 생성, Clone의 Component에 접근할 수 있게 as GameObject를 사용함
        warningCopy = Instantiate(warning, new Vector3(Random.Range(-2f, 2f), 0, -0.1f), meteor.transform.rotation) as GameObject;
        // meteor 생성
        meteorCopy = Instantiate(meteor) as GameObject;

        // meteor 비활성화
        meteorCopy.SetActive(false);
        // warning 비활성화
        warningCopy.SetActive(false);

        // meteor 생성 간격만큼 기다림
        yield return new WaitForSeconds(time);

        // warning 활성화
        warningCopy.SetActive(true);

        // 무한 루프
        while (true)
        {
            // warning 복사본에 값이 있다면
            if (warningCopy != null)
            {
                // warning이 player를 따라갈 방향을 계산
                Vector3 targetDirection = player.transform.position - warningCopy.transform.position;

                // y축으로는 움직이지 않음
                targetDirection.y = 0;
                // z축으로는 움직이지 않음
                targetDirection.z = 0;

                // player를 따라감
                warningCopy.transform.position += targetDirection * 1f * Time.deltaTime;

                // warning의 위치를 저장해놓음
                tempWarningPos = warningCopy.transform.position.x;
                tempWarningPos.Equals(warning);
            }
            else if (meteorCopy != null && meteorCopy.activeSelf == false)  // meteor에 값이 있고 비활성화 상태라면
            {
                // meteor의 위치는 임시로 저장한 warning의 위치
                meteorCopy.transform.position = new Vector3(tempWarningPos, 6, -0.1f);
                // meteor 활성화
                meteorCopy.SetActive(true);
            }

            // meteor에 값이 있고 meteor가 활성화 상태라면
            if (meteorCopy != null && meteorCopy.activeSelf == true)
            {
                // meteor를 아래로 이동시켜줌
                meteorCopy.transform.position += new Vector3(0, -6f, -0.1f) * Time.deltaTime;
            }

            // meteor복사본이 값이 없다면 무한 루프 탈출
            if (meteorCopy == null)
            {
                break;
            }

            // 한 프레임을 기다림
            yield return new WaitForEndOfFrame();
        }

        // 다시 meteor 생성
        StartCoroutine(MakeMeteor(0));
    }
}