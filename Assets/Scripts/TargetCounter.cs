using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetCounter : MonoBehaviour
{
    public int cnt = 0;
    public Text scoreText;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
     scoreText=GameObject.Find("ScoreText").GetComponent<Text>();   
    }

    public void PlusCnt()
    {
        cnt++;
        scoreText.text = "Score : " + cnt;
    }
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
}
