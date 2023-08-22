using UnityEngine.Audio;
using UnityEngine;

public class MenuAudio : MonoBehaviour {

	public AudioSource source;		//reference to the audio source component
	public AudioClip hover;			//hover sound
	public AudioClip click;			//click sound

	//called when cursor hovers over a button
	public void ButtonHover()
	{
		//plays the hover sound 
		source.PlayOneShot (hover);
	}

	//called when a button is clicked
	public void ButtonClick()
	{
		//plays the clicked sound
		source.PlayOneShot (click);
	}
}