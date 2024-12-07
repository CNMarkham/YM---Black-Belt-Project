using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public GameObject player;
    public Transform orientation;

    public float sensX;
    public float sensY;


    float xRotation;
    float yRotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += MouseX;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
