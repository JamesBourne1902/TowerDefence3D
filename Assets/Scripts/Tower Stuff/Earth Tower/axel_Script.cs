using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axel_Script : MonoBehaviour
{
    public Tower_Stat_Script stats;
    public float rotationSpeed;
    Quaternion starting;

    private void Start()
    {
        stats = gameObject.GetComponentInParent<Tower_Stat_Script>();
        starting = transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(rotateForth());
        }
    }

    public IEnumerator rotateForth()
    {
        float elapsedTime = 0f;
        Quaternion starter = transform.localRotation;
        Quaternion target = Quaternion.Euler(0, 0, 90) * starter;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * (1/stats.shotDelay) * 2; // Adjust rotation speed based on 90 degrees
            transform.localRotation = Quaternion.Slerp(starter, target, elapsedTime);
            yield return null;
        }

        StartCoroutine(rotateBack());
    }
    public IEnumerator rotateBack()
    {
        float elapsedTime = 0f;
        Quaternion starter = transform.localRotation;
        Quaternion target = Quaternion.Euler(0, 0, -90) * starter;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * (1 / stats.shotDelay) * 2; // Adjust rotation speed based on 90 degrees
            transform.localRotation = Quaternion.Slerp(starter, target, elapsedTime);
            yield return null;
        }
    }

    public IEnumerator returnToOriginalPosition()
    {
        float elapsedTime = 0f;
        Quaternion target = transform.localRotation;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * (1 / stats.shotDelay) * 2; // Adjust rotation speed based on 90 degrees
            transform.localRotation = Quaternion.Slerp(target, starting, elapsedTime);
            yield return null;
        }
    }

    public void startPlaying()
    {
        StartCoroutine(rotateForth());
    }
}
