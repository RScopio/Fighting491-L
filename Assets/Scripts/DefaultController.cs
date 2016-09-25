using UnityEngine;
using System.Collections;

/// <summary>
/// Todo:
/// -when holding left/right then down, crouch activates but stays walking animation
/// </summary>

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class DefaultController : MonoBehaviour
{
    private enum AnimState
    {
        idle,
        walk,
        crouch,
        punch,
        kick,
        block
    };

    public float Speed = 1;
    bool crouch = false;
    bool ground = false;
    float horiz = 0;
    float vert = 0;

    Animator anim;
    SpriteRenderer render;
    Rigidbody2D body;
    AnimState state = AnimState.idle;

    void Start()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horiz = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horiz = -1;
        }
        else
        {
            horiz = 0;
        }

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


        if (vert < 0 && ground)
        {
            crouch = true;
            anim.SetBool("Crouch", true);
        }
        else
        {
            crouch = false;
        }

        if (vert > 0 && ground)
        {
            //jump
            //ground = false;
        }

        if (horiz > 0)
        {
            if (!crouch)
            {
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
            }
            render.flipX = false;
        }

        if (horiz < 0)
        {
            if (!crouch)
            {
                transform.Translate(Vector2.left * Speed * Time.deltaTime);
            }
            render.flipX = true;
        }




    }

    void Attack()
    {
        
    }

    void Update()
    {
        Attack();
        Movement();
        //check other actions

        anim.SetBool("Crouch", crouch);
        anim.SetBool("Ground", ground);
        anim.SetFloat("Speed", Mathf.Abs(horiz));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }
}
