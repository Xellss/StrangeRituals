using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour
{
#pragma warning disable 0108
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float velocity;
#pragma warning restore

    public float HP = 100;

    public Transform target;

    public float MoveSpeed = 1;
    public int maxRange;
    public int minRange;

    public int state = 0; // state 0 is Idle, state 1 is attacking, state 2 is aggro

    void Start()
    {
        ChangeState<StateIdle>();
    }

    public void Move(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }

    private State currentState;

    public State CurrentState { get { return currentState; } }

    public void ChangeState<T>() where T : State, new()
    {
        currentState = new T();
    }

    void Update()
    {
        currentState.Update(this);
        velocity = rigidbody.velocity.magnitude;
    }
}
