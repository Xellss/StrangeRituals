using UnityEngine;
using System.Collections;

public class RotateItems : MonoBehaviour {
    public float RotateSpeed = 5;

	void Update ()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.Self);	
	}
}
