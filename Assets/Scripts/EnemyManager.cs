using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject[] enemyPool;
    public int poolSize = 10;
    public float curTime;
    public float spawnTime = 2f;
    int spawnCnt = 1;
    public int maxSpawnCnt = 20;
   
    void Start()  // 처음 시작시 실행되는 함수입니다.
    {
        enemyPool = new GameObject[poolSize];
        for (int i = 0; i < enemyPool.Length; i++)
        {
            if (i == 9)
            {
                enemyPool[i] = Instantiate(enemyPrefab2) as GameObject;
                enemyPool[i].SetActive(false);
            }
            else
            {
                enemyPool[i] = Instantiate(enemyPrefab) as GameObject;
                enemyPool[i].SetActive(false);
            }

        }


    }

    
    void Update() // 매 프레임마다 실행되는 함수입니다.
    {
        curTime += Time.deltaTime;
        if (curTime > spawnTime)
        {
            //GameObject enemy = Instantiate(enemyPrefab) as GameObject;
            //float x = Random.Range(-20f, 20f);
            //enemy.transform.position = new Vector3(x, 1, 20f);
            //enemy.name = "ENEMY_" + spawnCnt;
            //++spawnCnt;
            curTime = 0;
            for (int i = 0; i < enemyPool.Length; i++)
            {
                if (enemyPool[i].activeSelf == true)
                {
                    continue;
                }
                else
                {
                    float x = Random.Range(-20f, 20f);
                    enemyPool[i].transform.position = new Vector3(x, 1f, 20f);
                    enemyPool[i].SetActive(true);
                    enemyPool[i].name = "ENEMY_" + spawnCnt;
                    ++spawnCnt;
                    break;
                }
            }
        }

    }
}
