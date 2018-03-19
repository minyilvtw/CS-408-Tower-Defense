using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        Debug.Log("Loading next scene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("ExtraMain");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
		SceneManager.LoadScene("Login");
        Application.Quit();
    }
	public void toLv1() {
		SceneManager.LoadScene ("ExtraMain");
	}

	public void toLv2() {
		SceneManager.LoadScene("Level1");
	}
}
