using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGControll : MonoBehaviour
{
    public GameObject[] BGList;

    public float speed;

    private void FixedUpdate()
    {
        for (int i = 0; i < BGList.Length; i++)
        {
            BGList[i].transform.position += Vector3.down * speed * Time.deltaTime;

            // 배경이 일정 위치까지 내려가면 다시 위로 올려줌
            if (BGList[i].transform.position.y < -8.0f)
            {
                BGList[i].transform.position = new Vector3(0, 15.5f, 0);
            }
        }
    }
}
