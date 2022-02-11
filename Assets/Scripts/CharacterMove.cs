using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpSpeed = 10f;
    public float gravity = -20f;
    public float yVelocity = 0;
    public CharacterController characterController;
    public Transform cameraTransform;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        characterController = GetComponent<CharacterController>();
    }

    void Cursor_onoff()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            print("z");
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            print("x");
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        if (Input.GetKeyUp(KeyCode.F12))
        {
            Cursor_onoff();
        }
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(0, 20f, 0);
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(h, 0, v);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        //Debug.Log("HERE!!!!!");
        //Debug.LogError("moveDirection :::: " + moveDirection);
        //Debug.LogWarning("END");
        moveDirection *= moveSpeed;

        if (characterController.isGrounded)
        {
            yVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpSpeed;
            }
        }

        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;


        characterController.Move(moveDirection * Time.deltaTime);


    }
}
