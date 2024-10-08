using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D Boomerang;

    [Header("Boomerang Stats")]
    public float BoomSpeed = 10f;
    private bool inflight = false;
    public float ThrowCooldown = 2;

    void Start()
    {
        // flight boolean checking if the boomerang is flying or not.
        inflight = false;
    }

    void Update()
    {

        if (!inflight)
        {
            BoomPoint();
        }

        if (Input.GetMouseButtonDown(0) && !inflight)
        {
            inflight = true;
            ShootBoom();
        }
    }

    private void BoomPoint()
    {
        // creates a V3 using the mouse position.
        Vector3 MPos = Input.mousePosition;

        // makes the MPos V3 relate to the current mouse position on the screen.
        MPos = Camera.main.ScreenToWorldPoint(MPos);

        // creates a V2 that is the distance between the spin position of the boomerang and the current mouse pos.
        Vector2 PointTo = new Vector2(MPos.x - transform.position.x, MPos.y - transform.position.y);

        // points the object upward towards this position.
        transform.up = PointTo;
    }

    void ShootBoom()
    {
        Vector3 ShootPos = Input.mousePosition;
        ShootPos = Camera.main.ScreenToWorldPoint(ShootPos);

        //Boomerang.transform.position = Vector2.MoveTowards(Boomerang.transform.position, , BoomSpeed * Time.deltaTime);
    }

}
