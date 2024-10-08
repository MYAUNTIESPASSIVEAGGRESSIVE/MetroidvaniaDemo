using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [Header("Game Object References")]
    public Rigidbody2D FallPlatform;

    [Header("MovementVariables")]
    public float FallSpeed = 2f;
    public float DelayTime = 2f;
    public float DestroyTime = 3f;

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallDelay());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(FallDelay());
        }
    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSecondsRealtime(DelayTime);
        FallPlatform.constraints = RigidbodyConstraints2D.None;
        FallPlatform.velocity = new Vector2(FallPlatform.velocity.x, FallSpeed);
        yield return new WaitForSecondsRealtime(DestroyTime);
        gameObject.SetActive(false);
    }
}
