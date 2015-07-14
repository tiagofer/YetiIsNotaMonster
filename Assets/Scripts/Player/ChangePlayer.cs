using UnityEngine;
using System.Collections;

public abstract class ChangePlayer 
{
	public static bool isActive = true;
	public static bool playerActive = false;
	public static bool yetiActive = false;

	public static bool ActiveYeti() 
	{
	 	if (Input.GetKey(KeyCode.S)) 
		{
			//activate yeti player
			isActive = false;
			playerActive = false;
			yetiActive = true;
		} 
		return yetiActive;
	}
	public static bool ActivePlayer() 
	{
		if (Input.GetKey(KeyCode.D)) 
		{
			//activate player girl
			isActive = false;
			playerActive = true;
			yetiActive = false;
		}
		return playerActive;
	}
	public static bool ActiveAll() 
	{
		if (Input.GetKey (KeyCode.A)) 
		{
			//activate two players command
			isActive = true;
		}
		return isActive;
	}


	                               

}

