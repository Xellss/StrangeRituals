using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 1;

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed,Space.World);
    }
}
