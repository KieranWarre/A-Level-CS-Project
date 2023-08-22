using UnityEngine;

public class TargetShot : MonoBehaviour
{
	[SerializeField]
	public float speed;				// speed at which the shot moves in the scene
	public Rigidbody Rb;			// rigidbody component of the shot 

	void FixedUpdate ()
	{
		//updates the transform of the shot in the z direction, moving it downwards
		Rb.transform.position = new Vector3(Rb.transform.position.x, Rb.transform.position.y,
			Rb.transform.position.z - speed);
	}

	// called when shot collides with another object 
	void OnTriggerEnter(Collider other)
	{
		//if it collides with the player 
		if (other.tag == "Player") 
		{
			//destroys the target shot
			Destroy (gameObject);
			//minuses 1 from lives
			_GameManager.Lives -= 1;
		}
	}
}