using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // 
    public GameObject gold;
    public static GameObject test;

    public GameObject hpBox;
    public static GameObject test1;

    void Awake()
    {
        // GetComponent쓰지 않고 GameObject 넣기, 테스트용
        test = gold;
        test1 = hpBox;

    }

    // 돈 생성
    public static void MakeMoney(Transform target, int count)
    {
        while (count > 0)
        {
            Instantiate(test, target.position, target.rotation);
            count--;
        }
    }

    // HP 생성
    public static void MakeHp(Transform target, int count)
    {
        while (count > 0)
        {
            Instantiate(test1, target.position, target.rotation);
            count--;
        }
    }
}