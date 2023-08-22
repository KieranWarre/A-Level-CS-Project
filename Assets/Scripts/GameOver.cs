using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour 
{
	public _GameManager gameManager;		//reference to the game manager script

	void OnTriggerEnter(Collider other)
	{
		//when a target collides with it
		if (other.name.Contains("Target:")) 
		{
			//calls the game over functio
			gameManager.GameOver ();
		}
	}	
}
