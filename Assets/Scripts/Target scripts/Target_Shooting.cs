using UnityEngine;

public class Target_Shooting : MonoBehaviour 
{
	public GameObject shot;					// defines the TargetShot game object in the script
	public Transform ShotSpawn;				// posision where the shots will spawn from

	public void Shoot()
	{
		//spawns a TargetShot game object on the ShotSpawn 
		Instantiate (shot, ShotSpawn.position, ShotSpawn.rotation);
	}
}