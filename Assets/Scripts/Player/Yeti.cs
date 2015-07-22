using UnityEngine;
using System.Collections;

public class Yeti : MonoBehaviour, IMovement
{
	
	public float finalVelocity;
	public float acceleration;
	public float velocity;
	private float _posX;
	private bool _isGrounded;
	
	public float jump;
	public Animator animator;
	public Transform groundDetect;

	public GameObject player;
		
	void Start()
	{
		animator = gameObject.GetComponent<Animator>();
		Physics.gravity = new Vector3(0,-40.0f,0);
		jump = 800.0f;
	}
	
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
		_isGrounded = Physics.Linecast(transform.position, groundDetect.position, 1 << LayerMask.NameToLayer("Ground"));
		//print(isGrounded);
		animator.SetBool("isGrounded", _isGrounded);
		if (ChangePlayer.ActiveYeti() || ChangePlayer.ActiveAll())
		{
			//_isGrounded = Physics.Linecast(transform.position, groundDetect.position, 1 << LayerMask.NameToLayer("Ground"));
			if (Input.GetButton("Jump") && _isGrounded)
			{
				gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jump, ForceMode.Force);
				
			}
		}
	}

//	public bool IActivePlayer () 
//	{
//		if (Input.GetKey (KeyCode.A)) 
//		{
//			isActive = true;
//			return isActive;
//			player.GetComponent<Player>().isActive = false;
//		} else if(true) 
//		{
//			isActive = ChangePlayer.ActivatePlayer();
//			return isActive;
//		}
//
//	}
	
}
