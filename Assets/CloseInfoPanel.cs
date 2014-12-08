using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseInfoPanel : MonoBehaviour {

	public GameObject canvas;

	[SerializeField]
	private Button MyButton = null; // assign in the editor
	
	void Start()
	{
		MyButton.onClick.AddListener(() => { ClosePanel();});
	}

	void ClosePanel () 
	{
		canvas.SetActive(false);
	}
}
