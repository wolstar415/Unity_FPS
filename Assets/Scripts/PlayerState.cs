using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public int hp = 5;
    public bool isDead = false;
    public Slider hpBar;
    public GameObject gameOver;
    public CameraShake cameraShake;
    public Text scoreText;
    //public ScoreManager scoreManager;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }


    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (isDead == false)
        {
            hpBar.value = (float)hp / 5;
        }
        else
        {
            hpBar.value = 0;
            gameOver.SetActive(true);
            //Debug.Log("You Died!!!!!!!!!");
        }

        //int score = scoreManager.myScore;
        //int bestscore = scoreManager.bestScore;
        int score = ScoreManager.Instance().myScore;
        int bestscore = ScoreManager.Instance().bestScore;
        scoreText.text = "MY SCORE : " + score + "\nBEST SCORE : " + bestscore;
        //scoreText.text = "zz " + score + "\nBEST SCORE : " + bestscore;
    }

    public void DamageByEnemy()
    {
       cameraShake.PlayCameraShake();
        --hp;
        if (hp <= 0)
        {
            isDead = true;
        }
    }

}
