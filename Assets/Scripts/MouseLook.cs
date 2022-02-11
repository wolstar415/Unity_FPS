using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += (mouseMoveValueX * sensitivity *Time.deltaTime);
        rotationX += (mouseMoveValueY * sensitivity * Time.deltaTime);

        if (rotationX > 25f)
        {
            rotationX = 25f;
        }


        if (rotationX < -50f)
        {
            rotationX = -50f;
        }

        transform.eulerAngles = new Vector3(-rotationX, rotationY,0);


       // Debug.Log(mouseMoveValueX);
       // Debug.Log(mouseMoveValueY);



    }
}
