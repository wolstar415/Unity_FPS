using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMnoDestory : MonoBehaviour
{
    public static BGMnoDestory _instance = null;
    public static BGMnoDestory Instance()
    {
        return _instance;
    }
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
