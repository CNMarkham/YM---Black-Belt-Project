using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    public GameObject player;
   
    public bool isJumping;
    private float jumpForce;
    private Rigidbody rb;
    private RaycastHit hit;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10;
        jumpForce = 10;

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {

            player.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.A))
        {

            player.transform.Translate(Vector3.left * speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {

            player.transform.Translate(Vector3.right * speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {

            player.transform.Translate(Vector3.back * speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(!isJumping)
            {
                Vector3 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;

                isJumping = true;
            }
            else
            {
                return;
            }
        }


    }
        
    //private void Jump()
    //{
    //    Physics.Raycast(player.transform.position, transform.TransformDirection(Vector3.down), out hit, 100f, LayerMask.GetMask("Terrain"));


    //    if (hit.collider) 
    //    {
    //        isJumping = false;
    //    }
    //}

    private bool GroundCheck()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit, 10f, LayerMask.GetMask("Terrain"));

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 10, Color.red);


        if (hit.collider)
        {
            isJumping = false;
        }
    }

}
