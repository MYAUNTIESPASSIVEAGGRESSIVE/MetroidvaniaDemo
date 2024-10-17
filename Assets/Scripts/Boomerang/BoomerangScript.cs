using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    [Header("Object References")]
    public Rigidbody2D BoomObject;
    public Transform PlayerPos;

    [Header("Boomerang Variables")]
    public float RotSpeed = 10f;
    public float FlySpeed = 10f;
    public float DelayTime = 3f;
    public bool InFlight;
    private Vector3 direction;
    private Vector3 aimPoint;
    private Vector3 targetPoint;
    private bool returning;
    private bool canFire;
    private float ObjRot;

    private void Start()
    {
        InFlight = false;
        returning = false;
        canFire = true;
    }

    // handles the boomerang pointing and shooting initation
    void Update()
    {
        if (!InFlight)
        {
            // aimpoint follows mouse on screen
            aimPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // direction is the position of the boomerang compared to the aimpoint
            direction = aimPoint - BoomObject.transform.position;
            // checks what rotation should the boomerang be
            ObjRot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // faces the boomerang in the direction of the mouse
            BoomObject.transform.rotation = Quaternion.Euler(0, 0, ObjRot);
        }

        // if the player presses left mouse and the boomerang is in hand and the timer is done
        if (Input.GetMouseButtonDown(0) && !InFlight && canFire)
        {
            // flight boolean is now true and the player cannot fire + calls the throwing function
            InFlight = true;
            canFire = false;
            ThrowBoomerang();
        }
    }

    void ThrowBoomerang()
    {
        // the target of the boomerang is what the aimpoint was on click
        targetPoint = aimPoint;
        // starts the coroutine
        StartCoroutine(BoomFlight());
    }

    // coroutine creates a while loop checking where the position of the boomerang is compared to the player and the target point
    private IEnumerator BoomFlight()
    {
        // checks the distance between the boomerang and the target point
        while (Vector2.Distance(BoomObject.position, targetPoint) > 0.05f)
        {
            // moves the boomerang towards the target point
            BoomObject.position = Vector2.MoveTowards(BoomObject.position, targetPoint, FlySpeed * Time.deltaTime);

            // if the boomerang reaches the target point then it can now return to the player
            if (Vector2.Distance(BoomObject.position, targetPoint) < 0.05f)
            {
                returning = true;
                yield return null;
            }

            yield return null;
        }
        // checks the distance between player and boomerang and that it is able to return
        while (Vector2.Distance(BoomObject.position, PlayerPos.position) > 0.05f && returning)
        {
            // moves the boomerang to the player
            BoomObject.position = Vector2.MoveTowards(BoomObject.position, PlayerPos.position, FlySpeed * Time.deltaTime);
            // if the player and boomerang are in the same position
            if (Vector2.Distance(BoomObject.position, PlayerPos.position) < 0.05f)
            {
                // the boomerang is now back in the players hand;
                InFlight = false;
                // makes sure the boomerang returns and is facing the right way (the aimpoint)
                BoomObject.transform.rotation = Quaternion.Euler(0, 0, ObjRot);
                // starts the cooldown timer
                StartCoroutine(Timer());
                yield return null;
            }
            yield return null;
        }
    }

    private IEnumerator Timer()
    {
        new WaitForSecondsRealtime(DelayTime);
        // when the timer is over the player can now fire again
        canFire = true;
        yield return null;
    }
}
