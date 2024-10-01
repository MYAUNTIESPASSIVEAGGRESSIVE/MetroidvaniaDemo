using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    [Header("Game Object References")]
    public LayerMask GroundLayer;
    private Rigidbody2D PlrRB;
    public Vector2 CheckSize;

    [Header("Movement Variables")]
    public float MoveSpeed = 20f;
    public float JumpHeight = 5f;
    private float HozPos;
    public float CastDistance = 1f;

    [Header("Jetpack Variables")]
    public bool JetpackFueled = false;
    public float FuelAmount = 0f;
    public float ReduceAmount = 5f;

    void Start()
    {
        PlrRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HozPos = Input.GetAxisRaw("Horizontal");

        CharacterMove();   
    }

    private void CharacterMove()
    {
        PlrRB.velocity = new Vector2(HozPos * MoveSpeed, PlrRB.velocity.y);

        // When jump button pressed + is grounded the player is able to jump
        if (Input.GetButton("Jump") && GroundChecker())
        {
            PlrRB.velocity = new Vector2(PlrRB.velocity.x, JumpHeight);
        }
        // when the player holds the jump button and the backpack is fueled then they fly
        else if (Input.GetButtonDown("Jump") && JetpackFueled)
        {
            PlrRB.AddForce(transform.up, ForceMode2D.Force);
            FuelAmount = FuelAmount - ReduceAmount;
            if (FuelAmount <= 0f)
            {
                JetpackFueled = false;
            }
        }
    }

    // checks player is on ground/platform
    public bool GroundChecker()
    {
        // if player is on ground layer then player can jump/ bool = true
         if (Physics2D.BoxCast(transform.position, CheckSize, 0, -transform.up, CastDistance, GroundLayer))
         {
             return true;
         }
         else return false;
    }

    // draws debug box for groundcheck
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * CastDistance, CheckSize);
        Gizmos.color = Color.green;
    }
}
