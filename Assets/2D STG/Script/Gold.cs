using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    void OnEnable()
    {
        // 코인이 퍼지는 효과를 만들기 위해서 작성
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50, 50), Random.Range(200, 300)));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // 랜덤한 코인 휙득
            GoldManager.goldmanager.AddRandomGold(1, 10);

            // 코인 휙득 사운드
            SoundManager.soundManager.PlayGetGoldSound();

            Destroy(gameObject);
        }
    }
}