using UnityEngine;
using System.Collections;

public class ZombieBehaviour : MonoBehaviour 
{
    public Color brainOnColor;
    public GameObject brainOnObj;
    private Material brainOnMaterial;
    public NavMeshAgent agent;
    public Transform player;
    public GameObject flashlight;
    public float roamingSpeed = 3f;
    public float flashlightOFFSpeed = 6f;
    public float flashlightONSpeed = 12f;
    public float turnOffBrainTime = 4f;

    private bool freeRoaming = false;
    private float distPlayerZombie = 100000;
    private bool inFlashlightRange = false;
    private bool inShotRange = false;
    private Vector3 startPosition;

    public int nrOfLives = 3;

	void Start () 
    {
        brainOnMaterial = brainOnObj.GetComponent<Renderer>().material;
        agent.speed = flashlightOFFSpeed;
        ShootWeapon.instance.onShoot += HeardShot;
        FreeRoam();
	}

    void Update()
    {
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0 && !freeRoaming)
        {
            FreeRoam();
        }

        distPlayerZombie = Vector3.Distance(transform.position, player.position);
        inFlashlightRange = distPlayerZombie < 12f;
        inShotRange = distPlayerZombie < 20f;

        if (flashlight.activeSelf && inFlashlightRange)
        {
            agent.speed = flashlightONSpeed;
            KnowsLocation(player.position);
        }
        else 
        {
            agent.speed = flashlightOFFSpeed;
        }
    }

    void HeardShot(Vector3 pos)
    {
        if (inShotRange)
        {
            agent.speed = flashlightOFFSpeed;
            KnowsLocation(pos);
        }
    }

	void KnowsLocation(Vector3 position) 
    {
        LeanTween.cancel(gameObject);
        agent.SetDestination(position);
        brainOnMaterial.SetColor("_TintColor", brainOnColor);
        LeanTween.value(gameObject, TurnOffBrain, brainOnColor.a, 0, turnOffBrainTime);
	}

    public void TurnOffBrain(float val)
    {
        brainOnMaterial.SetColor("_TintColor", new Color(brainOnColor.r, brainOnColor.g, brainOnColor.b, val));
    }

    void OnDestroy()
    {
        ShootWeapon.instance.onShoot -= HeardShot;
        StopCoroutine("ResetRoaming");
    }

    void FreeRoam()
    {
        startPosition = gameObject.transform.localPosition;
        Vector3 randomDirection = Random.insideUnitSphere * 15;
        randomDirection += startPosition;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 30, 1);
        Vector3 finalPosition = hit.position;
        agent.destination = finalPosition;
        agent.speed = roamingSpeed;
        freeRoaming = true;
        StartCoroutine("ResetRoaming");
    }

    IEnumerator ResetRoaming()
    {
        yield return new WaitForSeconds(4);
        FreeRoam();
    }

    public void HasBeenShot()
    {
        agent.destination = player.position;
        nrOfLives--;
        if (nrOfLives == 0)
        {
            Destroy(gameObject);
        }
    }

}
