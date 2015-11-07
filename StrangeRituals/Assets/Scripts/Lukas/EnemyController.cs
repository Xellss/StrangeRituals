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

    private ParticleSystem BloodParticle;
    private Transform myTransform;
    private Rigidbody myRigidBody;
    private Health myHealth;

    private float rotation;
    private float attackTimer;
    private float attackDelay = 500;

    void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody>();
        myHealth = GetComponent<Health>();
        BloodParticle = GetComponentInChildren<ParticleSystem>();
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

            if (other.gameObject == Target.gameObject)
                other.gameObject.GetComponent<Health>().DecreaseHealth(AttackDamage);
        }

        if (other.gameObject.tag == "Bullet")
        {
            BloodParticle.Play();

            GameObject otherGameObject = other.gameObject;
            Bullet otherBullet = otherGameObject.GetComponentInChildren<Bullet>();
            myHealth.DecreaseHealth(otherBullet.Damage);
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
