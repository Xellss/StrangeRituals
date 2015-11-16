using UnityEngine;
using System.Collections;

public class PlayerAudioController : MonoBehaviour
{
    public BulletSpawn BulletSpawn;

    AudioSource myAudio;

    void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("MiniGunFire") && BulletSpawn.CanShoot && !BulletSpawn.Reload)
        {
            myAudio.enabled = true;
        }
        else
            myAudio.enabled = false;
    }
}
