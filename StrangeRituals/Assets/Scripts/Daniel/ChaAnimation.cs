using UnityEngine;
using System.Collections;

public class ChaAnimation : MonoBehaviour {

    public BulletSpawn BulletShoot;

    Animator myAnimator;
    GameObject Fire1;
    GameObject Fire2;
    MeshRenderer Fire1R;
    MeshRenderer Fire2R;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        Fire1 = GameObject.Find("Muzzle_1");
        Fire2 = GameObject.Find("Muzzle_2");
        Fire1R = Fire1.GetComponent<MeshRenderer>();
        Fire2R = Fire2.GetComponent<MeshRenderer>();

    }

    void Update()
    {
        if (Input.GetAxis("Shoot") > 0.1f || Input.GetMouseButton(0) && BulletShoot.CanShoot && !BulletShoot.Reload)
        {
            myAnimator.Play("Shoot");
            Fire1R.enabled = true;
            Fire2R.enabled = true;
        }
        else
        {
            myAnimator.Play("Main");
            Fire1R.enabled = false;
            Fire2R.enabled = false;
        }
    }
}
