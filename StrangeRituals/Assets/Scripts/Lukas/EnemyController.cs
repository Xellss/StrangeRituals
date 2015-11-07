using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyController : MonoBehaviour 
{
    public Transform Target;
    public float Speed = 0.5f;
    public float RotationSpeed = 1;
    public int AttackDamage = 20;

    private Transform myTransform;
    private Rigidbody myRigidBody;

    private float rotation;
    private float attackTimer;
    private float attackDelay = 500;

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

    void OnCollisionEnter(Collision other)
    {
        attackTimer += Time.deltaTime;
        if (attackTimer <= attackDelay)
        {
            attackTimer = 0;

            if (other.gameObject.GetComponent<Health>() == null)
                return;

            if (other.gameObject == Target.gameObject)
                other.gameObject.GetComponent<Health>().DecreaseHealth(AttackDamage);
        }

        if (other.gameObject.tag == "Bullet")
        {
            Health health = GetComponent<Health>();
            BulletSpawn bullet = other.gameObject.GetComponent<BulletSpawn>();
            health.DecreaseHealth(bullet.Damage);
        }
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
