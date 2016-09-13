using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerControl : MonoBehaviour
{
    private Animator myanimator;
    public Collider2D mycollider;
    public LayerMask matchground;
    public bool ground;
    public float speed;
    public float MoveSpeed;
    public bool jump;
    public bool crouch;
    public bool walk;
    private Rigidbody2D rg;
    public float jumpNumber;
    public int direction;
    public float h;
    public bool hadooken;
    // Use this for initialization
    void Start()
    {
        myanimator = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        mycollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        playerMovement();

        //ground = Physics2D.IsTouchingLayers(mycollider, matchground);

        jump = Input.GetKeyDown(KeyCode.Space);

        if (ground == true) //if we're on the floor
        {
            if (jump)
            {
                rg.AddForce(Vector2.up * jumpNumber);

            }

        }




        hadooken = Input.GetKeyDown("g");


        myanimator.SetBool("hadooken", hadooken);
        myanimator.SetBool("jump", jump);
        myanimator.SetBool("ground", ground);
        myanimator.SetFloat("Speed", Mathf.Abs(h));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }

    public void playerMovement()
    {
        h = Input.GetAxis("Horizontal");


        if (h > 0)
        {


            if (direction == 1)
            {
                transform.Rotate(0, 180, 0);
            }
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            direction = -1;

        }

        if (h < 0)
        {
            if (direction == -1)
            {
                transform.Rotate(0, -180, 0);
            }
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            direction = 1;

        }








    }
}