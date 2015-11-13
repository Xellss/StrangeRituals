using UnityEngine;
using System.Collections;

public class RotateItems : MonoBehaviour {

	void Update ()
    {
        transform.Rotate(0, 5f, 0, Space.Self);	
	}
}
