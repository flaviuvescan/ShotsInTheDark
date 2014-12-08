using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {

	public GameObject canvas;

	private bool isHovering = false;

	public void IsHovering()
	{
		isHovering = true;
	}

	void Update()
	{
		if(isHovering)
		{
			renderer.material.SetColor("_TintColor", Color.red);
		}
		else
		{
			renderer.material.SetColor("_TintColor", Color.white);
		}

		if(isHovering && Input.GetMouseButtonDown(0))
		{
			Action();
		}

		isHovering = false;
	}

	void Action()
	{
		if(!canvas.activeSelf)
		{
			switch(gameObject.name)
			{
				case "Play":
					Application.LoadLevel("MainScene");
					break;
				case "Instructions":
					canvas.SetActive(true);
					break;
				case "Exit":
					Application.Quit();
					break;

			}
		}
		
	}
}
