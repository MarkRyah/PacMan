using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class contr : MonoBehaviour
{
    public GameObject heart;
    public GameObject heart2;
	private int currentScore;
	public PlayerController Player;
    //public GameObject heart3;
    //public int pelletCount;
	public Text scoreText;
	private const int WINSCORE = 241; //pellet count + 4 powerup count
    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        CheckScore();

    }


	private void CheckScore()
	{   //fix this later
		if(Player.totalPellets > currentScore)
		{
			scoreText.text = Player.totalPellets.ToString("D6");
		}
		if (Player.totalPellets == WINSCORE)
		{
			onLoadScene();
		}
		if (Player.totalSwords != 0)
		{
			scoreText.text = Player.totalPellets.ToString("D6");
		}
		if (Player.totalPellets == WINSCORE * 2)
		{
			SceneManager.LoadScene("Win");	
		}
		if (Player.maxHealth == 2)
		{
			Destroy(heart);
		}
		if (Player.maxHealth == 1)
		{
			Destroy(heart2);
		}
		if (Player.maxHealth == 0)
		{
			SceneManager.LoadScene("EndState");
		}
	}

	private void onLoadScene()
	{
		Player.totalPellets = 0;
		Player.totalSwords = 0;
		SceneManager.LoadScene("Level Two");
	}

}
