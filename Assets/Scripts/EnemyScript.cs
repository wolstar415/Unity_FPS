using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum ENEMYSTATE
    {
        NONE = -1,
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }

    public ENEMYSTATE enemyState = ENEMYSTATE.NONE;
    public float stateTime;
    public float idleStateTime = 2f;
    public Transform target;

    public float speed = 2f;
    public float rotationSpeed = 10f;
    public float attackRange = 2.5f;
    public float attackStateMaxTime = 2f;
    public CharacterController characterController;
    public int hp = 5;
    public Animator animator;
    public PlayerState playerState;
    public ScoreManager scoreManager;

    void Start()  // 처음 시작시 실행되는 함수입니다.
    {

        enemyState = ENEMYSTATE.IDLE;
        target = GameObject.Find("Player").transform;
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        playerState =target.GetComponent<PlayerState>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        // Cursor.lockState = CursorLockMode.Locked;
    }



    void Update() // 매 프레임마다 실행되는 함수입니다.
    {



        switch (enemyState)
        {
            case ENEMYSTATE.NONE:
                Debug.Log("할거없음...");

                break;
            case ENEMYSTATE.IDLE:
                stateTime += Time.deltaTime;
                if (stateTime > idleStateTime)
                {
                    stateTime = 0;
                    enemyState = ENEMYSTATE.MOVE;
                }
                    break;
            case ENEMYSTATE.MOVE:
                //float distance = (target.position - transform.position).magnitude;
                float distance = Vector3.Distance(target.position, transform.position);
                if (distance < attackRange)
                {
                    enemyState = ENEMYSTATE.ATTACK;


                }
                else
                {
                    Vector3 dir = target.position - transform.position;
                    Debug.DrawLine(target.position, transform.position, Color.red);
                    //Debug.Log("기본 ::: "+dir);
                    dir.y = 0;
                    dir.Normalize();

                    //Debug.Log("노멀라이즈 ::: "+dir);
                    //characterController.Move(dir * speed);

                    characterController.SimpleMove(dir*speed);
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir),rotationSpeed*Time.deltaTime);

                }
                //transform.position = new Vector3(transform.position.x,1f,transform.position.z);
                break;
            case ENEMYSTATE.ATTACK:
                
                Vector3 dirz = target.position - transform.position;
                dirz.y = 0;
                dirz.Normalize();
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dirz), rotationSpeed * Time.deltaTime);
                stateTime += Time.deltaTime;
                if (stateTime > attackStateMaxTime)
                {
                    stateTime = 0;
                    //print(Vector3.Distance(target.position, transform.position));
                    if (Vector3.Distance(target.position, transform.position) < attackRange)
                    {
                    playerState.DamageByEnemy();

                    }
                    //Debug.Log("플레이어 공격!!!!!");

                }
                float dist = Vector3.Distance(target.position, transform.position);
                if (dist > attackRange)
                {

                    enemyState = ENEMYSTATE.MOVE;

                }
                break;
            case ENEMYSTATE.DAMAGE:
                stateTime += Time.deltaTime;

                if (stateTime >1f)
                {
                    stateTime = 0;
                    enemyState = ENEMYSTATE.MOVE;
                }
                if (hp <= 0)
                {
                    enemyState = ENEMYSTATE.DEAD;
                    //characterController.enabled = false;
                    //DeadProcess2(2f);
                    Invoke("DeadProcess3", 2f);
                    scoreManager.myScore += 10;
                }
                    break;
            case ENEMYSTATE.DEAD:
                
                
                //Destroy(gameObject,3f);
                //gameObject.SetActive(false);
                //print("1");
                //DeadProcess(1f);
                break;
            default:

                break;
        }
        animator.SetInteger("ZombieState", (int)enemyState);

    }

    void DeadProcess3()
    {
        
        gameObject.SetActive(false);
        InitEnemy();
    }
    IEnumerator DeadProcess2(float t)
    {
        print("2");
        
        yield return new WaitForSeconds(t);
        while (transform.position.y > -t)
        {
            Vector3 temp = transform.position;
            temp.y -= 0.01f * Time.deltaTime;
            transform.position = temp;
            yield return new WaitForEndOfFrame();
        }
        
        gameObject.SetActive(false);
        InitEnemy();
    }

    public void InitEnemy()
    {
        //characterController.enabled = true;
        hp = 5;
        enemyState = ENEMYSTATE.IDLE;
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet" && enemyState!=ENEMYSTATE.DEAD)
        {

            --hp;
            //print(hp);
            enemyState = ENEMYSTATE.DAMAGE;
        }

    }
}
