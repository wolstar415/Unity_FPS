using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Vector3 myLocalPosition;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {

    }


    IEnumerator CameraShakeProcess(float shakeTime, float shakeSence)
    {
        float curTime = 0;
        while (curTime < shakeTime)
        {
            curTime += Time.deltaTime;
            transform.localPosition = myLocalPosition;

            Vector3 pos = new Vector3(0,0,0);
            pos.x = Random.Range(-shakeSence,shakeSence);
            pos.y = Random.Range(-shakeSence,shakeSence);
            pos.z = Random.Range(-shakeSence,shakeSence);

            transform.localPosition += pos;
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = myLocalPosition;
    }

    public void PlayCameraShake()
    {
        StartCoroutine(CameraShakeProcess(0.5f, 0.25f));

    }

}
