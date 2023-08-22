using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float LeftBoundary, RightBoundary;
}

public class Player_controller : MonoBehaviour 
{
	//movement
	[SerializeField]
	public float PlayerSpeed;			// how fast the player can move
	public Rigidbody rb;				// rigidbody component on the player
	public Boundary boundary;			// allows the variables in the boundary class to be used here

	//shooting
	[SerializeField]
	public GameObject shot;					// PlayerShot game object
	public Transform ShotSpawn;				// position where the PlayerShot will spawn from
	public float FireRate = 0.5f;			// rate of fire for the player		
	private float nextFire = 0.0f;

	void FixedUpdate()
	{
		//allows player to move left or right
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerSpeed;
		transform.Translate(x, 0, 0);
		// clamps the y and z axis but allows the player to move between the left and right boundary
		rb.position = new Vector3(Mathf.Clamp (rb.position.x, boundary.LeftBoundary, boundary.RightBoundary), 2.2f, -15.0f);
	
		if (Input.GetKey ("space") && Time.time > nextFire) 
		{
			//resets time before next shot
			nextFire = Time.time + FireRate;
			//spawns a player shot on the spawn point
			Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
		}
	}
}