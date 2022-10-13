using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //씬 전환시 써주어야함
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float fSpeed;
    public GameObject effect;

    void Update()
    {
        // 좌우 이동
        float h = Input.GetAxis("Horizontal");
        Vector3 hVelocity = Vector3.right * h * fSpeed * Time.deltaTime;
        transform.position += hVelocity;

        // 상하 이동
        float v = Input.GetAxis("Vertical");
        Vector3 vVelocity = Vector3.up * v * fSpeed * Time.deltaTime;
        transform.position += vVelocity;

        // 화면 벗어나지 않게 하기
        Vector3 mypos = transform.position;
        mypos.x = Mathf.Clamp(transform.position.x, -2, 2);
        mypos.y = Mathf.Clamp(transform.position.y, -3, 3);
        transform.position = mypos;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            // 피격당하면 체력 1 감소
            HPBoxManager.g_Hp = HPBoxManager.g_Hp - 1;
            HPBoxManager.hpBoxManager.t_Hp.text = HPBoxManager.g_Hp.ToString();

            // 충돌한 적은 삭제
            Destroy(col.gameObject);

            // 플레이어 위치에 이펙트 생성
            Instantiate(effect, transform.position, transform.rotation);

            // 만약 체력이 0이하라면
            if (HPBoxManager.g_Hp <= 0)
            {
                // Result 씬으로 이동
                SceneManager.LoadScene("Result");

                // 마우스 커서 보이고 잠금 해제
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}