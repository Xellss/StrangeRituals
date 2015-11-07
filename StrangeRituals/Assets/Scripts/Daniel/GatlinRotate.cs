using UnityEngine;
using System.Collections;

public class GatlinRotate : MonoBehaviour {

	public float RotateSpeed = 20;
	void Update () 
    {
        if (Input.GetButton("Jump"))
        {
            transform.Rotate(RotateSpeed, 0, 0);
        }
	}
}
