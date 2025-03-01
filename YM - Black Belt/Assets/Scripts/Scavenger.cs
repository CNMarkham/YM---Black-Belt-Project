using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scavenger : MonoBehaviour
{
    public float DistanceTriggered;

    public float DistanceToPlayer;

    public GameObject player;

    private NavMeshAgent agent;

    private bool MonsterAttracted;

    private Rigidbody rb;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DistanceTriggered = 35f;

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        animator.SetFloat("PlayerRange", DistanceToPlayer);
        Debug.Log(DistanceToPlayer);

        DistanceToPlayer = Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position);

        if (DistanceToPlayer <= DistanceTriggered)
        {
            MonsterAttracted = true;
        }
        else if(DistanceToPlayer >= DistanceTriggered)
        {
            MonsterAttracted = false;
        }

        if (MonsterAttracted)
        {
            agent.speed = 14;
            MoveTowardsPlayer();
        }
        else if(!MonsterAttracted)
        {
            agent.speed = 0;
        }


    }

    public void MoveTowardsPlayer()
    {
        animator.SetFloat("Speed", agent.speed);
        agent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            agent.speed = 0;
            animator.SetBool("TouchingPlayer", true);
        }
        else
        { 
            animator.SetBool("TouchingPlayer", false);
        }
    }
}

