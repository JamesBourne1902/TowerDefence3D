using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_Script : MonoBehaviour
{
    public Transform parent;
    public float targetScale = 2f; // The target scale of the GameObject
    public float duration = 2f; // The duration over which the scaling should occur

    void Start()
    {
        // Start the scaling coroutine
        StartCoroutine(ScaleOverTime(targetScale, duration));
    }

    IEnumerator ScaleOverTime(float targetScale, float duration)
    {
        Vector3 originalScale = parent.localScale; // Store the original scale
        float timer = 0f;

        // Scale up smoothly over the specified duration
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration); // Calculate the interpolation parameter
            parent.localScale = Vector3.Lerp(originalScale, Vector3.one * targetScale, t); // Interpolate the scale
            
            yield return null;
        }

        // Ensure the scale reaches the target exactly
        transform.localScale = Vector3.one * targetScale;
        Destroy(parent.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<Stats_Script>().takeDamage(10);
            other.gameObject.GetComponent<Stats_Script>().startBurning();
        }
    }
}
