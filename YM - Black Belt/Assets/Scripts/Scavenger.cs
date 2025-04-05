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

    private bool Attacking;

    Animator animator;

    public GameObject ScavengerHealthSlider;

    [SerializeField] private Camera camera;

    public GameObject ScavHealthSlider;

    private int RandomizedAnim;

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
        //Debug.Log(Attacking);

        ScavengerHealthSlider.transform.rotation = camera.transform.rotation;

        ScavengerHealthSlider.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8, gameObject.transform.position.z);

        animator.SetFloat("PlayerRange", DistanceToPlayer);

        DistanceToPlayer = Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position);

        if (DistanceToPlayer <= DistanceTriggered)
        {
            if(DistanceToPlayer <= 7f)
            {
                agent.speed = 0;
                if(DistanceToPlayer <= 5.5f)
                {
                    RandomizedAnim = Random.Range(1, 3);
                    Debug.Log(RandomizedAnim);
                    animator.SetInteger("Random", RandomizedAnim);
                    animator.SetBool("TouchingPlayer", true);
                }
            }
            else
            {
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


    IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(1.9f);

        movement.Health -= Random.Range(50, 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //RandomizedAnim = Random.Range(1, 3);
            //Debug.Log(RandomizedAnim);
            //animator.SetInteger("Random", RandomizedAnim);
            //animator.SetBool("TouchingPlayer", true);
            Attacking = true;
            if(Attacking)
            {
                StartCoroutine("TakeDamage");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("TouchingPlayer", false);
        Attacking = false;
    }
}

