using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private Vector3 velocity;
    
   
    public bool grounded;
    private float jumpForce;
    private Rigidbody rb;
    private RaycastHit hit;
    private float maxSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 20;
        jumpForce = 10;
        grounded = true;
        maxSpeed = 10;


    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 2, Color.red);
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 velocity = rb.velocity;

            if (velocity.magnitude > maxSpeed)
            {
                velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
                rb.velocity = velocity;
            }
            rb.AddForce(transform.forward * speed);

            Debug.Log(velocity);

        }

        if (Input.GetKey(KeyCode.A))
        {

            Vector3 velocity = rb.velocity;

            if (velocity.magnitude > maxSpeed)
            {
                velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
                rb.velocity = velocity;
            }


            rb.AddForce(-transform.right * speed);

            Debug.Log(velocity);


        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 velocity = rb.velocity;

            if (velocity.magnitude > maxSpeed)
            {
                velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
                rb.velocity = velocity;
            }
            
            
            rb.AddForce(transform.right * speed);
            
            Debug.Log(velocity);
        }

        if (Input.GetKey(KeyCode.S))
        {

            Vector3 velocity = rb.velocity;

            if (velocity.magnitude > maxSpeed)
            {
                velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
                rb.velocity = velocity;
            }
            rb.AddForce(-transform.forward * speed);

            Debug.Log(velocity);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }


    }

    private void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f, LayerMask.GetMask("Terrain")))
        {
            Debug.Log("1");
            grounded = true;
        }
        else
        {
            Debug.Log("2");
            grounded = false;
        }

        if (grounded == true)
        {
            Debug.Log("3");
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;

            grounded = false;
        }
        else
        {
            Debug.Log("4");
            return;
        }


    }

}
