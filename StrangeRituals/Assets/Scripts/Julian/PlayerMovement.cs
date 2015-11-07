using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public bool MoveOverTransform = false;
    public bool UseJoyStick = true;

    public float MovementSpeed = 5000;
    public float RotationSpeed = 1;

    private Camera mainCamera;
    private Transform myTransform;
    private Rigidbody myRigidBody;
    private float angle;

    void Awake()
    {
        mainCamera = Camera.main;
        myTransform = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
    }

	private void Rotate() 
	{
        float y = Input.GetAxis("rotY");
        float x = Input.GetAxis("rotX");

        angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        myTransform.rotation = Quaternion.Euler(0, angle + mainCamera.transform.rotation.y + 220, 0);
    }

    private void Move()
    {
        if (MoveOverTransform)
            myTransform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed, Space.World);
        else
            myRigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * MovementSpeed);
    }
}
