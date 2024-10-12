using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangInFlight : MonoBehaviour
{
    public BoomerangScript BoomScript;
    private Rigidbody2D BoomMove;
    public float BoomerangFlySpeed = 10f;
    public Transform PlayerPos;
    private bool Returning;

    void Start()
    {
        BoomMove = GetComponent<Rigidbody2D>();

        Vector3 Mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 ShootDir = Mpos - transform.position;

        BoomMove.velocity = new Vector2(ShootDir.x, ShootDir.y).normalized * BoomerangFlySpeed;

        if (Vector3.Distance(BoomMove.position, ShootDir) < 0.05f)
        {
            Debug.Log("Returning");
            BoomMove.velocity = new Vector2(-ShootDir.x, -ShootDir.y).normalized * BoomerangFlySpeed;
            Returning = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Returning)
        {
            Destroy(gameObject);
            BoomScript.InFlight = false;
        }
    }
}
