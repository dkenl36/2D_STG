using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{

    // 미사일 발사 위치변수
    public Transform FirePos1;
    public Transform FirePos2;
    public Transform FirePos3;
    public Transform FirePos4;
    public Transform FirePos5;
    public Transform FirePos6;
    public Transform FirePos7;

    // 미사일 프리팹
    public GameObject goMissile;

    //몇초에 한번씩 미사일이 나갈지 제어해주는 변수
    public float fIntervalMax = 0.1f;
    private float fInterval = 0;

    // 공격 횟수 레벨
    public static int g_AttackNum_level = 0;

    void Update()
    {
        // fInterval에 시간값을 더해줌
        fInterval = fInterval + Time.deltaTime;

        // Z키 누르고 게임이 정지상태가 아니면 발사
        if(Input.GetKey(KeyCode.Mouse0) && PauseManager.pauseManager.isPause == false)
        {
            // fInterval값이 fIntervalMax보다 크면 발사
            if (fInterval > fIntervalMax)
            {
                // 그리고 fInterval값을 다시 0으로 초기화
                fInterval = 0;

                // 발사 소리 한번 재생
                SoundManager.soundManager.PlayPlayerShootSound();

                // 공격 횟수 레벨에 따른 미사일 발사
                switch (g_AttackNum_level)
                {
                    case 0:
                        {
                            Instantiate(goMissile, FirePos1.position, Quaternion.identity);
                            break;
                        }

                    case 1:
                        {
                            Instantiate(goMissile, FirePos2.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos3.position, Quaternion.identity);
                            break;
                        }

                    case 2:
                        {
                            Instantiate(goMissile, FirePos1.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos2.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos3.position, Quaternion.identity);
                            break;
                        }

                    case 3:
                        {
                            Instantiate(goMissile, FirePos2.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos3.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos4.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos5.position, Quaternion.identity);
                            break;
                        }

                    case 4:
                        {
                            Instantiate(goMissile, FirePos1.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos2.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos3.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos4.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos5.position, Quaternion.identity);
                            break;
                        }

                    case 5:
                        {
                            Instantiate(goMissile, FirePos2.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos3.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos4.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos5.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos6.position, Quaternion.identity);
                            Instantiate(goMissile, FirePos7.position, Quaternion.identity);
                            break;
                        }
                }
            }
        }
    }
}