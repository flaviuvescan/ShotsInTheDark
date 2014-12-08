using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

	void Update() 
	{	
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit))
		{
			hit.collider.GetComponent<MenuInput>().IsHovering();
		}
	}
}
