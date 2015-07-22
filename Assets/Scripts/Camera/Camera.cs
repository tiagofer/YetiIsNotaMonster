using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Transform person;
	public float smooth = 0.3f;
	public float vel = 0.3f;
	public float velY = 0.5f;
	public float posX;
	public float posY;
	// Update is called once per frame
	void Update () {
		posX = Mathf.SmoothDamp(transform.position.x, person.position.x, ref vel, smooth);
		posY = Mathf.SmoothDamp(transform.position.y, person.position.y, ref velY, smooth);

		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}
