using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

	public string name;			//name of sound
	public AudioClip clip;		//sound clip

	[Range(0f, 1f)]
	public float volume;		//volume of sound clip
	[Range(.1f, 3f)]
	public float pitch;			//pitch of sound clip

	public bool loop;

	[HideInInspector]			//hides the audio source in the inspector
	public AudioSource source;	//audio source the sound is played through
}