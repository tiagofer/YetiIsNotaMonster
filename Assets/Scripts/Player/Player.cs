using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IMovement
{
	
	public float finalVelocity;
	public float acceleration;
	public float velocity;
	private float _posX;
	private bool _isGrounded;
	public bool isGrounded
	{ 	
		get
		{
			return _isGrounded;
		}
		set
		{
			_isGrounded = value;
		}
	}

	//jump system
	public float jump;
	public Animator animator;
	public Transform groundDetect;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public GameObject yeti;
	
	void Start()
	{
		animator = gameObject.GetComponent<Animator>();
		//Physics.gravity = new Vector3(0,-40.0f,0);
		//jump = 950.0f;
	}

	void FixedUpdate() 
	{
		IHorizontalMove();
		IJump();
	}
	
	
	public void IHorizontalMove()
	{
		//animator.SetFloat("velX", Mathf.Abs(Input.GetAxis("Horizontal"))); 
		velocity += (acceleration * Time.deltaTime);
		velocity = Mathf.Clamp(velocity, 0f, finalVelocity);
		_posX = transform.position.x;
	
		if ((ChangePlayer.ActivePlayer() || ChangePlayer.ActiveAll())) 
		{
			if (Input.GetAxis("Horizontal") > 0) 
			{
				_posX += (velocity * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,0);
				transform.position = new Vector2(_posX, transform.position.y);
			} else if (Input.GetAxis("Horizontal") < 0)
			{
				_posX -= (velocity * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,180);
				transform.position = new Vector2(_posX, transform.position.y);
			} else
			{
				_posX = 0;
				velocity = 0;
			}
			animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal"))); 
		} else 
		{
			animator.SetFloat("Speed", 0); 
		}
	}

	
	public void IJump()
	{
		isGrounded = Physics2D.OverlapCircle (groundDetect.position, groundRadius, whatIsGround);
		//print(isGrounded);
		animator.SetBool("isGrounded", isGrounded);
		if (ChangePlayer.ActivePlayer() || ChangePlayer.ActiveAll())
		{
			if (Input.GetButton("Jump") && isGrounded)
			{
				gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jump, ForceMode2D.Force);
			}
		}
	}


}

