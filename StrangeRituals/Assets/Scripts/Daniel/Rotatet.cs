using UnityEngine;
using System.Collections;

public class Rotatet : MonoBehaviour {

	void Update () 
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
	}
}
