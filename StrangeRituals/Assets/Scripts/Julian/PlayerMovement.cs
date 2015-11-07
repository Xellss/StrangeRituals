using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 5000;

    private Transform transform;

    void Awake()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));
    }

}
