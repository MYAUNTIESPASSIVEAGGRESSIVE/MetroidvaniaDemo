using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [Header("Game Object References")]
    public Transform InitalPosition;
    public Rigidbody2D FallPlatform;

    [Header("MovementVariables")]
    public float DelayTime = 2f;
    public float RespawnTime = 3f;

    private void Start()
    {
        InitalPosition.position = transform.position;
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
        FallPlatform.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSecondsRealtime(RespawnTime);
        PlatReturn();
    }

    void PlatReturn()
    {
        FallPlatform.bodyType = RigidbodyType2D.Static;
        transform.position = InitalPosition.position;
    }
}
