using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.2f;

    private Vector3 originalPosition;

    public void StartShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        originalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }
}
