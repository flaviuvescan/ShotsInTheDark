using UnityEngine;
using System.Collections;

public class RotatePlayer : MonoBehaviour {

    private Quaternion targetRotation;
    private Vector3 targetPoint;
    private Plane playerPlane;
    private float hitDist = 0f;

    void Update()
    {
		if(!GameManager.instance.gameOver)
		{
	        playerPlane = new Plane(Vector3.up, transform.position);

	        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	        if (playerPlane.Raycast(ray, out hitDist))
	        {
	            // Get the point along the ray that hits the calculated distance.
	            targetPoint = ray.GetPoint(hitDist);

	            targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

	            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1);
	        }
		}
    }
}
