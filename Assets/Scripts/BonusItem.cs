using UnityEngine;

public class BonusItem : MonoBehaviour 
{
	public float speed;		//speed the item moves 
	public Rigidbody rb;	//reference to the rigidbody component 

	void FixedUpdate()
	{
		//moves the item across the screen horizontally
		rb.transform.position = new Vector3 (rb.transform.position.x + speed,
			rb.transform.position.y, rb.transform.position.z);
	}
}
