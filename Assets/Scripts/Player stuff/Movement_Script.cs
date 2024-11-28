using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    public Object_Detection_Script detector;

    public Transform tran;
    public float movementScale;
    public Rigidbody rb;

    private void Start()
    {
        detector = gameObject.GetComponent<Object_Detection_Script>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && canLookAround())
        {
            Vector3 vector3 = generateForwardVector();
            tran.position += vector3 * movementScale;
        }

        else if (Input.GetKey(KeyCode.S) && canLookAround())
        {
            Vector3 vector3 = generateForwardVector();
            tran.position -= vector3 * movementScale;
        }

        if(Input.GetKey(KeyCode.D) && canLookAround())
        {
            Vector3 vector3 = generateSideVector();
            tran.position += vector3 * movementScale;
        }

        else if(Input.GetKey(KeyCode.A) && canLookAround())
        {
            Vector3 vector3 = generateSideVector();
            tran.position -= vector3 * movementScale;
        }
    }

    private bool canLookAround()
    {
        if (!detector.inBuyMenu && !Menu_Manager_Script.instance.inPauseMenu)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Outputs a vector that points in the forward direction of the camera
    Vector3 generateForwardVector()
    {
        Vector3 Forward = Camera.main.transform.forward;
        Forward.y = 0.0f; // prevents moving vertically;
        Forward.Normalize(); // ensures the forward vector has a magnitude of 1
        return Forward;
    }

    // Outputs a vector that points in the right direction from the camera
    Vector3 generateSideVector()
    {
        Vector3 Side = Camera.main.transform.right;
        Side.y = 0.0f;
        Side.Normalize();
        return Side;
    }

    // This prevents sliding
    private void FixedUpdate()
    {
        Vector3 speed = rb.velocity;
        speed.x = 0;
        speed.z = 0;

        rb.velocity = speed;
    }
}
