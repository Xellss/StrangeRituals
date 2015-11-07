using UnityEngine;
using System.Collections;

public class CaracterController : MonoBehaviour 
{
    public bool MoveOverTransform = false;
    public bool UseJoyStick = true;
    public bool GodMode = false;

    public float MovementSpeed = 5000;
    public float RotationSpeed = 1;

    private Camera mainCamera;
    private Health myHealth;
    private Transform myTransform;
    private Rigidbody myRigidBody;

    private float angleToAvoid = 220.25f;
    private float angleBackUp;
    private float angle;

    void Awake()
    {
        mainCamera = Camera.main;
        myTransform = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody>();
        myHealth = GetComponent<Health>();

        angleToAvoid = angle;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void OnCollisionEnter(Collision other)
    {
        if (!GodMode)
        {
            if (other.gameObject.tag == "Enemy")
            {
                EnemyController otherController = other.gameObject.GetComponent<EnemyController>();
                myHealth.DecreaseHealth(otherController.AttackDamage);
            }
        }
    }

    private void Rotate()
    {
        float y = Input.GetAxis("rotY");
        float x = Input.GetAxis("rotX");

        angleBackUp = angle;
        angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        if (angle == angleToAvoid)
            angle = angleBackUp;

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
