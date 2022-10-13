using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMissile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // .tag는 리소스낭비 .CompareTag사용
        // Missile이면 삭제
        if(collision.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
