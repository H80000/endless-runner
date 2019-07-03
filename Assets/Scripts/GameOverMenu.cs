using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	public string startLevel;
	
	public string mainMenu;
	
	public void NewGame(){
		Application.LoadLevel (startLevel);
	}
	
	public void Quit(){
		Application.LoadLevel (mainMenu);
	}

}
