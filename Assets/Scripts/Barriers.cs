using UnityEngine;

public class Barriers : MonoBehaviour 
{
	//materials for the barriers
	public Material BarrierStage3;
	public Material BarrierStage2;
	public Material BarrierStage1;
	public int state = 4;

	void OnTriggerEnter(Collider other)
	{
		//destroys any shot that collides with a barrier
		if (other.tag == "shot") 
		{
			Destroy(other.gameObject);
		}
		state -= 1;
		//changes the material of the barrier
		UpdateMaterial ();
	}

	void UpdateMaterial()
	{
		//reference to the mesh renderer on the barrier
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		//changes the material depending on what state teh barrier is on
		if (state == 3) {
			renderer.material = BarrierStage3;
		} else if (state == 2) {
			renderer.material = BarrierStage2;
		} else if (state == 1) {
			renderer.material = BarrierStage1;
		} else if (state <= 0) {
			Destroy (gameObject);
		}
	}
}
