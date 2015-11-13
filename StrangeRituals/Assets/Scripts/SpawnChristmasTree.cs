using UnityEngine;
using System.Collections;

public class SpawnChristmasTree : MonoBehaviour {

    public float RotationSpeed = 1;
    public float VelocitySpeed = 1;
    public GameObject ParticleEffect;

    //private ParticleSystem particleSystem;
    private bool endOfVelocity = false;

	void Awake ()
    {
        //particleSystem = ParticleEffect.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        spawn();
	}

    void spawn()
    {
        if (transform.position.y >= 0)
        {
            endOfVelocity = true;
            ParticleEffect.SetActive(true);
            StartCoroutine(endOfGame());
            
        }

        if (!endOfVelocity)
        {
            transform.Rotate(0,RotationSpeed * Time.deltaTime,0);
            transform.Translate(0, VelocitySpeed * Time.deltaTime, 0);
        }
    }


    IEnumerator endOfGame()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("win");
    }
}
