using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : MonoBehaviour
{
    public float DistanceTriggered;
    public float DistanceAttackTriggered;

    public float DistanceToPlayer;

    public GameObject player;
    private bool MonsterAttracted;
    private bool MonsterAttackAttracted;

    private float maxSpeed;
    private float speed;

    private int Health;

    private Rigidbody rb;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DistanceTriggered = 50f;
        DistanceAttackTriggered = 15f;

        maxSpeed = 10;
        speed = 10;

        MonsterAttackAttracted = false;

        Health = 100;

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        DistanceToPlayer = Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position);

        if (DistanceToPlayer <= DistanceTriggered)
        {
            MonsterAttracted = true;
        }
        else
        {
            MonsterAttracted = false;
        }

        if (MonsterAttracted)
        {
            MoveTowardsPlayer();
        }


    }

    public void MoveTowardsPlayer()
    {
        Vector3 velocity = rb.velocity;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            rb.velocity = velocity;
        }

        Vector3 TargetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(TargetPosition, Vector3.up);

        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("TouchingPlayer", true);
        }
        else
        {
            animator.SetBool("TouchingPlayer", false);
        }
    }
}

