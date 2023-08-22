using UnityEngine;

public class DestroyByBoundary : MonoBehaviour 
{
	//when a game object is no longer in the boundary, this function is called
	void OnTriggerExit(Collider other)
	{
		// other game object removed from the scene
		Destroy (other.gameObject);
	}
}