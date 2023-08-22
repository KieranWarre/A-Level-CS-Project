using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {

	[SerializeField]
	public float speed = 0.0f;			//speed of the shot
	public Rigidbody Rb;				// rigidbody component of the shot
	public float rotation;				// how fast the ball rotates

	void FixedUpdate()
	{
		//updates the transform of the shot in the z direction
		Rb.transform.position = new Vector3(Rb.transform.position.x, Rb.transform.position.y, Rb.transform.position.z + speed);
		transform.Rotate (0, rotation, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		//identifies whether the shot collides with a target
		if (other.tag == "Target") 
		{
			//removes the target and shot from the scene
			Destroy (other.gameObject);
			Destroy (gameObject);
			FindObjectOfType<AudioManager> ().PLay ("TargetHit");
		}

		// decides how many point to add depending on what row the target is in
		if (other.name.Contains ("Target: Row 4")) {
			_GameManager.Score += 10;
		} else if (other.name.Contains ("Target: Row 3")) {
			_GameManager.Score += 20;
		} else if (other.name.Contains ("Target: Row 2")) {
			_GameManager.Score += 30;
		} else if (other.name.Contains ("Target: Row 1")) {
			_GameManager.Score += 40;
		} 

		if (other.tag == "Bonus Item") 
		{
			//plays the BonusItemHit sound
			FindObjectOfType<AudioManager> ().PLay ("BonusItemHit");
			//adds one to lives
			_GameManager.Lives += 1;
			//destroys bonus item
			Destroy (other.gameObject);
			//destroys the player shot
			Destroy (gameObject);
		}
	}
}