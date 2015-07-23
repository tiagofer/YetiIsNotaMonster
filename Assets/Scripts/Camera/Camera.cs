using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Transform person;
	public float smooth = 0.2f;
	public float vel = 0.3f;
	public float velY = 0.5f;
	public float posX;
	public float posY;
	Vector3 offset;


	void Start() 
	{
		offset = transform.position - person.position;

	}
	// Update is called once per frame
	void FixedUpdate () {
		//posX = Mathf.SmoothDamp(transform.position.x, person.position.x, ref vel, smooth);
		//posY = Mathf.SmoothDamp(transform.position.y, person.position.y, ref velY, smooth);
		Vector3 targetCamPos = person.position + offset;
		transform.position = Vector3.Lerp (targetCamPos, transform.position, smooth * Time.deltaTime);
	}
}
