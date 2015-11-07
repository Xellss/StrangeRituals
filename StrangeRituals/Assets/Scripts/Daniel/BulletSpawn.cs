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
    

    private GameObject newBullet;
    private Rigidbody myRigidbody;
    private bool canShoot = true;
    private bool reload = false;
    private int bulletAmount = 0;

    void Update()
    {
        CooldownWeapon();
        bulletSpawn();
        //print(bulletAmount);
    }

    void bulletSpawn()
    {
        if (Input.GetButton("Jump") && canShoot && !reload)
        {
            newBullet = (GameObject)Instantiate(BulletPrefab,transform.position,Quaternion.identity);
            Rigidbody bulletRig = newBullet.GetComponent<Rigidbody>();
            bulletRig.AddRelativeForce(Player.transform.forward * BulletForce);
            bulletAmount++;
            StartCoroutine(DestroyAfterLifetime(newBullet));
            StartCoroutine(ShootDelay());
            //print(bulletAmount);
        }
    }

    void CooldownWeapon()
    {
        if (bulletAmount == MaxBulletAmount && !reload)
        {
            StartCoroutine(WeaponCooldown());
        }
    }
    IEnumerator WeaponCooldown()
    {
        reload = true;
        canShoot = false;
        yield return new WaitForSeconds(ReloadTime);
        reload = false;
        canShoot = true;
        bulletAmount = 0;
    }
    IEnumerator DestroyAfterLifetime(GameObject mybullet)
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(mybullet);
    }
    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(DelayTime);
        canShoot = true;
    }


}
