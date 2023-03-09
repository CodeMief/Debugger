using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyV2Behaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private StatsSO stats;
    NavMeshAgent agent;
    float TargetDistance = Mathf.Infinity;

    [SerializeField] public float radius;
    [Range(0, 360)]
    [SerializeField] public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public bool isProvoked = false;
    public bool canJump = true;

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2;
        agent.speed = stats.MovementSpeed;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private void FixedUpdate()
    {
        TargetDistance = Vector3.Distance(target.position, transform.position);
        if (isProvoked || canSeePlayer)
        {
            EngageTarget();
        }
    }

    private void EngageTarget()
    {
        transform.LookAt(target.position);
        if (TargetDistance > agent.stoppingDistance)
        {

            ChaseTarget();
        }

        if (TargetDistance <= agent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        //avtivate attack animation
    }

    private void ChaseTarget()
    {
        //disable attack animation and enable move animation
        agent.SetDestination(target.position);
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void OnDamageTake()
    {
        isProvoked = true;
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    isProvoked = true;
                }
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
