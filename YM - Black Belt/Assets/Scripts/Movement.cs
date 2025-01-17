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

    public int MaxStamina;
    public int Stamina;
    private bool StaminaToggle;


    //public PlayerUI PlayerUI;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 20;
        jumpForce = 10;
        grounded = true;
        maxSpeed = 10;

        Stamina = 1000;

    }

    void Update()
    {
        gameObject.GetComponent<PlayerUI>().Stamina = Stamina;
        gameObject.GetComponent<PlayerUI>().MaxStamina = MaxStamina;

        //Drawing RayCast so we can see groundcheck (Jump)
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 2, Color.red);

        //Stamina Depletion as well as Stamina Toggle for Sprinting and Jumping Higher/Faster
        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {
            StaminaToggle = true;
        }
        else
        {
            if (StaminaToggle)
            {
                //Use Coroutines here
            }
            StaminaToggle = false;
        }
        if(StaminaToggle)
        {
            maxSpeed = 20;
            Stamina -= 1;
            jumpForce = 20;
        }
        else
        {
            maxSpeed = 10;
            jumpForce = 10;
        }

        if(Stamina <= 0)
        {
            
        }


        //Movement Keys
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
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (grounded == true)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;

            grounded = false;
        }
        else
        {
            return;
        }


    }

    //private void RegainStamina()
    //{

    //    if(Stamina <= MaxStamina)
    //    {
    //        Stamina = Stamina * 1.2;
    //    }
    //}

}
