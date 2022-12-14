using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ZombieState
{
    Idle,
    Chase,
    Attack,
    death
}

public class ZombieController : MonoBehaviour
{
    public float alertRange = 10f;

    public float moveSpeed = 5f;
    public float attackInterval = 2f;
    float nextAttackTime;
    public int damage = 5;

    public float attackRange = 1f;

    public DamageCollider damageCollider;
    public ZombieState state;

    private Transform playerTransform;
    NavMeshAgent agent;
    Animator animator;
    Rigidbody rb;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        damageCollider = GetComponentInChildren<DamageCollider>();
        rb = GetComponent<Rigidbody>();
        state = ZombieState.Idle;
        nextAttackTime = Time.time;
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case ZombieState.Idle:
                IdleUpdate();
                break;

            case ZombieState.Chase:
                ChaseUpdate();
                break;

            case ZombieState.Attack:
                AttackUpdate();
                break;
            case ZombieState.death:
                OnDeath();
                break;
        }
    }

    void IdleUpdate()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) <= alertRange)
        {
            agent.stoppingDistance = attackRange;
            agent.speed = moveSpeed;
            state = ZombieState.Chase;
            return;
        }
    }

    void ChaseUpdate()
    {
        FacePlayer();
        if (Vector3.Distance(playerTransform.position, transform.position) <= attackRange)
        {
            agent.ResetPath();
            state = ZombieState.Attack;
            return;
        }
        agent.SetDestination(playerTransform.position);
    }

    void AttackUpdate()
    {
        FacePlayer();
        if (Vector3.Distance(playerTransform.position, transform.position) >= attackRange * 1.2)
        {
            state = ZombieState.Chase;
            return ;
        }

        agent.ResetPath();
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackInterval;
            animator.CrossFade("Attack", 0.2f);
        }   
    }

    void OnDeath()
    {
        animator.CrossFade("Death", 0.2f);
        GetComponent<ZombieController>().enabled = false;
    }

    void FacePlayer()
    {
        transform.LookAt(playerTransform);
    }

    public void TurnOnDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void TurnOffDamageCollider()
    {
        damageCollider.enabled = false;
    }
}
