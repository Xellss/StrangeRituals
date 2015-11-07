using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour
{

    GameObject bulletSpawn;
    BulletSpawn bulletScript;
    public Rigidbody bullet;

    void Awake()
    {
        bulletSpawn = GameObject.Find("BulletSpawn");
        bulletScript = bulletSpawn.GetComponent<BulletSpawn>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            // bulletScript.DelayTime = 0.5f;
            // bulletScript.Damage = 100;
            // bulletScript.BulletForce /= 15f; 
            //bullet.useGravity = true;
            
        }
    }
}