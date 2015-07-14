using UnityEngine;
using System.Collections;

public class StartTreeAnim : MonoBehaviour {

	public Animator treeRotation;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("yeti"))
		{
			treeRotation.SetBool("isActive", true);
		} else if (other.gameObject.CompareTag("ground"))
			treeRotation.SetBool("isGrounded", true);
	}
}
