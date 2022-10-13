using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBox : MonoBehaviour
{
    void OnEnable()
    {
        // HPBox 퍼지는 효과주기위해 작성
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50, 50), Random.Range(200, 300)));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // 남은 HP 1 올리기
            HPBoxManager.hpBoxManager.addHp(1);

            Destroy(gameObject);
        }
    }
}
