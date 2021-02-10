using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
	public void ReturnButt()
	{
		SceneManager.LoadScene("Menu");
	}
}
