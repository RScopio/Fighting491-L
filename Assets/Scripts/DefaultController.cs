using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(InputController), typeof(SoundController))]
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

    public enum Direction
    {
        left,
        right
    };

    public float Speed = 1;
    public float JumpForce = 3;
    bool crouch = false;
    bool onGround = false;
    [HideInInspector]
    public bool Damaged = false;
    [HideInInspector]
    public bool Nullify = false;


    Animator anim;
    Rigidbody2D body;
    //max speed, jump duration?, attack rate?
    //Vector3 movement
    //bool for states

    InputController input;
    SoundController sound;


    public Direction direct = Direction.right;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        input = GetComponent<InputController>();
        sound = GetComponent<SoundController>();
    }

    void AttackSounds()
    {
        if (input.Attack)
        {
            sound.Attack();
        }

        if (input.Power)
        {
            sound.Power();
        }
    }

    void OrientDirection()
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

    void Movement()
    {
        if (input.Horizontal == 1)
        {
            direct = Direction.right;
        }
        if (input.Horizontal == -1)
        {
            direct = Direction.left;
        }

        if (input.Vertical < 0 && onGround)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }

        if (input.Vertical > 0 && onGround)
        {
            Vector2 velocity = body.velocity;
            velocity.y = Mathf.Sqrt(2f * JumpForce * -Physics2D.gravity.y);
            body.velocity = velocity;
            sound.Jump();
        }


        if (!crouch && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("block"))
        {
            if (input.Horizontal != 0)
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
        anim.SetBool("Attack", input.Attack);
        anim.SetBool("Power", input.Power);
        anim.SetBool("Block", input.Block);
        anim.SetBool("Damage", Damaged);
        anim.SetFloat("Speed", Mathf.Abs(input.Horizontal));
    }

    void Update()
    {
        AttackSounds();
        OrientDirection();
        //OnGroundCheck();
        Movement();
        UpdateAnimator();

        Damaged = false;
        if (input.Block == false)
        {
            Nullify = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            body.velocity = Vector2.zero;
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
