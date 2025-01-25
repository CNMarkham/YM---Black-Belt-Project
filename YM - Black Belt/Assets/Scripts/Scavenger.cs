using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : MonoBehaviour
{
    public float DistanceTriggered;

    public float DistanceToPlayer;

    public GameObject player;
    private bool MonsterAttracted;

    private float maxSpeed;
    private float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DistanceTriggered = 50f;

        maxSpeed = 10;
        speed = 15;
    }


    void Update()
    {
        DistanceToPlayer = Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position);
        
        if(DistanceToPlayer <= DistanceTriggered)
        {
            MonsterAttracted = true;
        }
        else
        {
            MonsterAttracted = false;
        }

        if(MonsterAttracted)
        {
            MoveTowardsPlayer();
        }


    }

    public void MoveTowardsPlayer()
    {

        Vector3 velocity = rb.velocity;

        if (velocity.magnitude > maxSpeed)
        {
            velocity.x = Mathf.Min(velocity.x, maxSpeed);
            velocity.y = Mathf.Min(velocity.y, 5);
            velocity.z = Mathf.Min(velocity.z, maxSpeed);
            rb.velocity = velocity;

        }

        transform.LookAt(player.gameObject.transform, Vector3.up);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);


        //Vector3.MoveTowards(gameObject.transform.position, player.gameObject.transform.position, 10f);
    }
}
