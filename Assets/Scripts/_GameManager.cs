using UnityEngine;
using UnityEngine.UI;

public class _GameManager : MonoBehaviour 
{		
	public static int Score = 0;		// score 
	public Text ScoreTxt;				// score text box
	public Text GameOverScoreTxt;		// score text on the game over screen

	public static int Lives = 3;		// players lives
	public Text LivesTxt;				// lives text box

	public GameObject BonusItem;		// Bonus item gameobject 
	public Transform BonusItemSpawn;	// where the bonus item spawns from
	public float NextSpawn;				// time between spawns

	void Start()
	{
		//sets time before the first spawn
		NextSpawn = UnityEngine.Random.Range (10, 30);
	}

	void Update()
	{
		if (Time.time >= NextSpawn) 
		{
			//resets the time for the next spawn
			NextSpawn = Time.time + UnityEngine.Random.Range (10,30);
			// spawns bonus item
			Instantiate (BonusItem, BonusItemSpawn.position, BonusItemSpawn.rotation);
		}

		// displays the score and lives 
		ScoreTxt.text = "SCORE: " + Score;
		LivesTxt.text = "LIVES: " + Lives;

		if (Lives == 0) 
		{
			//calls the game over function
			GameOver ();
		}
	}

	//reference to the game over screen
	public GameObject GameOverScreen;		

	public void GameOver()
	{
		//changes the text on the game over screen
		GameOverScoreTxt.text = "SCORE: " + Score;
		//freezes the game
		Time.timeScale = 0f;
		//displays the game over screen
		GameOverScreen.SetActive (true);
	}

	//resets the score and lives
	public void Reset()
	{
		Lives = 3;
		Score = 0;
	}

	public GameObject LevelCompleteScreen;		//reference to the level complete screen
	public Text LevelCompleteScoreTxt;			//reference to teh text on the level complete screen

	public void LevelComplete()
	{
		//changes the text on the level complete screen
		LevelCompleteScoreTxt.text = "SCORE: " + Score;
		//displays the level complete screen 
		LevelCompleteScreen.SetActive (true);
	}
}