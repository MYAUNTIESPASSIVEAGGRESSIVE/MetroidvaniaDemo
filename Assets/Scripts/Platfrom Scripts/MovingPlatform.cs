using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Start and End Positions")]
    public Vector2 StartPos;
    public Vector2 EndPos;

    [Header("Platform Variables")]
    public float MoveSpeed;
    public float MoveDelay;

    void Start()
    {
        transform.position = StartPos;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, EndPos, MoveSpeed * Time.deltaTime);

        if (transform.position == EndPos)
        {

        }
    }
}
