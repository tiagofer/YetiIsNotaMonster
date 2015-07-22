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
			return _isActive;
		}
		set
		{
			_isActive = value;
		}
	}


	public float jump;
	public Animator animator;
	public Transform groundDetect;
	public GameObject yeti;

	private bool _isActive;
	public bool isActive 
	{ 	
		get
		{
			return _isActive;
		}
		set
		{
			_isActive = value;
		}
	}
	

	void Start()
	{
		animator = gameObject.GetComponent<Animator>();
		Physics.gravity = new Vector3(0,-40.0f,0);
		jump = 950.0f;
		_isActive = false;
	}
	// Update is called once per frame
	void Update ()
	{

		IHorizontalMove();

	}

	void FixedUpdate() 
	{
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
		isGrounded = Physics.Linecast(transform.position, groundDetect.position, 1 << LayerMask.NameToLayer("Ground"));
		print(isGrounded);
		animator.SetBool("isGrounded", isGrounded);
		if (ChangePlayer.ActivePlayer() || ChangePlayer.ActiveAll())
		{
			if (Input.GetButton("Jump") && isGrounded)
			{
				gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jump, ForceMode.Force);

			}
		}
	}

//	public bool IActivePlayer () 
//	{
//		if (Input.GetKey (KeyCode.C)) 
//		{
//			isActive = true;
//			yeti.GetComponent<Yeti>().isActive = false;
//		}
//		return isActive;
//	}

}

