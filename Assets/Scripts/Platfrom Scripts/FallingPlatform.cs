using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [Header("Game Object References")]
    public Rigidbody2D FallPlatform;

    [Header("MovementVariables")]
    public float DelayTime = 2f;

    private void Start()
    {
        FallPlatform.simulated = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallDelay());
        }
    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSecondsRealtime(DelayTime);
        FallPlatform.simulated = true;
    }
}
