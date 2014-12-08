using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    public Rigidbody playerBody;
    public float speed = 20f;
    public float sprintMultiplier = 1.5f;

    private Vector2 translation;
    private float sprint = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey("joystick button 4")) sprint = sprintMultiplier;
        else sprint = 1f;

        translation = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed / 10 * sprint * Time.deltaTime;

        playerBody.position += new Vector3(translation.x, 0, translation.y);
    }

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag.Equals("Zombie"))
		{
			GameManager.instance.GameOver();
		}
	}

    void OnCollisionExit(Collision coll)
    {
        playerBody.velocity = Vector3.zero;
    }
}
