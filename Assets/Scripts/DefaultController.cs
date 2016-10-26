using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class DefaultController : MonoBehaviour
{
    /// <summary>
    /// Notes:
    /// -Input Manager
    /// -int PlayerNumber
    /// -Transform Enemy
    /// -Health Script
    /// -bool for each animation state
    /// 
    /// start, update, fixed update, ongroundcheck, updateanimator, oncollision enter& exit
    /// 
    /// possible switch to brawler style
    /// move, jump, crouch
    /// Mid Attack, Mid Power Attack (Power is slower but does more damage and is longer range)
    /// Low Attack, Low Power Attack
    /// Air Attack, Air Power Attack
    /// Block (Blocks mid & high), Low Block (blocks low & mid)
    /// Grab
    /// Special Attack
    /// 
    /// Transition from attack <-> power needs fixing
    /// </summary>

    private enum Direction
    {
        left,
        right
    };

    public float Speed = 1;
    public float JumpForce = 3;
    bool crouch = false;
    bool onGround = false;
    bool attack = false;
    bool power = false;
    bool block = false;


    Animator anim;
    Rigidbody2D body;

    float horiz;
    float vert;
    //max speed, jump duration?, attack rate?
    //Vector3 movement
    //bool for states

    //controller input
    float xbox_hAxis;
    float xbox_vAxis;
    //float xbox_aAxis;
    float xbox_htAxis;
    float xbox_vtAxis;

    float xbox_ltaxis;
    float xbox_rtaxis;
    float xbox_dhaxis;
    float xbox_dvaxis;

    bool xbox_a;
    bool xbox_b;
    bool xbox_x;
    bool xbox_y;
    bool xbox_lb;
    bool xbox_rb;
    bool xbox_ls;
    bool xbox_rs;
    bool xbox_back;
    bool xbox_start;

    Text DebugText;

    public AudioClip attackSound;
    //public AudioClip kickSound;
    public AudioClip jumpSound;
    Direction direct = Direction.right;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        DebugText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<Text>();
    }

    void ReadInput()
    {
        xbox_hAxis = Input.GetAxis("Horizontal");
        xbox_vAxis = Input.GetAxis("Vertical");
        //xbox_aAxis = Input.GetAxis("Altitude");
        xbox_htAxis = Input.GetAxis("HorizontalTurn");
        xbox_vtAxis = Input.GetAxis("VerticalTurn");

        xbox_ltaxis = Input.GetAxis("XboxLeftTrigger");
        xbox_rtaxis = Input.GetAxis("XboxRightTrigger");
        xbox_dhaxis = Input.GetAxis("XboxDpadHorizontal"); //not working
        xbox_dvaxis = Input.GetAxis("XboxDpadVertical"); //not working

        xbox_a = Input.GetButton("XboxA");
        xbox_b = Input.GetButton("XboxB");
        xbox_x = Input.GetButton("XboxX");
        xbox_y = Input.GetButton("XboxY");
        xbox_lb = Input.GetButton("XboxLB");
        xbox_rb = Input.GetButton("XboxRB");
        xbox_ls = Input.GetButton("XboxLS");
        xbox_rs = Input.GetButton("XboxRS");
        xbox_back = Input.GetButton("XboxBack");
        xbox_start = Input.GetButton("XboxStart");

        DebugText.text =
        string.Format(
            "Horizontal: {14:0.000} Vertical: {15:0.000}\n" +
            "HorizontalTurn: {16:0.000} VerticalTurn: {17:0.000}\n" +
            "LTrigger: {0:0.000} RTrigger: {1:0.000}\n" +
            "A: {2} B: {3} X: {4} Y:{5}\n" +
            "LB: {6} RB: {7} LS: {8} RS:{9}\n" +
            "View: {10} Menu: {11}\n" +
            "Dpad-H: {12:0.000} Dpad-V: {13:0.000}\n",
            xbox_ltaxis, xbox_rtaxis,
            xbox_a, xbox_b, xbox_x, xbox_y,
            xbox_lb, xbox_rb, xbox_ls, xbox_rs,
            xbox_back, xbox_start,
            xbox_dhaxis, xbox_dvaxis,
            xbox_hAxis, xbox_vAxis,
            xbox_htAxis, xbox_vtAxis);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z) || xbox_x)
        {
            attack = true;
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlaySingle(attackSound);
            }
        }
        else
        {
            attack = false;
        }

        if (Input.GetKeyDown(KeyCode.X) || xbox_y)
        {
            power = true;
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlaySingle(attackSound);
            }
        }
        else
        {
            power = false;
        }

        if (Input.GetKey(KeyCode.C) || xbox_rb)
        {
            block = true;
        }
        else
        {
            block = false;
        }
    }

    void UpdateDirection()
    {
        //if enemy pos < pos::localScale = -1,1,1 else 1,1,1(flip using scale)
        if (direct == Direction.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direct == Direction.right)
        {
            transform.localScale = Vector2.one;
        }
    }

    void OnGroundCheck()
    {

    }

    void Movement()
    {
        #region Horizontal Input
        if (Input.GetKey(KeyCode.RightArrow) || xbox_hAxis > 0)
        {
            horiz = 1;
            direct = Direction.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || xbox_hAxis < 0)
        {
            horiz = -1;
            direct = Direction.left;
        }
        else
        {
            horiz = 0;
        }
        #endregion

        #region Vertical Input
        if (Input.GetKey(KeyCode.UpArrow) || xbox_a || xbox_vAxis > 0)
        {
            vert = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || xbox_vAxis < 0)
        {
            vert = -1;
        }
        else
        {
            vert = 0;
        }
        #endregion

        if (vert < 0 && onGround)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }

        if (vert > 0 && onGround)
        {
            body.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            if (SoundManager.instance != null)
            {
                SoundManager.instance.PlaySingle(jumpSound);
            }
        }


        if (!crouch && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("block"))
        {
            if (horiz != 0)
            {
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
            }
        }
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void UpdateAnimator()
    {
        anim.SetBool("Crouch", crouch);
        anim.SetBool("Ground", onGround);
        anim.SetBool("Attack", attack);
        anim.SetBool("Power", power);
        anim.SetBool("Block", block);
        anim.SetFloat("Speed", Mathf.Abs(horiz));
    }

    void Update()
    {
        ReadInput();
        Attack();
        UpdateDirection();
        OnGroundCheck();
        Movement();
        UpdateAnimator();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
