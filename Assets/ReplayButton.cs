using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReplayButton : MonoBehaviour {

	[SerializeField]
	private Button MyButton = null; // assign in the editor
	
	void Start()
	{
		MyButton.onClick.AddListener(() => { Restart();});
	}

	void Restart()
	{
		Time.timeScale = 1;
		Application.LoadLevel("MainScene");
	}
}
