using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Login : MonoBehaviour {

	public Text usernameUI;
	public Text passwordUI;
	public Button loginBtn;
	public Button toRegisterBtn;
	public GameObject loginMenu;
	public GameObject registerMenu;
	public Text Invalid;

	void Start()
	{
		Button login = loginBtn.GetComponent<Button>();
		login.onClick.AddListener(loginToGame);
		Button toRegister = toRegisterBtn.GetComponent<Button>();
		toRegister.onClick.AddListener(showRegister);
	}

	void loginToGame()
	{

		if (checkInfo(usernameUI.text, passwordUI.text)) {
			Application.LoadLevel (1);
		} else {
			Invalid.text = "Invalid Input";
			Debug.Log ("Invalid Input");
		}
	}

	bool checkInfo(string usrn, string pwd) {
		//checkInfo

		if (usrn == Players.username && pwd == Players.password) {
			return true;
		}
		return false;
	}

	void showRegister() {
		loginMenu.SetActive(false);
		registerMenu.SetActive (true);
	}
	

}
