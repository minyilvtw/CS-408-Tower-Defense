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

	void Start()
	{
		Button login = loginBtn.GetComponent<Button>();
		login.onClick.AddListener(loginToGame);
		Button toRegister = toRegisterBtn.GetComponent<Button>();
		toRegister.onClick.AddListener(showRegister);
	}

	void loginToGame()
	{
		Variables.username = usernameUI.text;
		Variables.password = passwordUI.text;
		Debug.Log (Variables.username);
		Debug.Log (Variables.password);
		if (checkInfo (Variables.username, Variables.password)) {
			Application.LoadLevel (1);
		}
	}

	bool checkInfo(string usrn, string pwd) {
		//checkInfo
		return true;
	}

	void showRegister() {
		loginMenu.SetActive(false);
		registerMenu.SetActive (true);
	}
	

}
