using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform person;
	public float smooth = 0.2f;
	public float vel = 0.3f;
	public float velY = 0.5f;
	public float posX;
	public float posY;
	private bool _isFollow;
	Vector3 offset;


	void Start() 
	{
		offset = transform.position - person.position;
		_isFollow = true;
	}
	// Update is called once per frame
	void FixedUpdate () {
		//posX = Mathf.SmoothDamp(transform.position.x, person.position.x, ref vel, smooth);
		//posY = Mathf.SmoothDamp(transform.position.y, person.position.y, ref velY, smooth);
		if (person.position.x >= -4.7f) {
			_isFollow = true;
		} else 
		{
			_isFollow = false;
		}
		if (_isFollow) {
			Vector3 targetCamPos = person.position + offset;
			transform.position = Vector3.Lerp (targetCamPos, transform.position, smooth * Time.deltaTime);
		} 
	
	}
}
