using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;	//whether game is paused
	public GameObject pauseMenuUI;				//reference to the pause menu UI
	public GameObject instructionUI;			//reference to the instruction UI

	void Update () 
	{
		//when the user presses ESC
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused) {
				//resumes the game
				Resume ();
			} else {
				//pauses the game
				Pause();
			}
		}
	}

	public void Resume()
	{
		//disables pause menu 
		pauseMenuUI.SetActive (false);
		//disables the intructions UI
		instructionUI.SetActive (false);
		//set the speed at which time passes back to normal
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Pause()
	{
		// enables the pause menu UI
		pauseMenuUI.SetActive (true);
		// freezes the game
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void ExitToMainMenu()
	{
		//set the speed at which time passes back to normal
		Time.timeScale = 1f;
		//loads the main menu scene
		SceneManager.LoadScene ("Main Menu");
	}
}
