using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float deadTime = 3f;
    public GameObject effect;
    
    public GameObject groundEffect;
    public AudioManager audioManager;
    public AudioClip bombSound1;
    public AudioClip bombSound2;
    public AudioClip bombSound3;


   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Destroy(gameObject,deadTime);
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.layer == 8)
        {
            audioManager.PlaySfx(bombSound1);
            Instantiate(groundEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 9)
        {
            audioManager.PlaySfx(bombSound2);
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 10)
        {
            audioManager.PlaySfx(bombSound3);
            Instantiate(effect, transform.position, transform.rotation);
            //collision.gameObject.GetComponent<EnemyScript>().enemyState = EnemyScript.ENEMYSTATE.DAMAGE;
            Destroy(gameObject);
        }
    }
}
