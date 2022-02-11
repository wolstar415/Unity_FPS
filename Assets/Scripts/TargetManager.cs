using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public float curTime;
    public float coolTime;
    public GameObject targetPrefab;


    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        curTime += Time.deltaTime;
        if (curTime > coolTime)
        {
            int rndPosX = Random.Range(-4, 5);
            int rndPosY = Random.Range(1, 4);
            GameObject targer = Instantiate(targetPrefab) as GameObject;
            targer.transform.position = new Vector3(rndPosX, rndPosY,2);
            curTime = 0;

        }
    }
}
