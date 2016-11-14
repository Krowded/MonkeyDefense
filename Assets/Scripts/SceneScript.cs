using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneScript : MonoBehaviour {


	void OnWin()
	{
		SceneManager.LoadScene("Menu");
	}

	void OnLoss()
	{
		SceneManager.LoadScene("Menu");
	}
}
