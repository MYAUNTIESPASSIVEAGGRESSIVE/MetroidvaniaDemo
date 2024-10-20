using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    
    [Header("Game Object References")]
    public LayerMask GroundLayer;
    private Rigidbody2D PlrRB;
    public Animator PlrAnim;
    public SpriteRenderer PlrSprite;
    public Sprite JumpSprite;
    public Vector2 CheckSize;
    public Canvas PauseMenu;
    public SceneManagers SceneManagersScript;
    public GameManager GameManagerScript;
    public GameObject Boomerang;
    public Slider JPSlider;

    [Header("Movement Variables")]
    public float MoveSpeed = 20f;
    public float JumpHeight = 5f;
    private float HozPos;
    private float VertPos;
    public float CastDistance = 1f;
    public bool OnLadder = false;
    public float ClimbSpeed = 2f;
    private bool canMove = true;

    [Header("Jetpack Variables")]
    public bool JetpackFueled = false;
    public float FuelAmount = 0f;
    public float FuelMaximum = 100f;
    public float ReduceAmount = 5f;
    public float FlightSpeed = 5f;

    void Start()
    {
        PlrRB = GetComponent<Rigidbody2D>();
        PlrAnim = GetComponent<Animator>();
        OnLadder = false;

        JPSlider.maxValue = FuelMaximum;
        JPSlider.value = FuelAmount;
    }

    void Update()
    {
        HozPos = Input.GetAxisRaw("Horizontal");
        VertPos = Input.GetAxisRaw("Vertical");
        PlrAnim.SetFloat("Speed", Mathf.Abs(HozPos));

        if (canMove)
        {
            CharacterMove();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausedGame();
        }

        if (FuelAmount >= 0.01)
        {
            JetpackFueled = true;
        }
    }

    private void CharacterMove()
    {
        PlrRB.velocity = new Vector2(HozPos * MoveSpeed, PlrRB.velocity.y);

        PlrSprite.flipX = (HozPos < 0.0f) ? true : false;

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

                PlrAnim.SetBool("IsFlying", true);
                // fuel reduces while in flight

                FuelAmount = FuelAmount - ReduceAmount;

                JPSlider.value = FuelAmount;

                // if the fuel ammount is 0 then the player cannot keep flying and falls
                if (FuelAmount <= 0f)
                {
                    JetpackFueled = false;
                    PlrAnim.SetBool("IsFlying", false);
                }
            }
            else
            {
                PlrAnim.SetBool("IsFlying", false);
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
        if (ladder.gameObject.CompareTag("Ladder"))
        {
            PlrRB.gravityScale = 0.01f;
            OnLadder = true;
            PlrRB.velocity = new Vector2(PlrRB.velocity.x, VertPos * ClimbSpeed);
            PlrAnim.SetBool("IsClimbing", true);
        }
    }

    private void OnTriggerExit2D(Collider2D ladder)
    {
        if (ladder.gameObject.CompareTag("Ladder"))
        {
            PlrAnim.SetBool("IsClimbing", false);
            PlrRB.gravityScale = 1;
            OnLadder = false;
        }
    }

    private void PausedGame()
    {
        PauseMenu.gameObject.SetActive(true);
        Boomerang.SetActive(false);
        canMove = false;
    }

    public void UnPause()
    {
        PauseMenu.gameObject.SetActive(false);
        Boomerang.SetActive(true);
        canMove = true;
    }

    public void AddFuel()
    {
        FuelAmount = FuelAmount + FuelMaximum;
        JPSlider.value = FuelAmount;
    }
}
