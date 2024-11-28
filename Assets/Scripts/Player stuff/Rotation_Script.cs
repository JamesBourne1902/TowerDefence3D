using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Script : MonoBehaviour
{
    public Object_Detection_Script detector;

    public float sensitivity = 2.0f;
    public Transform playerBody;

    private float verticalRotation = 0.0f;
    private float horizontalRotation = 0.0f;

    private void Start()
    {
        detector = gameObject.GetComponentInParent<Object_Detection_Script>();
    }

    // makes the player rotate as the mouse moves
    void Update()
    {
        if (!detector.inBuyMenu && !Menu_Manager_Script.instance.inPauseMenu)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            verticalRotation -= mouseY;
            horizontalRotation += mouseX;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // sets the upper and lower limit

        }
        playerBody.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }
}
