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
		Variables.username = usernameUI.text;
		string email = emailUI.text;
		Variables.password = passwordUI.text;
		Debug.Log (Variables.username);
		Debug.Log (Variables.password);
		Debug.Log (email);
		if (checkInfo (Variables.username, Variables.password)) {
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
