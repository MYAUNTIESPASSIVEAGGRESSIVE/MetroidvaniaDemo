using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Start and End Positions")]
    public Transform[] PlatformPoints;
    private Transform targetpos;
    private int currentpos = 0;

    [Header("Platform Variables")]
    public float MoveSpeed;
    public float MoveDelay;

    // sets the target position to the first platform point
    private void Start()
    {
        targetpos = PlatformPoints[0];
    }

    private void Update()
    {
        PlatformMovement();
    }

    // potential timer for platforms
    IEnumerator PauseTime()
    {
        yield return new WaitForSecondsRealtime(MoveDelay);
    }

    // how the platforms move
    void PlatformMovement()
    {
        // platform moves towards the target position at the movement speed
        transform.position = Vector2.MoveTowards(transform.position, targetpos.position, MoveSpeed * Time.deltaTime);

        // if its close to the target platform then it will change tagrte position
        if (Vector2.Distance(transform.position, targetpos.position) < 0.02f)
        {
            //StartCoroutine(PauseTime());

            // target changes to next position
            targetpos = NextPlace();
        }
    }

    // position point changer
    Transform NextPlace()
    {
        // increases position point
        currentpos++;

        // if the current pos is now longer than the amount of elements in the array it resets to 0
        if (currentpos >= PlatformPoints.Length)
        {
            currentpos = 0;
        }

        return PlatformPoints[currentpos];
    }

    // on collision enter the player becomes a child of the platform
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    // when the player leaves the collider then it gets unparented
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
