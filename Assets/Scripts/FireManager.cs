using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public Transform cameratransform;
    public GameObject bulletPrefab;
    public Transform firePosition;

    public float power = 25f;
    public float deadTime = 3f;
    public GameObject effect2;
    public AudioManager audioManager;
    public AudioClip bombSound;
    public Animator anim;



    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        anim = GetComponentInChildren<Animator>();
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.Play("Gun Shot");
            audioManager.PlaySfx(bombSound);
            Instantiate(effect2, firePosition.position, firePosition.rotation);
            //Destroy(effect2, deadTime);
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = firePosition.position;
            bullet.GetComponent<Rigidbody>().velocity = cameratransform.forward* power;
            //Debug.Log(cameratransform.forward);
            //Destroy(bullet, deadTime);
        }
    }
}
