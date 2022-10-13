using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // 미사일 이동 속도
    public static int fSpeed = 5;

    void Update()
    {
        // 미사일 발사
        transform.Translate(Vector3.up * fSpeed * Time.deltaTime);
    }
}
