using UnityEngine;
using System.Collections;


public class EnemyManager : MonoBehaviour
{
    // 적 오브젝트
    public GameObject goEnemy;

    // 랜덤한 X좌표 저장할 변수
    private float randomX;
    // 랜덤한 Y좌표 저장할 변수
    private float randomY;

    void Start()
    {
        // 코루틴으로 적 생성
        StartCoroutine(MakeEenemy(0.25f));
    }

    IEnumerator MakeEenemy(float spawn_time)
    {
        // 새로운 랜덤좌표 생성
        randomX = Random.Range(-2f, 3f);
        randomY = Random.Range(5f, 7f);

        Instantiate(goEnemy, new Vector3(randomX, randomY, -0.1f), Quaternion.identity);

        yield return new WaitForSeconds(spawn_time);

        StartCoroutine(MakeEenemy(0.25f));
    }
}