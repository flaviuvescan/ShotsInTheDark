using UnityEngine;
using System.Collections;

public class ActivateFlashlight : MonoBehaviour {

    public GameObject flashlight;
    public float anxietyReliefBy = 2;

    void Update()
    {
		if(!GameManager.instance.gameOver)
		{
	        if (Input.GetMouseButton(1))
	        {
	            flashlight.SetActive(true);
	            AnxietyMeter.instance.AddToTimer(anxietyReliefBy * Time.deltaTime);
	        }
	        else 
	        {
	            flashlight.SetActive(false);
	        }
		}
    }
}
