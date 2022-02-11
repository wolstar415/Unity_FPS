using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_RayCast01 : MonoBehaviour
{

    Vector3 point1 = new Vector3(0, 0, 0);
    Vector3 point2 = new Vector3(100, 0, 0);

        
    RaycastHit hit;
    public GameObject metalEffect;
    public GameObject woodEffect;
    public GameObject grungeEffect;
    public GameObject targetEffect;
    public AudioClip metalSound;
    public AudioClip woodSound;
    public AudioClip grungeSound;
    public AudioClip targetSound;
    public AudioSource audioSourece;
    public TargetCounter targetCounter;

    public Animator gunAnim;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        audioSourece = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        targetCounter = GetComponent<TargetCounter>();
    
        gunAnim = GetComponentInChildren<Animator>();

    }

    
    void cursorcheck()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            cursorcheck();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log(hit.point);
                gunAnim.Play("Gun Shot");

                switch (hit.collider.tag)
                {
                    case "Metal":
                        Instantiate(metalEffect, hit.point, Quaternion.Euler(-180f,0,0));
                        audioSourece.PlayOneShot(metalSound);

                        break;
                    case "Wood":
                        Instantiate(woodEffect, hit.point, Quaternion.Euler(-180f, 0, 0));
                        audioSourece.PlayOneShot(woodSound);
                        break;
                    case "Grunge":
                        Instantiate(grungeEffect, hit.point, Quaternion.Euler(-180f, 0, 0));
                        audioSourece.PlayOneShot(grungeSound);
                        break;
                    case "Target":
                        Instantiate(targetEffect, hit.point, Quaternion.Euler(-180f, 0, 0));
                        audioSourece.PlayOneShot(targetSound);
                        targetCounter.PlusCnt();
                        Destroy(hit.collider.gameObject);
                        break;
                    default:
                        break;


                }


            }
            

        }
        Debug.DrawRay(point1, point2, Color.red);
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }


}
