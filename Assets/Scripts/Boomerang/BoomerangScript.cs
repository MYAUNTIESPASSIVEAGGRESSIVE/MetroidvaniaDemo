using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    [Header("Object References")]
    public Rigidbody2D BoomMoveObj;
    public GameObject BoomerangStillObject;
    public Transform PlayerPos;

    [Header("Boomerang Variables")]
    public float BoomerangRotSpeed = 10f;
    public float BoomerangFlySpeed = 10f;
    public bool InFlight;
    public float BoomDistanceMax = 10f;
    private Vector2 Targetpos;
    private Vector3 direction;

    private void Start()
    {
        
    }

    void Update()
    {

        Vector3 AimPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = AimPoint - BoomerangStillObject.transform.position;

        float ObjRot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        BoomerangStillObject.transform.rotation = Quaternion.Euler(0, 0, ObjRot);

        if (Input.GetMouseButtonDown(0))
        {
            BoomFlight();
        }
    }

    void BoomFlight()
    {
        //Instantiate<
    }
}
