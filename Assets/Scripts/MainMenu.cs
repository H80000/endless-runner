using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public GameObject helpCanvas;

	public void NewGame(){
		Application.LoadLevel (startLevel);
	}

	public void Help(){
		helpCanvas.SetActive (true);
	}

	public void OK(){
		helpCanvas.SetActive (false);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
