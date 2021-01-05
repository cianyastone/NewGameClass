using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public int skillAmount=0;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;
    public Animator myAnim;
    private DrillAttack da;
    

    // private PlayerInputAction controls;
    // private Vector2 move;

    // void  Awake()
    // {
    //     controls = new PlayerInputAction();

    //     controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    //     controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;

    //     controls.GamePlay.Jump.started += ctx => Jump();
    // }

    // void OnEnable()
    // {
    //     controls.GamePlay.Enable();
    // }

    // void OnDisable()
    // {
    //     controls.GamePlay.Disable();
    // }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        da = GetComponent<DrillAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.isGameAlive = true)
        {
            Run();
            Flip();
            Jump();
            Attack();
            DrillAttack();
            status();
            checkGrounded(); 
            SwitchAnimation();
        }
    }

    void Flip()
    {
        bool playerHasAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(playerHasAxisSpeed)
        {
            if(myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if(myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void checkGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        // Debug.Log(isGround);
    }

    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        // Vector2 playerVel = new Vector2(move.x * runSpeed, myRigidbody.velocity.y); 
        // myRigidbody.velocity = playerVel;
        bool playerHasAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run" , playerHasAxisSpeed);
        myAnim.SetBool("drillrun" , playerHasAxisSpeed);
        Debug.Log(playerHasAxisSpeed);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(isGround)
            {
                myAnim.SetBool("Jump", true);
                myAnim.SetBool("Start", true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                     Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpSpeed);
                     myRigidbody.velocity = Vector2.up * doubleJumpVel;
                     canDoubleJump = false;
                }
            }
        }
    }

    void Attack()
    {
        if(Input.GetButtonDown("Attack"))
        {
            if(myAnim.GetBool("Drill") == false)
            {
                myAnim.SetTrigger("Attack");
            }
            
        }
    } 

    void DrillAttack()
    {
        if(Input.GetButtonDown("Attack"))
        {
            if(myAnim.GetBool("Drill"))
            {
                myAnim.SetBool("Drillattack", true);
                da.Attacked();
            }
            // if(myAnim.GetBool("Drillattack"))
            // {
            //     // myRigidbody.velocity = Vector2.right * 50;
            //     // WaitForSeconds(2);
            //     // myAnim.SetBool("Drillattack", false);
            // }
        }
    }

    void SwitchAnimation()
    {
        myAnim.SetBool("Idle", false);
        if(myAnim.GetBool("Jump"))
        {
            if(myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("Jump", false);
            }
        }
        else if(isGround)
        {
            myAnim.SetBool("Idle", true);
        }
    }
    void status()
    {
        if(Input.GetButtonDown("Skill"))
        {
            skillAmount ++;
            if(skillAmount > 1)
            {
                skillAmount = 0;
            }
        }
        if(skillAmount == 0)
        {
            myAnim.SetBool("Idle", true);
            myAnim.SetBool("Drill", false);
        }
        else if(skillAmount == 1)
        {
            myAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle");
            // myAnim.SetBool("Idle", false);
            myAnim.SetBool("Drill", true);
        }
    }

    public void DrillBack()
    {
        myAnim.SetBool("Drillattack", false);
    }
}

