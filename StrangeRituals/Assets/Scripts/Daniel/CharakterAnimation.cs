using UnityEngine;
using System.Collections;

public class CharakterAnimation : MonoBehaviour {

    Animator myAnimator;
    GameObject Fire1;
    GameObject Fire2;
    MeshRenderer Fire1R;
    MeshRenderer Fire2R;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        Fire1 = GameObject.Find("Cylinder_1_2_2");
        Fire2 = GameObject.Find("Cylinder_1_3_2");
        Fire1R = Fire1.GetComponent<MeshRenderer>();
        Fire2R = Fire2.GetComponent<MeshRenderer>();

    }
	
	void Update () 
    {
        if (Input.GetButton("Jump"))
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
