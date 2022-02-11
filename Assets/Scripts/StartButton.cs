using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
   
    public void StartButton1()
    {
        SceneManager.LoadScene(1);
    }

    public void StartButton2()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitButton() // 매 프레임마다 실행되는 함수입니다.
    {
        Application.Quit();
    }
    public void ExitButton2() // 매 프레임마다 실행되는 함수입니다.
    {
        Application.Quit();
    }
}
