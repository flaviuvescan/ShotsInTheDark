using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

    public Transform player;
    public GameObject flashlight;
    public GameObject zombie;
    public float timeBetweenSpawns = 5f;
    public float timeReducingAfterEachSpawn = 0.1f;

    void Start()
    {
        Spawn();
        StartCoroutine("SpawnZombie");
    }

    IEnumerator SpawnZombie()
    { 
		if(!GameManager.instance.gameOver)
		{
	        float timeToWait = Random.RandomRange(timeBetweenSpawns - 2, timeBetweenSpawns + 2);
	        yield return new WaitForSeconds(timeToWait);
	        float dist = Vector3.Distance(transform.position, player.position);
	        if (dist > 15)
	        {
	            Spawn();
	        }
	        StartCoroutine("SpawnZombie");
		}
	}

    void Spawn()
    {
        GameObject clone = Instantiate(zombie, transform.position, transform.rotation) as GameObject;
        ZombieBehaviour behaviour = clone.GetComponent<ZombieBehaviour>();
        behaviour.player = player;
        behaviour.flashlight = flashlight;
        timeBetweenSpawns -= timeReducingAfterEachSpawn;
    }
}
