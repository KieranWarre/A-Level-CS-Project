using UnityEngine;
using System;

public class Target_Shooting_Controller : MonoBehaviour 
{
	public float NextShot;					// rate of fire
	public GameObject[] Targets;			// array holding the targets
	GameObject selectedTarget;				// a target is selected from the array
	private int index;						// position of target in the array
	public int arrayLen;					// length of the array holding the targets

	void Start()
	{
		// puts targets into array
		Targets = GameObject.FindGameObjectsWithTag ("Target");
	}

	void Update()
	{
		//adds the targets in the scene to the array
		Targets = GameObject.FindGameObjectsWithTag ("Target");
		if (Time.time >= NextShot) 
		{
			SelectNewTarget ();
			NextShot = Time.time + UnityEngine.Random.Range(1, 5.0f);
			// calls the shoot function on the target
			selectedTarget.GetComponent<Target_Shooting> ().Shoot ();
		}
	}

	public _GameManager gameManager;		//reference to the game manager script

	void SelectNewTarget()
	{
		//sets arrayLen to length of the targets array
		arrayLen = Targets.Length;

		//when array is empty
		if (arrayLen == 0) 
		{
			//freezes the game
			Time.timeScale = 0f;
			//calls the LevelComplete() function in the game manager
			gameManager.LevelComplete ();
			return;
		}

		//selects a random target from the array
		index = UnityEngine.Random.Range (0, arrayLen);
		selectedTarget = Targets [index];
	}
}