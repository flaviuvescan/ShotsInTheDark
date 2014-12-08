using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

	public Text text;

	void OnEnable()
	{
		text.text = GameManager.instance.timeLasted.ToString();
	}
}
