using UnityEngine;
using System.Collections;

public class ShootWeapon: MonoBehaviour
{
    public static ShootWeapon instance; 

    public delegate void  OnShootEvent(Vector3 playerPosition);
    public event OnShootEvent onShoot;

    public Rigidbody Bullet;
    public float speed = 20f;
    public bool canShootAgain = true;
    public float waitBetweenShots = 0.3f;
    public float anxietySecondsToAdd = 0.5f;
    public float scatterAmount = 5;
    private Vector3 shotDirection = Vector3.zero; 

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShootAgain)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(Bullet, transform.position, transform.rotation);
            shotDirection = new Vector3(bulletClone.transform.right.x + (Random.Range(-scatterAmount, scatterAmount) / 100), 
                                            bulletClone.transform.right.y,
                                                bulletClone.transform.right.z + (Random.Range(-scatterAmount, scatterAmount) / 100));
            bulletClone.AddForce(shotDirection * speed, ForceMode.Impulse);
            canShootAgain = false;
            AnxietyMeter.instance.AddToTimer(anxietySecondsToAdd);
            if(onShoot != null) onShoot(gameObject.transform.position);
            StartCoroutine(WaitBeforeShooting());
        }
    }

    IEnumerator WaitBeforeShooting()
    {
        yield return new WaitForSeconds(waitBetweenShots);
        canShootAgain = true;
    }
}