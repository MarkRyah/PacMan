using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
	public void Play()
	{
		SceneManager.LoadScene("SampleScene");
	}
	public void ControlsButt()
	{
		SceneManager.LoadScene("Controls");
	}
	public void CreditsButt()
	{
		SceneManager.LoadScene("Credits");
	}
	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}

}
