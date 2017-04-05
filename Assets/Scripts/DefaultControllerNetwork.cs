using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D), typeof(InputController), typeof(SoundController))]
public class DefaultControllerNetwork : NetworkBehaviour
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


    public Animator anim;

    public Rigidbody2D body;

    //max speed, jump duration?, attack rate?
    //Vector3 movement
    //bool for states

	public InputController input;
    public SoundController sound;

	[SyncVar(hook = "OnChangedDirection")]
	public Direction direct;//; = Direction.right;
	NetworkIdentity playerNetworkID;
    void Start()
    {
		if (!isLocalPlayer) {
			return;
		}

		if (isServer) {
			playerNetworkID = gameObject.GetComponent<NetworkIdentity> ();
			playerNetworkID.AssignClientAuthority (connectionToClient);
		}
        //body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //input = GetComponent<InputController>();
        //sound = GetComponent<SoundController>();

    }

	void AttackSounds()
		{
//			if (input.Attack) {
//				sound.Attack ();
//			}
//
//			if (input.Power) {
//				sound.Power ();
//			}
		}

	void OrientDirection()
    {
		if (direct == Direction.left)
		{
			this.transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (direct == Direction.right)
		{
			this.transform.localScale = Vector3.one;
		}
    }



	void OnChangedDirection(Direction direction){
		direct = direction;
		OrientDirection ();
	}

	[Command]
	public void CmdFlipSprite(Direction direction){
	
		//Debug.Log ("direction sent to server is " + direct);
		if (direction == Direction.left)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (direction == Direction.right)
		{
			transform.localScale = Vector3.one;
		}

	}


	[ClientRpc]
	void RpcFlipSprite(Direction direction)
	{


		//if enemy pos < pos::localScale = -1,1,1 else 1,1,1(flip using scale)
		if (direction == Direction.left)
		{
			this.transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (direction == Direction.right)
		{
			this.transform.localScale = Vector3.one;
		}
	}

    void Movement()
    {
        if (input.Horizontal == 1)
        {
            direct = Direction.right;
	
//			if (isServer) {
//				RpcFlipSprite (direct);
//
//			} else {
			if(isLocalPlayer)
				CmdFlipSprite (direct);
//				Debug.Log ("right");
//			}
				
        }
        if (input.Horizontal == -1)
        {
			
            direct = Direction.left;
			if(isLocalPlayer)
				CmdFlipSprite (direct);
//			if (isServer) {
//				Debug.Log ("this should not be called on client");
//				RpcFlipSprite (direct);
//			} else {
//				Debug.Log ("left");
		
				
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
            //sound.Jump();
        }


        if (!crouch && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("block"))
        {
            if (input.Horizontal != 0)
            {
                transform.Translate(Vector2.right * input.Horizontal * Speed * Time.deltaTime);
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
		if (!isLocalPlayer)
			return;
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
