using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Scavenger : MonoBehaviour
{
    public float DistanceTriggered;

    public float DistanceToPlayer;

    public GameObject player;

    public Movement movement;

    private NavMeshAgent agent;

    private Rigidbody rb;

    public int Health;

    Animator animator;

    public GameObject ScavengerHealthSlider;

    [SerializeField] private Camera camera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        DistanceTriggered = 35f;

        Health = 1000;

        ScavengerHealthSlider.GetComponent<Slider>().value = Health;

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        ScavengerHealthSlider.transform.rotation = camera.transform.rotation;

        ScavengerHealthSlider.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8, gameObject.transform.position.z);

        animator.SetFloat("PlayerRange", DistanceToPlayer);

        DistanceToPlayer = Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position);

        if (DistanceToPlayer <= DistanceTriggered)
        {
            if(DistanceToPlayer <= 7f)
            {
                agent.speed = 0;
                animator.SetBool("TouchingPlayer", true);
            }
            else
            {
                animator.SetBool("TouchingPlayer", false);
                MoveTowardsPlayer();
            }
        }
        else
        {
            agent.speed = 0;
        }


    }

    public void MoveTowardsPlayer()
    {
        agent.speed = 14;
        animator.SetFloat("Speed", agent.speed);
        agent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player");
            movement.Health -= 25;
        }
    }
}

