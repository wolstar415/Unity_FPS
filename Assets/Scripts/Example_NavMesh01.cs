using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Example_NavMesh01 : MonoBehaviour
{
    public NavMeshAgent nvAgent;
    public Transform target;
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
     nvAgent = GetComponent<NavMeshAgent>();
        
    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        nvAgent.SetDestination(target.position);
    }
}
