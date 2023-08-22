using UnityEngine;

public class PlayerHit : MonoBehaviour {

	public Player_controller playerController;	// reference to the PlayerController script
	public bool PlayerActive;					// whether the player is curently active
	public float HitDuration = 2f;				// how long the player is disabled for
	public float TimeRemaining;					// holds how long the player has left before it's active again

	void Start()
	{
		TimeRemaining = HitDuration;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name.Contains("TargetShot"))
		{
			//plays the PLayerHit sound
			FindObjectOfType<AudioManager> ().PLay ("PlayerHit");
			//disables the player
			playerController.enabled = false;
			PlayerActive = false;
			//changes the colour of the player
			ChangePlayerColour ();
		}
	}

	private void Update()
	{
		//how long the player is disabled for
		if (!PlayerActive && TimeRemaining > 0) {
			TimeRemaining -= Time.deltaTime;
		} else {
			TimeRemaining = HitDuration;
			//re-enables the player
			playerController.enabled = true;
			PlayerActive = true;
			//changes the player colours back
			ChangeColourBack ();
		}
	}

	public Material PlayerHitMat;		//colour the player changes to when hit
	public Material CapsuleColour;		//normal colour of the capsule child object 
	public Material CylinderColour;		//normal colour of the cylinder child object

	void ChangePlayerColour()
	{
		//array that hold the child object of the player
		Renderer[] children;
		//adds the child objects to the array
		children = GetComponentsInChildren<Renderer> ();

		//loops through each object in the array
		foreach (Renderer rend in children) 
		{
			//changes the colour of all object that are visible 
			if (rend.name == "Capsule") {
				rend.material = PlayerHitMat;
			} else if (rend.name == "Cylinder") {
				rend.material = PlayerHitMat;
			}
		}
	}

	void ChangeColourBack()
	{
		//array that hold the child object of the player
		Renderer[] children;
		//adds the child objects to the array
		children = GetComponentsInChildren<Renderer> ();

		//loops through each object in the array
		foreach (Renderer rend in children) 
		{
			//changes the colour of all object that are visible 
			if (rend.name == "Capsule") {
				rend.material = CapsuleColour;
			} else if (rend.name == "Cylinder") {
				rend.material = CylinderColour;
			}
		}
	}
}