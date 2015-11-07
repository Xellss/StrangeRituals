using UnityEngine;
using System.Collections;

public class Navigator : MonoBehaviour {

    public Transform objectToFollowTransform;
    private Rigidbody myRigidbody;
    private float rotation;

    void Awake()
    {
        myRigidbody = 
        // Get myRigidbody
    }

	// Update is called once per frame
	void Update () {
        float distanceX = objectToFollowTransform.position.x - myTransForm.position.x;
        float distanceY = objectToFollowTransform.position.y - myTransForm.position.y;

        float tempRotation = Mathf.Atan2(distanceY, distanceX);
        rotation = (180 / Mathf.PI) * tempRotation - 90;

        myRigidBody.rotation = rotation;
	}
}
