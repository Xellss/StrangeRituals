using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {

    public GameObject BulletPrefab;
    public Transform Player;
    public float BulletForce = 100;
    public float LifeTime = 1;
    public float MaxDelayTime = 0.6f;
    public float MinDelayTime = 0.4f;
    public int MaxBulletAmount = 100;
    public float ReloadTime = 1;
    public static bool CanShoot = true;
    public static bool Reload = false;

    private GameObject newBullet;
    private Rigidbody myRigidbody;
    private Transform myTransForm;
    private int bulletAmount = 0;

    void Awake()
    {
        myTransForm = GetComponent<Transform>();  
    }
    
    void Update()
    {
        CooldownWeapon();
        bulletSpawn();
    }

    void bulletSpawn()
    {
        if (CanShoot && !Reload)
        {
            if (Input.GetAxis("Shoot") > 0.1f || Input.GetMouseButton(0))
            {
                newBullet = (GameObject)Instantiate(BulletPrefab, myTransForm.position, myTransForm.rotation);
                Rigidbody bulletRig = newBullet.GetComponent<Rigidbody>();
                bulletRig.AddForce(Player.transform.forward * BulletForce);
                bulletAmount++;
                StartCoroutine(DestroyAfterLifetime(newBullet));
                StartCoroutine(ShootDelay());
            }
        }
    }

    void CooldownWeapon()
    {
        if (bulletAmount == MaxBulletAmount && !Reload)
        {
            StartCoroutine(WeaponCooldown());
        }
    }
    IEnumerator WeaponCooldown()
    {
        Reload = true;
        CanShoot = false;
        yield return new WaitForSeconds(ReloadTime);
        Reload = false;
        CanShoot = true;
        bulletAmount = 0;
    }
    IEnumerator DestroyAfterLifetime(GameObject mybullet)
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(mybullet);
    }
    IEnumerator ShootDelay()
    {
        CanShoot = false;
        yield return new WaitForSeconds(Random.Range((float)MinDelayTime, (float)MaxDelayTime));
        CanShoot = true;
    }
}
