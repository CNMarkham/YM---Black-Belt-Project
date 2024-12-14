using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    public GameObject player;
   
    public bool grounded;
    private float jumpForce;
    private Rigidbody rb;
    private RaycastHit hit;
    //private float maxSpeed;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10;
        jumpForce = 10;
        //grounded = true;

    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 2, Color.red);
        if (Input.GetKey(KeyCode.W))
        {

            player.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //rb.AddForce(Vector3.forward * speed);

            //if (rb.velocity.magnitude > maxSpeed)
            //{
            //    Vector3.ClampMagnitude(Vector3.forward, maxSpeed);
            //}

        }

        if (Input.GetKey(KeyCode.A))
        {

            player.transform.Translate(Vector3.left * speed * Time.deltaTime);

            //rb.AddForce(Vector3.left * speed * Time.deltaTime);


        }

        if (Input.GetKey(KeyCode.D))
        {

            player.transform.Translate(Vector3.right * speed * Time.deltaTime);

            //rb.AddForce(Vector3.right * speed * Time.deltaTime);


        }

        if (Input.GetKey(KeyCode.S))
        {

            player.transform.Translate(Vector3.back * speed * Time.deltaTime);

            //rb.AddForce(Vector3.back * speed * Time.deltaTime);



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
