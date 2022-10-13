using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 코인 사운드 저장 변수
    public AudioClip getGoldSound;
    // 미사일 발사 사운드 저장 변수
    public AudioClip playerShootSound;

    // AudioSource 변수
    AudioSource audiosource;

    // SoundManager 객체 선언
    public static SoundManager soundManager = null;

    private void Awake()
    {
        soundManager = this;
    }

    private void Start()
    {
        // audiosource 컴포넌트 추가
        audiosource = GetComponent<AudioSource>();
    }

    // 코인 얻는 때 나오는 사운드 함수
    public void PlayGetGoldSound()
    {
        audiosource.volume = 1.0f;
        audiosource.PlayOneShot(getGoldSound);
    }

    // 미사일 발사할 때 나오는 사운드 함수
    public void PlayPlayerShootSound()
    {
        audiosource.volume = 1.0f;
        audiosource.PlayOneShot(playerShootSound);
    }
}
