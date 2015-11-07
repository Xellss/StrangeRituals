using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyController : MonoBehaviour 
{
    public Transform Target;
    public float Speed = 0.5f;
    public float RotationSpeed = 1;

    private Transform myTransform;
    private Rigidbody myRigidBody;

    private float rotation;

    void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        GameObject TargetGameobject = GameObject.Find("Player");
        Target = TargetGameobject.GetComponent<Transform>();
        myRigidBody.drag = 15;
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        RotateToTarget();
        myRigidBody.AddRelativeForce(Vector3.forward * Speed, ForceMode.Force);
    }

    private void RotateToTarget()
    {
        var q = Quaternion.LookRotation(Target.position - myTransform.position);

        myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, q, RotationSpeed);
    }
}
