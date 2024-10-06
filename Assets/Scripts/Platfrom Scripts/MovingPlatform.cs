using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Start and End Positions")]
    public Transform[] positions;
    private Transform targetpos;
    private int currentpos;

    [Header("Platform Variables")]
    public float MoveSpeed;
    public float MoveDelay;

    private void Start()
    {
        targetpos = positions[0];
    }

    private void Update()
    {
        PlatformMovement();
    }

    IEnumerator PauseTime()
    {
        yield return new WaitForSecondsRealtime(MoveDelay);
    }

    void PlatformMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetpos.position, MoveSpeed * Time.deltaTime);


    }
}
