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
    private float VertPos;
    private bool Interacted;
    public float CastDistance = 1f;
    public bool OnLadder = false;
    public float ClimbSpeed = 2f;

    [Header("Jetpack Variables")]
    public bool JetpackFueled = false;
    public float FuelAmount = 0f;
    public float ReduceAmount = 5f;
    public float FlightSpeed = 5f;

    void Start()
    {
        PlrRB = GetComponent<Rigidbody2D>();
        OnLadder = false;
    }

    void Update()
    {
        HozPos = Input.GetAxisRaw("Horizontal");
        VertPos = Input.GetAxisRaw("Vertical");
        Interacted = Input.GetKeyDown(KeyCode.E);


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

        if (!OnLadder) 
        {
            // when the player holds the jump button and the backpack is fueled then they fly
            if (Input.GetButton("Jump") && Input.GetKey(KeyCode.LeftShift) && JetpackFueled)
            {
                PlrRB.AddForce(transform.up * FlightSpeed, ForceMode2D.Force);

                // fuel reduces while in flight
                FuelAmount = FuelAmount - ReduceAmount;

                // if the fuel ammount is 0 then the player cannot keep flying and falls
                if (FuelAmount <= 0f)
                {
                    JetpackFueled = false;
                }
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

    private void OnTriggerStay2D(Collider2D ladder)
    {
        if (ladder.gameObject.CompareTag("Ladder") && Interacted)
        {
            LadderMovement();
        }
    }



    public void LadderMovement()
    {
        PlrRB.velocity = new Vector2(PlrRB.velocity.x, VertPos * ClimbSpeed);
    }
}
