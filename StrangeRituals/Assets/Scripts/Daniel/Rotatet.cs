using UnityEngine;
using System.Collections;

public class Rotatet : MonoBehaviour {
    public float RotateSpeed = 1;

	void Update () 
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * RotateSpeed, 0);
	}
}
