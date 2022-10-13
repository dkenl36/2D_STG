using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
    public float fSpeed = 3f;
    public int iEnemyHp = 1;
    public GameObject Effect;

    // 미사일에 맞았을시 애니메이션 제어해줘야함으로 애니메이션 변수 선언
    Animator enemyAni;
    
    void Awake()
    {
        enemyAni = GetComponent<Animator>();
    }

    void Update()
    {
        // 현재 좌표 기준으로 fSpeed만큼 아래로(Vector3.down)움직인다
        transform.Translate(Vector3.down * fSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // 충돌된 오브젝트의 태그이름이 "Missile" 일경우 트루반환
        if (col.CompareTag("Missile"))
        {
            // hp를 깍는다
            iEnemyHp--;

            // 적이 맞는 애니메이션 재생
            enemyAni.SetTrigger("hit");

            // 맞은 총알은 없애준다 
            Destroy(col.gameObject);

            // 체력이 0 이하면 
            if (iEnemyHp <= 0)
            {
                // 돈과 아이템 생성
                ItemManager.MakeMoney(transform, Random.Range(0, 5));
                ItemManager.MakeHp(transform, Random.Range(0, 2));

                // 스코어 더해줌
                ScoreManager.scoreManager.AddRandomScore(10, 50);

                // 이펙트 생성
                Instantiate(Effect, transform.position, transform.rotation);

                // 자기 자신 삭제
                Destroy(gameObject);
            }
        }
    }
}
