using UnityEngine;

public class Target_movement : MonoBehaviour {

	[SerializeField]
	public float MoveDistanceX;			// how far the targets move in the horizontal direction
	public float MoveDistanceZ;			// how far the targets move down 
	public float timeLeft;				// time between the targets movement 
	public float timeRestart;
	public float RightEdge;				// targets move down when at an edge
	public float LeftEdge;

	// holds a boolean value to dictate which direction the targets move
	private bool AtRightEdge = false;

	void FixedUpdate()
	{
		//target moves horizontal when timer = 0 and it's not at the edge of the scene
		timeLeft -= Time.deltaTime;
		if ((timeLeft <= 0) && (AtRightEdge == false)) 
		{ 
			MoveRight ();
			//resets timer
			timeLeft = timeRestart;
			//moves down
			if (transform.position.x == RightEdge) 
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - MoveDistanceZ);
				AtRightEdge = true;
			}
		}else if ((timeLeft <= 0)  && (AtRightEdge = true)) 
		{
			MoveLeft ();
			timeLeft = timeRestart;
			//moves down
			if (transform.position.x == LeftEdge) 
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - MoveDistanceZ);
				AtRightEdge = false;
			}
		}
	}

	void MoveRight()
	{
		//moves "MoveDistanceX" in positive x direction
		transform.position = new Vector3 (transform.position.x + MoveDistanceX, transform.position.y,
			transform.position.z);
	}

	void MoveLeft()
	{
		//moves "MoveDistanceX" in negative x direction
		transform.position = new Vector3 (transform.position.x - MoveDistanceX, transform.position.y,
			transform.position.z);
	}
}
