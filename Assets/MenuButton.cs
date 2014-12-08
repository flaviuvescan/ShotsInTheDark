using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButton : MonoBehaviour {

	[SerializeField]
	private Button MyButton = null; // assign in the editor
	
	void Start()
	{
		MyButton.onClick.AddListener(() => { GoToMenu();});
	}
	
	void GoToMenu()
	{
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
	}
}
