using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class EnemyController : MonoBehaviour
{
    public GameObject BloodOnDeathToInit;
    public float Speed = 0.5f;
    public float RotationSpeed = 1;
    public int AttackDamage = 20;

    private GameManager GameManagerObject;
    private Transform Target;
    private ParticleSystem BloodParticle;
    private Transform myTransform;
    private Rigidbody myRigidBody;
    private Health myHealth;
    private NavMeshAgent agent;
    private Animator animator;

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
        GameObject GamemanagerGameObject = GameObject.Find("Gamemanager");
        GameManagerObject = GamemanagerGameObject.GetComponent<GameManager>();

        GameObject TargetGameobject = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.destination = TargetGameobject.transform.position;
        Target = TargetGameobject.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        myRigidBody.drag = 15;
    }

    void Update()
    {
        if (!GameManagerObject.Pause)
        {
            FollowPlayer();
            agent.enabled = true;
            UpdateGoalPosition();
            animator.enabled = true;

        }
        else
        {
            agent.enabled = false;
            animator.enabled = false;

        }

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

            if (myHealth.HealthPoints <= 0)
                Instantiate(BloodOnDeathToInit, myTransform.position, Quaternion.identity);
        }
    }

    private void UpdateGoalPosition()
    {
        agent.destination = Target.transform.position;
    }

    private void FollowPlayer()
    {
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        var q = Quaternion.LookRotation(Target.position - myTransform.position);

        myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, q, RotationSpeed);
    }
}
