using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	//array thaat hold the sounds
	public Sound[] sounds;

	//called just before Start()
	void Awake () 
	{
		//loops through each sound in the array
		foreach (Sound s in sounds) 
		{
			//adds an audio source for every sound
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	void Start()
	{
		//plays the backing track
		PLay ("Theme");
	}

	//takes in the name of a sound
	public void PLay(string name)
	{
		//the name of the sound passed in is searched for in the array
		Sound s = Array.Find (sounds, sound => sound.name == name);
		//if the sound isn't in the array
		if (s == null) {
			//displays an error message in the console
			Debug.LogError ("sound: " + name + " not found");
			return;
		}
		//plays the sound
		s.source.Play ();
	}
}