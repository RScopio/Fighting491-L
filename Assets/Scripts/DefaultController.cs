using UnityEngine;
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


    Animator anim;
    Rigidbody2D body;

    float horiz;
    float vert;
    //max speed, jump duration?, attack rate?
    //Vector3 movement
    //bool for states

    public AudioClip attackSound;

    Direction direct = Direction.right;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            attack = true;
            SoundManager.instance.PlaySingle(attackSound);
        }
        else
        {
            attack = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            power = true;
        }
        else
        {
            power = false;
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horiz = 1;
            direct = Direction.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vert = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
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
        }


        if (!crouch && !anim.GetCurrentAnimatorStateInfo(0).IsName("punch"))
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
        anim.SetFloat("Speed", Mathf.Abs(horiz));
    }

    void Update()
    {
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
