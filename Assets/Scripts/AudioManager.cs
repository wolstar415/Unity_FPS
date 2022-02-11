using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    static AudioManager _instance = null;
    public static AudioManager Instance()
    {
        return _instance;
    }


    public AudioClip bgm;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {

        if (_instance == null)
        {
            _instance = this;
        }
        GetComponent<AudioSource>().clip = bgm;
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();

    }

    public void PlaySfx(AudioClip sfx)
    {
        GetComponent <AudioSource>().PlayOneShot(sfx);
    }
    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
