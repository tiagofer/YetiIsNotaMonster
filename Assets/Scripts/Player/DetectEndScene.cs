using UnityEngine;
using System.Collections;

public class DetectEndScene : MonoBehaviour {


	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("yeti") || other.gameObject.CompareTag("Player"))
		{
			gameObject.GetComponent<Player>().velocity = 0.0f;
			gameObject.GetComponent<Yeti>().velocity = 0.0f;
		}
	}
}