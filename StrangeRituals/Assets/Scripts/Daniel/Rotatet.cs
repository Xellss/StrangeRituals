using UnityEngine;
using System.Collections;

public class Rotatet : MonoBehaviour {

    Rigidbody myRigid;
	
    void Awake()
    {
        myRigid = GetComponent<Rigidbody>();
    }
	void Update () 
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        //myRigid.rotation = transform.rotation;
	}
}
