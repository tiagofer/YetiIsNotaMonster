using UnityEngine;
using System.Collections;

public class Yeti : MonoBehaviour, IMovement
{
	
	public float finalVelocity;
	public float acceleration;
	public float velocity;
	private float _posX;

	//jump system
	private bool _isGrounded = false;
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

	public float jump;
	public Transform groundDetect;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public Animator animator;

	public GameObject player;
		
	void Start()
	{
		animator = gameObject.GetComponent<Animator>();
		//Physics.gravity = new Vector3(0,-40.0f,0);
		//jump = 10.0f;
	}
	
	void Update ()	
	{	

	}
	
	void FixedUpdate() 
	{
		IHorizontalMove();		
		IJump();
	}

	public void IHorizontalMove()
	{
		velocity += (acceleration * Time.deltaTime);
		velocity = Mathf.Clamp(velocity, 0f, finalVelocity);
		_posX = transform.position.x;

		if (ChangePlayer.ActiveYeti() || ChangePlayer.ActiveAll())
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
		print(isGrounded);
		animator.SetBool("isGrounded", isGrounded);
		if (ChangePlayer.ActiveYeti() || ChangePlayer.ActiveAll())
		{
			//_isGrounded = Physics.Linecast(transform.position, groundDetect.position, 1 << LayerMask.NameToLayer("Ground"));
			if (Input.GetButton("Jump") && isGrounded)
			{
				gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jump, ForceMode2D.Force);
				
			}
		}
	}
	
}
