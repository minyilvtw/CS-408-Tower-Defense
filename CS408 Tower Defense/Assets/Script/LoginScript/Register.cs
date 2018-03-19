using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour {

	public Text usernameUI;
	public Text emailUI;
	public Text passwordUI;
	public Button registerBtn;
	public Button toLoginBtn;
	public GameObject loginMenu;
	public GameObject registerMenu;
	public Text Invalid;

	void Start()
	{
		Button register = registerBtn.GetComponent<Button>();
		register.onClick.AddListener(loginToGame);
		Button toLogin = toLoginBtn.GetComponent<Button>();
		toLogin.onClick.AddListener(showLogin);
	}

	void loginToGame()
	{
		Players.username = usernameUI.text;
		string email = emailUI.text;
		Players.password = passwordUI.text;
		Debug.Log (Players.username);
		Debug.Log (Players.password);
		Debug.Log (email);
		if (checkInfo (Players.username, Players.password)) {
			Application.LoadLevel (1);
		} else {
			Invalid.text = "Invalid Input";
			Debug.Log ("Invalid Input");
		}
	}

	bool checkInfo(string usrn, string pwd) {
		//check Info
		Regex r = new Regex("^[a-zA-Z0-9]*$");
		if (r.IsMatch (usrn) && r.IsMatch (pwd)) {
			return true;
		} else {
			return false;
		}
	}

	void showLogin() {
		registerMenu.SetActive (false);
		loginMenu.SetActive(true);
	}



}
