using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public float timeBeforeSelfDestruct = 2f;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Zombie"))
        {
            other.gameObject.GetComponent<ZombieBehaviour>().HasBeenShot();
        }

        Destroy(gameObject);
    }

    void OnEnable()
    {
        StartCoroutine("SelfDestruct");
    }

    void OnDisable()
    {
        StopCoroutine("SelfDestruct");
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeBeforeSelfDestruct);
        Destroy(gameObject);
    }
}
