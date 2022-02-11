using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static IntroManager _instance = null;
    public Button startBtn;

    public void GoMainScene()
    {
        SceneManager.LoadScene(1);
    }
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
        //startBtn = GameObject.Find("StartButton").GetComponent<Button>();
        //startBtn.onClick.AddListener(StartBtnClick);
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
       if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }


    }

    public void StartBtnClick()
    {
        SceneManager.LoadScene("02_Main_NavMesh");

    }



}
