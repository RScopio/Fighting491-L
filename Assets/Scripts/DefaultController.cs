using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class DefaultController : MonoBehaviour
{
    private enum AnimState
    {
        idle,
        walk
    };

    public float Speed = 1;

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
        float horiz = Input.GetAxis("Horizontal");
        if (horiz > 0)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            render.flipX = false;
        }

        if (horiz < 0)
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            render.flipX = true;
        }

        anim.SetFloat("Speed", Mathf.Abs(horiz));
    }

    void Update()
    {
        Movement();
        //check other actions
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("Ground", true);
        }
    }
}
