 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    GameObject target;

    EnemyStats enemyStats;
    [SerializeField] public float StopDistance = 1;
    [SerializeField] public int Damage = 10; 
    Animator anim;
    float LastAttackTime = 0;
    float AttackCoolDown = 1;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>(); 
        enemyStats = GetComponent<EnemyStats>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position,target.transform.position); 
        if(dist < StopDistance && enemyStats.isDead != true)
        {
            StopEnemy();
            if (Time.time - LastAttackTime > AttackCoolDown)
            {
                LastAttackTime = Time.time;
                anim.SetBool("Attack",true);
                target.GetComponent<PlayerStats>().Takedmg(Damage);
                // Debug.Log(target.GetComponent<PlayerStats>().currHP);
            }
        }
        else if (target.transform.position.z < 30) target.GetComponent<PlayerStats>().Die();
        else if(enemyStats.isDead == true)
        {
            Dead();
        }
        else
        {
            ToTarget();
        
        }
    }

    private void ToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("IsWalking",true);
    }
    private void Dead()
    {
        agent.isStopped = true;
        anim.SetBool("IsWalking",false);
        anim.SetBool("Attack",false);
        anim.SetBool("IsDead",true);
    }
    private void StopEnemy()
    {
        agent.isStopped = true;
        agent.transform.forward = Vector3.ProjectOnPlane((Camera.main.transform.position - agent.transform.position),Vector3.up).normalized;
        anim.SetBool("IsWalking",false);
    }
}
