using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {

    public GameObject BulletPrefab;
    public Transform Player;
    public float BulletForce = 100;
    public float LifeTime = 1;
    public float DelayTime = 0.5f;
    public int MaxBulletAmount = 100;
    public float ReloadTime = 1;
    public static bool CanShoot = true;
    public static bool Reload = false;

    private GameObject newBullet;
    private Rigidbody myRigidbody;
    private int bulletAmount = 0;

    void Update()
    {
        CooldownWeapon();
        bulletSpawn();
    }

    void bulletSpawn()
    {
        if (Input.GetButton("Jump") && CanShoot && !Reload)
        {
            newBullet = (GameObject)Instantiate(BulletPrefab,transform.position,Quaternion.identity);
            Rigidbody bulletRig = newBullet.GetComponent<Rigidbody>();
            bulletRig.AddRelativeForce(Player.transform.forward * BulletForce);
            bulletAmount++;
            StartCoroutine(DestroyAfterLifetime(newBullet));
            StartCoroutine(ShootDelay());
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
        yield return new WaitForSeconds(DelayTime);
        CanShoot = true;
    }
}
