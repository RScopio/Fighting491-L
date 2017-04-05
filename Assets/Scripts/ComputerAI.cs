using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(InputController), typeof(SoundController))]
public class ComputerAI : MonoBehaviour
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

	public Transform Computer;
	public Transform Player;
	public float Speed = 1;
	public float JumpForce = 3;
	bool crouch = false;
	bool onGround = false;
	[HideInInspector]
	public bool Damaged = false;
	[HideInInspector]
	public bool Nullify = false;
	private float Distance;
	float attackTimer;
	float attackCooldown = 3.0f;

	Animator anim;
	Rigidbody2D body;
	//max speed, jump duration?, attack rate?
	//Vector3 movement
	//bool for states

	InputController input;
	SoundController sound;


	public Direction direct = Direction.left;

	void Start()
	{
		Computer = transform;
		Player = GameObject.FindGameObjectWithTag ("Player").transform;

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
		Distance = Mathf.Abs(Vector3.Distance(Player.position, Computer.position));

		if (Computer.position.x > Player.position.x && Distance > 4.3) {
			input.Horizontal = -1;
			direct = Direction.left;
//		} else if (Computer.position.x > Player.position.x && Distance < 3.8) {
//			input.Horizontal = 1;
//			direct = Direction.right;
		} else if (Computer.position.x < Player.position.x && Distance > 4.3) {
			input.Horizontal = 1;
			direct = Direction.right;
//		} else if (Computer.position.x < Player.position.x && Distance < 3.8) {
//			input.Horizontal = -1;
//			direct = Direction.left;
		}

		int JumpChance = Random.Range (1, 100);

		if (Player.position.y > 1.5) {
			if (JumpChance < 20) {
				Debug.Log("Jumping");
				input.Vertical = 1;
				if (input.Vertical > 0 && onGround)
				{
					Vector2 velocity = body.velocity;
					velocity.y = Mathf.Sqrt(2f * JumpForce * -Physics2D.gravity.y);
					body.velocity = velocity;
					sound.Jump();
				}

				input.Vertical = 0;
			}
		}

		if (!crouch && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("block"))
		{
			if (input.Horizontal != 0)
			{
				Computer.Translate(Vector2.right * input.Horizontal * Speed * Time.deltaTime);
			}
		}
			
		Computer.rotation = Quaternion.Euler(Vector3.zero);
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
			
		if (collision.gameObject.tag == "Player" && input.Attack == false && input.Power == false) {
            Debug.Log("Attacking!");
			int attackChance = Random.Range (1, 100);
			if (attackChance <= 100) {
				int attackSelection = Random.Range (1, 100);
				if (attackSelection < 40) {
					input.Attack = true;
				} else {
					input.Power = true;
				}
				attackTimer = attackCooldown;
			}
				
//			if (attackChance > 50) {
//				Debug.Log ("Blocking");
//				input.Horizontal = 0;
//				input.Attack = false;
//				input.Power = false;
//
//				input.Block = true;
//				Nullify = true;
//				StartWait();
//				input.Block = false;
//				Nullify = false;
//			}
		}

		StartCoroutine(AttackCheck());
	}

	public void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			onGround = false;
		}
	}

	IEnumerator AttackCheck() {
		while (true) {
			if (input.Attack || input.Power) {
				if (attackTimer > 1.0f) {
					Debug.Log ("Decreasing");
					attackTimer -= 1.0f;
				}

				if (attackTimer <= 1.0f) {
					input.Attack = false;
					input.Power = false;
					Debug.Log ("Done attacking!");
				} 
			}
			yield return new WaitForSeconds (1);
		}
	}

	IEnumerator StartWait()
	{
		yield return StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (2);   
	}
}